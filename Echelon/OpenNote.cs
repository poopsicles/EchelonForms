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
        Form MainWindow;
        string[] note_contents;

        public OpenNote(int UID, int NID, byte[] PrivateKey, Form MainWindow)
        {
            InitializeComponent();
            this.UID = UID;
            this.NID = NID;
            this.PrivateKey = PrivateKey;
            this.MainWindow = MainWindow;
        }

        private void OpenNote_Load(object sender, EventArgs e)
        {
            note_contents = Services.Database.GetNoteContents(NID, PrivateKey);

            if (note_contents[0] != "" || note_contents[1] != "")
            {
                TitleTextbox.Text = note_contents[0];
                BodyTextbox.Text = note_contents[1];
            }
        }

        private void SaveNote()
        {
            string newTitle = String.IsNullOrEmpty(TitleTextbox.Text) ? "No title..." : TitleTextbox.Text;
            string newBody = String.IsNullOrEmpty(BodyTextbox.Text) ? "No body..." : BodyTextbox.Text;

            Services.Database.UpdateNote(NID, PrivateKey, newTitle, newBody);
        }

        private void SaveLabel_Click(object sender, EventArgs e)
        {
            SaveNote();

            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new OpenNote(UID, NID, PrivateKey, MainWindow));
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
            SaveNote();

            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new Home(MainWindow, UID, PrivateKey));
        }

        private void BodyTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveLabel.Text = "☁️!";
        }

        private void TitleTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveLabel.Text = "☁️!";
        }

        private void OpenNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    SaveNote();

                    MainWindow.Controls.Clear();
                    MainWindow.Controls.Add(new OpenNote(UID, NID, PrivateKey, MainWindow));
                }
            }
        }

        private void TitleTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    SaveNote();

                    MainWindow.Controls.Clear();
                    MainWindow.Controls.Add(new OpenNote(UID, NID, PrivateKey, MainWindow));
                }
            }
        }

        private void BodyTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    SaveNote();

                    MainWindow.Controls.Clear();
                    MainWindow.Controls.Add(new OpenNote(UID, NID, PrivateKey, MainWindow));
                }
            }
        }
    }
}
