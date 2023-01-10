using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Echelon.Services;

namespace Echelon
{
    public partial class Login : UserControl
    {
        int UID;
        string name;
        byte[] StoredHash;
        byte[] UnlockedPrivateKey;
        MainWindow ParentContainer;

        public Login(MainWindow Parent)
        {
            this.ParentContainer = Parent;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            NameLabel.Font = new Font(ParentContainer.interCollection.Families[12], 36F, FontStyle.Regular);
            QuestionLabel.Font = new Font(ParentContainer.interCollection.Families[12], 36F, FontStyle.Regular);
            BorderLabel.Font = new Font(ParentContainer.interCollection.Families[0], 36F, FontStyle.Bold);
            NextLabel.Font = new Font(ParentContainer.interCollection.Families[0], 36F, FontStyle.Bold);
            ValidationLabel.Font = new Font(ParentContainer.interCollection.Families[0], 11.25F, FontStyle.Regular);
            ForgotLabel.Font = new Font(ParentContainer.interCollection.Families[0], 11.25F, FontStyle.Regular);

            // for now there's only one user, so get the first name
            using (var db = new Models.DatabaseContext())
            {
                UID = db.Users.First().UserID;
                name = db.Users.First(c => c.UserID == UID).Name;
                StoredHash = db.Users.First(c => c.UserID == UID).PasswordHash;
            }

            NameLabel.Text = $"Welcome back, {name}";
            ForgotLabel.Text = $"Forgot password or not {name}?";
        }

        private void NextLabel_Click(object sender, EventArgs e)
        {
            GoToHome();
        }

        private void ForgotLabel_Click(object sender, EventArgs e)
        {
            // go to data deletion page
            GoToReset();
        }

        private void inputTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                // validate
                GoToHome();
            }
        }

        private void NextLabel_MouseEnter(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(24, 120, 215);
        }

        private void NextLabel_MouseLeave(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(30, 144, 255);
        }

        private void inputTextbox_Enter(object sender, EventArgs e)
        {
            BorderLabel.ForeColor = Color.FromArgb(24, 120, 215);
        }

        private void inputTextbox_Leave(object sender, EventArgs e)
        {
            BorderLabel.ForeColor = Color.FromArgb(30, 144, 255);
        }

        private void ForgotLabel_MouseEnter(object sender, EventArgs e)
        {
            ForgotLabel.ForeColor = Color.FromArgb(125, 125, 125);
        }

        private void ForgotLabel_MouseLeave(object sender, EventArgs e)
        {
            ForgotLabel.ForeColor = Color.FromArgb(105, 105, 105);
        }

        public void GoToHome()
        {
            if (String.IsNullOrEmpty(inputTextbox.Text.Trim()))
            {
                ValidationLabel.Visible = true;
            }
            else
            {
                if (Crypto.ValidateHash(inputTextbox.Text, StoredHash))
                {
                    // password correct
                    ValidationLabel.Visible = false;

                    using (var db = new Models.DatabaseContext())
                    {
                        UnlockedPrivateKey = Crypto.GetPrivateKey(inputTextbox.Text, db.Users.First(c => c.UserID == UID).ProtectedPrivateKey);
                    }

                    ParentContainer.Controls.Clear();
                    ParentContainer.Controls.Add(new Home(ParentContainer, UID, UnlockedPrivateKey));
                }
                else
                {
                    // password wrong
                    inputTextbox.Clear();
                    ValidationLabel.Visible = true;
                }
            }
        }

        private void GoToReset()
        {
            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Reset(ParentContainer));
        }
    }
}
