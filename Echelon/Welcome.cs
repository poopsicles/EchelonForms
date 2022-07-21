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
        Form MainWindow;

        public void MoveToOnboarding()
        {
            TickTimer.Enabled = false;
            MainWindow.Controls.Clear();
            MainWindow.Controls.Add(new Onboarding(MainWindow));
        }

        public Welcome(Form MainWindow)
        {
            this.MainWindow = MainWindow;
            InitializeComponent();
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
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
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                MoveToOnboarding();
            }
        }
    }
}
