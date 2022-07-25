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
    public partial class OpenNote : UserControl
    {
        int UID;
        int NID;
        byte[] PrivateKey;
        Form ParentContainer;
        string[] note_contents;

        public OpenNote(int UID, int NID, byte[] PrivateKey, Form MainWindow)
        {
            this.UID = UID;
            this.NID = NID;
            this.PrivateKey = PrivateKey;
            this.ParentContainer = MainWindow;

            InitializeComponent();
        }

        private void OpenNote_Load(object sender, EventArgs e)
        {
            note_contents = Services.Database.GetNoteContents(NID, PrivateKey);

            // if it's empty don't overwrite the placeholder text
            if (note_contents[0] != "" || note_contents[1] != "")
            {
                TitleTextbox.Text = note_contents[0];
                BodyTextbox.Text = note_contents[1];
            }
        }

        // on text change - update saved status icon
        private void BodyTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveLabel.Text = "☁️!";
        }

        private void TitleTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveLabel.Text = "☁️!";
        }

        private void SaveLabel_Click(object sender, EventArgs e)
        {
            // save and refresh
            MoveToNote();
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
            // save and go back
            MoveToHome();
        }

        // Ctrl + S handlers
        private void OpenNote_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    MoveToNote();
                }
            }
        }

        private void TitleTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    MoveToNote();
                }
            }
        }

        private void BodyTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    MoveToNote();
                }
            }
        }

        private void SaveNote()
        {
            // if it's empty place dummy text
            string newTitle = String.IsNullOrEmpty(TitleTextbox.Text) ? "No Title" : TitleTextbox.Text;
            string newBody = String.IsNullOrEmpty(BodyTextbox.Text) ? "No Body..." : BodyTextbox.Text;

            Services.Database.UpdateNote(NID, PrivateKey, newTitle, newBody);
        }

        private void MoveToNote()
        {
            SaveNote();

            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new OpenNote(UID, NID, PrivateKey, ParentContainer));
        }

        private void MoveToHome()
        {
            SaveNote();

            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Home(ParentContainer, UID, PrivateKey));
        }
    }
}
