using BioMaker.model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BioMaker.view.utils
{
    public partial class SplashScreen : Form
    {
        private static string file;
        private static SplashScreen splash = null;

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
    }
}