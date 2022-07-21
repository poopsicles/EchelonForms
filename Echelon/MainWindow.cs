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
        public MainWindow()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
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
