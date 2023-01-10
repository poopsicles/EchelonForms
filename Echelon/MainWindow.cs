using Echelon.Models;
using System.Drawing.Text;
using System.Runtime.InteropServices;


namespace Echelon
{
    public partial class MainWindow : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [In] ref uint pcFonts);

        // interCollection.Families
        // { System.Drawing.FontFamily[16]
        //        [0]: { Name = "Inter"}
        //        [1]: { Name = "Inter Black"}
        //        [2]: { Name = "Inter Black Italic"}
        //        [3]: { Name = "Inter Extra Bold"}
        //        [4]: { Name = "Inter Extra Bold Italic"}
        //        [5]: { Name = "Inter Extra Light"}
        //        [6]: { Name = "Inter Extra Light Italic"}
        //        [7]: { Name = "Inter Italic"}
        //        [8]: { Name = "Inter Light"}
        //        [9]: { Name = "Inter Light Italic"}
        //        [10]: { Name = "Inter Medium"}
        //        [11]: { Name = "Inter Medium Italic"}
        //        [12]: { Name = "Inter Semi Bold"}
        //        [13]: { Name = "Inter Semi Bold Italic"}
        //        [14]: { Name = "Inter Thin"}
        //        [15]: { Name = "Inter Thin Italic"}

        public PrivateFontCollection interCollection = new PrivateFontCollection();

        // MainWindow is the "container" for every other page in the application (User Controls)
        // So page transitions are achieved by removing the current control (the current page)
        // And then adding the control you want, with a reference to MainWindow

        public MainWindow()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            // getting the font data
            byte[] fontData = Properties.Resources.Inter;

            // copying the font into memory
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            // registering the font with the system
            uint dummy = 0;
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Inter.Length, IntPtr.Zero, ref dummy);
            dummy += 1;

            // add to our collection
            interCollection.AddMemoryFont(fontPtr, Properties.Resources.Inter.Length);

            // free memory
            Marshal.FreeCoTaskMem(fontPtr);
            fontPtr = IntPtr.Zero;
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
                }
                else
                {
                    this.Controls.Add(new Login(this));
                }
            }
        }
    }
}
