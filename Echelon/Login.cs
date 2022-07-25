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
        Form ParentContainer;


        public Login(Form MainWindow)
        {
            this.ParentContainer = MainWindow;

            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
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
