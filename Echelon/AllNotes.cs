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
        Form ParentContainer;

        public AllNotes(int UID, byte[] PrivateKey, Form Mainwindow) 
        {
            this.UID = UID;
            this.PrivateKey = PrivateKey;
            this.ParentContainer = Mainwindow;
            NIDs = new List<int>();
            
            InitializeComponent();
        }

        private void AllNotes_Load(object sender, EventArgs e)
        {
            // get the total number of notes for the header
            // and the note titles themselves to the grid and the corresponding IDs to a list

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
            // go home

            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Home(ParentContainer, UID, PrivateKey));
        }

        private void NotesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var noteID = NIDs.ElementAt(NotesGridView.CurrentCell.RowIndex);
            
            if (NotesGridView.CurrentCell.ColumnIndex.Equals(2)) // export button
            {
                // get the contents and export

                var noteContents = Services.Database.GetNoteContents(noteID, PrivateKey);
                string fileContents = $"# {noteContents[0]}\n\n{noteContents[1]}\n\n*Last modified: {noteContents[2]}*";

                Stream myStream;
                SaveFileDialog dialogBox = new SaveFileDialog();

                dialogBox.Filter = "Markdown files (*.md)|*.md|All files (*.*)|*.*";
                dialogBox.FilterIndex = 0;
                dialogBox.RestoreDirectory = true;

                if (dialogBox.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = dialogBox.OpenFile()) != null)
                    {
                        using (StreamWriter streamwriter = new StreamWriter(myStream))
                        {
                            streamwriter.Write(fileContents);
                        }
                        
                        myStream.Close();
                    }
                }

                NotesGridView.CurrentCell.Selected = false;
            } else if (NotesGridView.CurrentCell.ColumnIndex.Equals(3)) { // delete button
                // get the NID, delete, reload

                Services.Database.DropNote(noteID);

                if  (NIDs.Count() - 1 == 0)
                {
                    // exhausted all notes, back to home
                    ParentContainer.Controls.Clear();
                    ParentContainer.Controls.Add(new Home(ParentContainer, UID, PrivateKey));
                } else
                {
                    ParentContainer.Controls.Clear();
                    ParentContainer.Controls.Add(new AllNotes(UID, PrivateKey, ParentContainer));
                }
            } else // title button
            {
                // get the row index, match the NID, open

                ParentContainer.Controls.Clear();
                ParentContainer.Controls.Add(new OpenNote(UID, noteID, PrivateKey, ParentContainer));
            }
        }
    }
}
