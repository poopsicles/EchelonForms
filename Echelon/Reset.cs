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
        MainWindow ParentContainer;
        bool confirmed = false;

        public Reset(MainWindow Parent)
        {
            this.ParentContainer = Parent;
            InitializeComponent();
        }

        private void Reset_Load(object sender, EventArgs e)
        {
            NameLabel.Font = new Font(ParentContainer.interCollection.Families[12], 36F, FontStyle.Regular);
            NextLabel.Font = new Font(ParentContainer.interCollection.Families[12], 27.75F, FontStyle.Regular);
            InfoLabel1.Font = new Font(ParentContainer.interCollection.Families[0], 18.75F, FontStyle.Regular);
            InfoLabel2.Font = new Font(ParentContainer.interCollection.Families[0], 18.75F, FontStyle.Regular);
            BackLabel.Font = new Font(ParentContainer.interCollection.Families[0], 14.25F, FontStyle.Bold);
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

        private void NextLabel_MouseEnter(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(255, 44, 44);
        }

        private void NextLabel_MouseLeave(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(255, 0, 0);
        }

        private void BackLabel_MouseEnter(object sender, EventArgs e)
        {
            BackLabel.ForeColor = Color.FromArgb(255, 44, 44);
        }

        private void BackLabel_MouseLeave(object sender, EventArgs e)
        {
            BackLabel.ForeColor = Color.FromArgb(255, 0, 0);
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
