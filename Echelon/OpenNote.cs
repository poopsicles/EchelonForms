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
        MainWindow ParentContainer;

        public OpenNote(int UID, int NID, byte[] PrivateKey, MainWindow Parent)
        {
            this.UID = UID;
            this.NID = NID;
            this.PrivateKey = PrivateKey;
            this.ParentContainer = Parent;

            InitializeComponent();
        }

        private void OpenNote_Load(object sender, EventArgs e)
        {
            TitleTextbox.Font = new Font(ParentContainer.interCollection.Families[12], 24.75F, FontStyle.Regular);
            BodyTextbox.Font = new Font(ParentContainer.interCollection.Families[0], 11.25F, FontStyle.Regular);
            HomeLabel.Font = new Font(ParentContainer.interCollection.Families[0], 14.25F, FontStyle.Bold);
            modifiedLabel.Font = new Font(ParentContainer.interCollection.Families[0], 9.75F, FontStyle.Regular);

            string[] note_contents = Services.Database.GetNoteContents(NID, PrivateKey);
            TitleTextbox.Text = note_contents[0];
            BodyTextbox.Text = note_contents[1];
            
            updateModified();
        }

        // on text change, save the note
        private void TitleTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveNote();
        }

        private void BodyTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveNote();
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
            // go back
            MoveToHome();
        }

        private void HomeLabel_MouseEnter(object sender, EventArgs e)
        {
            HomeLabel.ForeColor = Color.FromArgb(24, 120, 215);
        }

        private void HomeLabel_MouseLeave(object sender, EventArgs e)
        {
            HomeLabel.ForeColor = Color.FromArgb(30, 144, 255);
        }

        private void SaveNote()
        {
            // if it's empty place empty text
            string newTitle = String.IsNullOrEmpty(TitleTextbox.Text) ? "" : TitleTextbox.Text;
            string newBody = String.IsNullOrEmpty(BodyTextbox.Text) ? "" : BodyTextbox.Text;

            Services.Database.UpdateNote(NID, PrivateKey, newTitle, newBody);
        }

        private void MoveToHome()
        {
            modifiedTimer.Enabled = false;
            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Home(ParentContainer, UID, PrivateKey));
        }

        private void modifiedTimer_Tick(object sender, EventArgs e)
        {
            updateModified();
        }

        private void updateModified()
        {
            var last_saved = Services.Database.GetNoteDateModified(NID);
            var interval = DateTime.Now - last_saved;

            if (interval <= new TimeSpan(0, 0, 5))
            {
                modifiedLabel.Text = "Saved just now";
            }
            else if (interval <= new TimeSpan(0, 2, 0))
            {
                modifiedLabel.Text = "Saved within a minute";
            }
            else if (interval <= new TimeSpan(0, 10, 0))
            {
                modifiedLabel.Text = "Saved a few minutes ago";
            }
            else if (interval <= new TimeSpan(1, 0, 0))
            {
                modifiedLabel.Text = "Saved within the hour";
            }
            else if (interval <= new TimeSpan(1, 0, 0, 0))
            {
                modifiedLabel.Text = "Saved earlier today";
            }
            else
            {
                modifiedLabel.Text = String.Format($"Saved on {last_saved}");
            }
        }
    }
}
