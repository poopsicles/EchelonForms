using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echelon
{
    public partial class AllNotes : UserControl
    {
        int UID;
        byte[] PrivateKey;
        List<int> NIDs;
        Form MainWindow;

        public AllNotes(int UID, byte[] PrivateKey, Form Mainwindow) 
        {
            InitializeComponent();
            this.UID = UID;
            this.PrivateKey = PrivateKey;
            this.MainWindow = Mainwindow;
            NIDs = new List<int>();
        }

        private void AllNotes_Load(object sender, EventArgs e)
        {
            using (var db = new Models.DatabaseContext())
            {
                TotalLabel.Text = $"{db.Notes.Where(c => c.UserID == UID).Count()} in total";

                foreach (var note in db.Notes.Where(c => c.UserID == UID).OrderBy(c => c.LastModified).Reverse()) {
                    var title = Services.Crypto.DecryptString(Services.Crypto.DecryptBytes(PrivateKey, note.EncryptedKey), note.EncryptedTitle);       
                    
                    NotesGridView.Rows.Add(title, note.LastModified.ToString("f"), "Export 💾", "Delete ❌");
                    NIDs.Add(note.NoteID);
                }
            }

            NotesGridView.CurrentCell.Selected = false;
        }


        private void HomeLabel_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new Home(MainWindow, UID, PrivateKey));
        }

        private void NotesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var noteID = NIDs.ElementAt(NotesGridView.CurrentCell.RowIndex);
            var noteContents = Services.Database.GetNoteContents(noteID, PrivateKey);
            string fileContents = $"## {noteContents[0]}\n\n{noteContents[1]}\n\nLast modified: {noteContents[2]}";

            if (NotesGridView.CurrentCell.ColumnIndex.Equals(2)) 
            {
                // get the row index, match the NID, export

                Stream myStream;
                SaveFileDialog dialog1 = new SaveFileDialog();

                dialog1.Filter = "Markdown files (*.md)|*.md|All files (*.*)|*.*";
                dialog1.FilterIndex = 0;
                dialog1.RestoreDirectory = true;

                if (dialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = dialog1.OpenFile()) != null)
                    {
                        using (StreamWriter streamwriter = new StreamWriter(myStream))
                        {
                            streamwriter.Write(fileContents);
                        }
                        
                        myStream.Close();
                    }
                }

                NotesGridView.CurrentCell.Selected = false;
            } else if (NotesGridView.CurrentCell.ColumnIndex.Equals(3)) {
                // get the NID, delete, reload

                Services.Database.DropNote(noteID);

                if  (NIDs.Count() - 1 == 0)
                {
                    // exhausted all notes
                    MainWindow.Controls.Clear();
                    MainWindow.Controls.Add(new Home(MainWindow, UID, PrivateKey));
                } else
                {
                    MainWindow.Controls.Clear();
                    MainWindow.Controls.Add(new AllNotes(UID, PrivateKey, MainWindow));
                }
            } else 
            {
                // get the row index, match the NID, open
                MainWindow.Controls.Clear();
                MainWindow.Controls.Add(new OpenNote(UID, noteID, PrivateKey, MainWindow));
            }
        }
    }
}
