using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Echelon.Models;


namespace Echelon
{
    public partial class MainWindow : Form
    {
        // MainWindow is the "container" for every other page in the application (User Controls)
        // So page transitions are achieved by removing the current control (the current page)
        // And then adding the control you want, with a reference to MainWindow

        public MainWindow()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        // On load, ensure the database exists and if it's new, open the Welcome splash
        // If not, open the Login page

            this.Controls.Clear();
            using (var db = new DatabaseContext())
            {
                db.Database.EnsureCreated();

                if (db.Users.Count() == 0)
                {
                    this.Controls.Add(new Welcome(this));
                } else
                {
                    this.Controls.Add(new Login(this));
                }
            }
        }
    }
}
