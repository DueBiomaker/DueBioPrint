using BioPrint.model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BioPrint.view.utils
{
    public partial class SplashScreen : Form
    {
        private static string file;
        private static SplashScreen splash = null;
        bool painted = false;

        public static void run()
        {
            int dur = Custom.GetInteger("splashscreenDelay", 0);
            if (dur <= 0) return;
            file = Application.StartupPath + Path.DirectorySeparatorChar + Custom.GetString("splashscreenImage", "doesnotexist");
            if (!File.Exists(file))
                return;
            splash = new SplashScreen();
            splash.Show();
            splash.timer.Interval = 1000 * dur;
            splash.timer.Start();
        }

        public SplashScreen()
        {
            InitializeComponent();
            Image img = Image.FromFile(file);
            BackgroundImage = img;
            Width = img.Width;
            Height = img.Height;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Hide();
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            if (painted) return;
            e.Graphics.DrawImage(BackgroundImage, 0, 0, Width, Height);
            painted = true;
        }
    }
}