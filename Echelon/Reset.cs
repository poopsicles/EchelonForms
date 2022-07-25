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
    public partial class Reset : UserControl
    {
        Form ParentContainer;
        bool confirmed = false;

        public Reset(Form MainWindow)
        {
            this.ParentContainer = MainWindow;
            InitializeComponent();
        }

        private void Reset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                MoveToWelcome();
            }
        }

        private void BackLabel_Click(object sender, EventArgs e)
        {
            MoveToLogin();
        }

        private void NextLabel_Click(object sender, EventArgs e)
        {
            MoveToWelcome();
        }

        public void MoveToWelcome()
        {
            if (!confirmed)
            {
                confirmed = true;
                NextLabel.Text = "Confirm? →";
            }
            else
            {
                // delete everything, move to welcome page
                using (var db = new Models.DatabaseContext())
                {
                    foreach (var user in db.Users)
                    {
                        db.Remove(user);
                    }

                    foreach (var note in db.Notes)
                    {
                        db.Remove(note);
                    }

                    db.SaveChanges();
                }

                ParentContainer.Controls.Clear();
                ParentContainer.Controls.Add(new Welcome(ParentContainer));
            }
        }

        public void MoveToLogin()
        {
            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Login(ParentContainer));
        }
    }
}
