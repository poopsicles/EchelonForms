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
    public partial class Welcome : UserControl
    {
        MainWindow ParentContainer;

        public Welcome(MainWindow Parent)
        {
            this.ParentContainer = Parent;
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Font = new Font(ParentContainer.interCollection.Families[12], 36, FontStyle.Regular);
            GreetingLabel.Font = new Font(ParentContainer.interCollection.Families[12], 36, FontStyle.Regular);
            NextLabel.Font = new Font(ParentContainer.interCollection.Families[12], 36, FontStyle.Regular);
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
        // primitive animation things

            switch (GreetingLabel.Text)
            {
                case "simple notes.":
                    GreetingLabel.Text = "fast notes.";
                    EmojiLabel.Text = "⚡";
                    break;

                case "fast notes.":
                    GreetingLabel.Text = "secure notes.";
                    EmojiLabel.Text = "🔒";
                    break;

                case "secure notes.":
                    GreetingLabel.Text = "simple notes.";
                    EmojiLabel.Text = "👌";
                    break;
            }
        }

        private void NextLabel_Click(object sender, EventArgs e)
        {
            MoveToOnboarding();
        }

        private void Welcome_KeyDown(object sender, KeyEventArgs e)
        {
        // handles the user pressing "Enter" instead of clicking the button

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                MoveToOnboarding();
            }
        }

        // hover effects
        private void NextLabel_MouseEnter(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(24, 120, 215);
        }

        private void NextLabel_MouseLeave(object sender, EventArgs e)
        {
            NextLabel.ForeColor = Color.FromArgb(30, 144, 255);
        }

        public void MoveToOnboarding()
        {
            // clears the parent MainWindow (removing itself), makes a new Onboarding control
            // and passes Mainwindow *into* Onboarding, allowing it to be controlled by the new control

            TickTimer.Enabled = false;
            ParentContainer.Controls.Clear();
            ParentContainer.Controls.Add(new Onboarding(ParentContainer));
        }
    }
}
