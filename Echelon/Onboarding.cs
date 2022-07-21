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
        Form MainWindow;
        string name;
        string password;
        bool askingPass = false;
        int newUserID;

        public Onboarding(Form MainWindow)
        {
            this.MainWindow = MainWindow;
            InitializeComponent();
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
                    case false: // stage one
                        ValidationLabel.Visible = false;
                        name = inputTextbox.Text;
                        inputTextbox.Clear();
                        QuestionLabel.Text = "And a password too.";
                        inputTextbox.UseSystemPasswordChar = true;
                        GagTimer.Enabled = false;
                        inputTextbox.PlaceholderText = "";
                        askingPass = true;

                        break;

                    case true: // stage two
                        ValidationLabel.Visible = false;
                        password = inputTextbox.Text;

                        newUserID = Services.Database.AddUser(name, password);

                        MainWindow.Controls.Clear();
                        MainWindow.Controls.Add(new Login(MainWindow));
                        break;
                }
            }
        }

        public void MoveToWelcome()
        {
            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new Welcome(MainWindow));
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

        private void NextLabel_Click(object sender, EventArgs e)
        {
            MoveToHome();
        }

        private void BackLabel_Click(object sender, EventArgs e)
        {
            MoveToWelcome();
        }

        private void GagTimer_Tick(object sender, EventArgs e)
        {
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
    }
}
