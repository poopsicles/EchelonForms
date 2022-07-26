﻿using System;
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
        Form ParentContainer;
        int UID;
        string name = "";
        byte[] PrivateKey;

        public Home(Form MainWindow, int UID, byte[] PrivateKey)
        {
            this.ParentContainer = MainWindow;
            this.PrivateKey = PrivateKey;
            this.UID = UID;

            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
        // check the time of day, and adjust the greeting accordingly

            using (var db = new Models.DatabaseContext())
            {
                // for now, only one user is allowed, so simply grab the first name from the database
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

            // are there already notes associated with that user?
            using (var db = new Models.DatabaseContext())
            {
                if (db.Notes.Where(c => c.UserID == UID).Count() == 0)
                {
                    AllNotesButton.Enabled = false;
                }
            }
        }

        private void BackgroundLockTimer_Tick(object sender, EventArgs e)
        {
            GoToLogin();
        }

        private void ManualLockTimer_Tick(object sender, EventArgs e)
        {
            GoToLogin();
        }

        private void LockLabel_Click(object sender, EventArgs e)
        {
            // changes button text and locks after 0.8s to allow the animation to show

            LockLabel.Text = "🔐";
            ManualLockTimer.Enabled = true;
        }

        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            GoToNewNote();
        }

        private void AllNotesButton_Click(object sender, EventArgs e)
        {
            GoToAllNotes();
        }

        private void GoToLogin()
        {
            BackgroundLockTimer.Enabled = false;
            ManualLockTimer.Enabled = false;

            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Login(ParentContainer));
        }

        private void GoToNewNote()
        {
            var newNoteID = Services.Database.AddNote(UID);

            BackgroundLockTimer.Enabled = false;
            ManualLockTimer.Enabled = false;

            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new OpenNote(UID, newNoteID, PrivateKey, ParentContainer));
        }

        private void GoToAllNotes()
        {
            BackgroundLockTimer.Enabled = false;
            ManualLockTimer.Enabled = false;

            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new AllNotes(UID, PrivateKey, ParentContainer));
        }
    }
}
