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
    public partial class Onboarding : UserControl
    {
        MainWindow ParentContainer;

        string name = "";
        string password = "";
        bool askingPass = false;

        public Onboarding(MainWindow Parent)
        {
            this.ParentContainer = Parent;
            InitializeComponent();
        }

        private void Onboarding_Load(object sender, EventArgs e)
        {
            BackLabel.Font = new Font(ParentContainer.interCollection.Families[0], 14.25F, FontStyle.Bold);
            QuestionLabel.Font = new Font(ParentContainer.interCollection.Families[12], 36F, FontStyle.Regular);
            inputTextbox.Font = new Font(ParentContainer.interCollection.Families[0], 24.75F, FontStyle.Regular);
            ValidationLabel.Font = new Font(ParentContainer.interCollection.Families[0], 11.25F, FontStyle.Regular);
            borderLabel.Font = new Font(ParentContainer.interCollection.Families[0], 36F, FontStyle.Bold);
            NextLabel.Font = new Font(ParentContainer.interCollection.Families[0], 36F, FontStyle.Bold);
        }

        private void GagTimer_Tick(object sender, EventArgs e)
        {
        // switches the placeholder text if the user waits long enough

            switch (inputTextbox.PlaceholderText)
            {
                case "Alexander":
                    inputTextbox.PlaceholderText = "Julia";
                    break;

                case "Julia":
                    inputTextbox.PlaceholderText = "Minecraft Steve";
                    break;

                case "Minecraft Steve":
                    inputTextbox.PlaceholderText = "Steve Jobs";
                    break;

                case "Steve Jobs":
                    inputTextbox.PlaceholderText = "Eliza";
                    break;

                case "Eliza":
                    inputTextbox.PlaceholderText = "Alexander";
                    break;
            }
        }

        private void NextLabel_Click(object sender, EventArgs e)
        {
            MoveToHome();
        }

        private void BackLabel_Click(object sender, EventArgs e)
        {
            MoveToWelcome();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                MoveToHome();
            }
        }

        private void inputTextbox_Enter(object sender, EventArgs e)
        {
            // make the text black from placeholder grey
            inputTextbox.ForeColor = Color.Black;
            borderLabel.ForeColor = Color.FromArgb(24, 120, 215);
        }

        private void inputTextbox_Leave(object sender, EventArgs e)
        {
            inputTextbox.ForeColor = Color.FromArgb(30, 144, 255);
        }

        private void BackLabel_MouseEnter(object sender, EventArgs e)
        {
            BackLabel.ForeColor = Color.FromArgb(24, 120, 215);
        }

        private void BackLabel_MouseLeave(object sender, EventArgs e)
        {
            BackLabel.ForeColor = Color.FromArgb(30, 144, 255);
        }

        private void NextLabel_MouseEnter(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(24, 120, 215);
        }

        private void NextLabel_MouseLeave(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(30, 144, 255);
        }

        public void MoveToHome()
        {
            if (String.IsNullOrEmpty(inputTextbox.Text.Trim()))
            {
                ValidationLabel.Visible = true;
            }
            else
            {
                switch (askingPass)
                {
                    // since we're reusing the same textbox, we need to change other components depending
                    // on whether it's a name or password that's being requested

                    case false: // stage one - name
                        ValidationLabel.Visible = false;
                        name = inputTextbox.Text;
                        inputTextbox.Clear();

                        QuestionLabel.Text = "And a password too.";
                        inputTextbox.UseSystemPasswordChar = true;
                        GagTimer.Enabled = false;
                        inputTextbox.PlaceholderText = "";
                        askingPass = true;

                        break;

                    case true: // stage two - password
                        ValidationLabel.Visible = false;
                        password = inputTextbox.Text;

                        Services.Database.AddUser(name, password);

                        ParentContainer.Controls.Clear();
                        ParentContainer.Controls.Add(new Login(ParentContainer));
                        break;
                }
            }
        }

        public void MoveToWelcome()
        {
            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Welcome(ParentContainer));
        }
    }
}
