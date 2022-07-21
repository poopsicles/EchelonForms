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
    public partial class Home : UserControl
    {
        Form MainWindow;
        int UID;
        string name;
        byte[] PrivateKey;

        public Home(Form MainWindow, int UID, byte[] PrivateKey)
        {
            this.MainWindow = MainWindow;
            this.PrivateKey = PrivateKey;
            this.UID = UID;

            InitializeComponent();
        }

        private void GoToLogin()
        {
            BackgroundLockTimer.Enabled = false;
            ManualLockTimer.Enabled = false;

            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new Login(MainWindow));
        }

        private void Home_Load(object sender, EventArgs e)
        {
            using (var db = new Models.DatabaseContext())
            {
                name = db.Users.First(c => c.UserID == UID).Name;
            }

            TimeSpan now = DateTime.Now.TimeOfDay;
            TimeSpan morning = new TimeSpan(5, 0, 0);
            TimeSpan noon = new TimeSpan(12, 0, 0);
            TimeSpan evening = new TimeSpan(20, 0, 0);

            if (now >= morning && now < noon)
            {
                NameLabel.Text = $"Good morning, {name}";
            } else if (now >= noon && now < evening)
            {
                NameLabel.Text = $"Good afternoon, {name}";
            } else
            {
                NameLabel.Text = $"How did your day go, {name}";
                GreetingLabel.Text = "What are we creating tonight?";
            }


            using (var db = new Models.DatabaseContext())
            {
                if (db.Notes.Where(c => c.UserID == UID).Count() == 0)
                {
                    AllNotesButton.Enabled = false;
                }
            }
        }

        private void LockLabel_Click(object sender, EventArgs e)
        {
            LockLabel.Text = "🔐";
            ManualLockTimer.Enabled = true;
        }

        private void BackgroundLockTimer_Tick(object sender, EventArgs e)
        {
            GoToLogin();
        }

        private void ManualLockTimer_Tick(object sender, EventArgs e)
        {
            GoToLogin();
        }

        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            // create a new note and open
            var newNoteID = Services.Database.AddNote(UID);

            BackgroundLockTimer.Enabled = false;
            ManualLockTimer.Enabled = false;

            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new OpenNote(UID, newNoteID, PrivateKey, MainWindow));
        }

        private void AllNotesButton_Click(object sender, EventArgs e)
        {
            // go to all notes page
            BackgroundLockTimer.Enabled = false;
            ManualLockTimer.Enabled = false;

            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new AllNotes(UID, PrivateKey, MainWindow));
        }
    }
}
