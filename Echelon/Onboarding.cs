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
        Form ParentContainer;
        string name = "";
        string password = "";
        bool askingPass = false;
        int newUserID;

        public Onboarding(Form MainWindow)
        {
            this.ParentContainer = MainWindow;
            InitializeComponent();
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

                        newUserID = Services.Database.AddUser(name, password);

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
