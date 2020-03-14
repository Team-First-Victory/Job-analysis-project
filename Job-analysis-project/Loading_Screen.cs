using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Job_analysis_project
{
    /// <summary>
    /// Loading_Screen class to handle loading screen.
    /// </summary>
    partial class Loading_Screen : Form
    {
        Timer LoadingTimer = new Timer();
        Timer RocketTimer = new Timer();
        public Loading_Screen()
        {
            InitializeComponent();
        }
        void Default()
        {
            lbLoading.Text = "Loading ...";
            pnlLoadingBar.Width = 0;
            picRocket.Top = 202;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadingTimer.Tick += LoadingTimer_Tick;
            RocketTimer.Tick += RocketTimer_Tick;
            LoadingTimer.Interval = 1;
            RocketTimer.Interval = 1;
            LoadingTimer.Start();
        }

        private void RocketTimer_Tick(object sender, EventArgs e)
        {
            if (picRocket.Top <= 5)
            {
                picRocket.Top = 202;
                picRocket.BackgroundImage = Job_analysis_project.Properties.Resources.rocket_size_48;
                RocketTimer.Stop();
                Default();
                LoadingTimer.Start();
            }
            else
            {
                picRocket.Top -= 5;
            }
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            if (pnlLoadingBar.Width < 700)
            {
                pnlLoadingBar.Width += 7;
                lbLoading.Text = "Loading ...";
            }
            else
            {
                picRocket.BackgroundImage = Job_analysis_project.Properties.Resources.rocket_size_48;
                LoadingTimer.Stop();
                RocketTimer.Start();
            }
        }
    }
}
