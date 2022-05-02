using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class SplashForm : Form
    {
        int _ticks;
        public SplashForm()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _ticks++;

            if (_ticks == 15)
            {
                timer.Stop();
                LoginForm login = new LoginForm();
                this.Hide();
                login.ShowDialog();
                this.Close();
            }
        }


    }
}
