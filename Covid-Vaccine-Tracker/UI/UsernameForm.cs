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
    public partial class UsernameForm : Form
    {
        string Username;
        string appTitle = "Covid Vaccine Tracker";
        int _ticks;
        // events
        public event EventHandler GoToPrevForm;

        private void RaiseGoToPrevForm()
        {
            var handler = GoToPrevForm;
            if (handler != null)
                GoToPrevForm(this, EventArgs.Empty);
        }
        public UsernameForm()
        {
            InitializeComponent();
        }
        public UsernameForm(string usrname)
        {
            InitializeComponent();
            Username = usrname;
        }
        private void UsernameForm_Load(object sender, EventArgs e)
        {
            try
            {
                // set place holder text in username box
                for (int elm = 0; elm <= 10; elm++)
                {
                    UsernameTxt.Text += "*";
                }
            }
            catch(Exception ex)
            { DisplayMsg(ex.Message, appTitle,"err"); }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            RaiseGoToPrevForm();
        }

        private void UsernameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RaiseGoToPrevForm();
        }
        private void DisplayMsg(string msg, string title, string MsgType)
        {
            MessageBoxIcon icon = new MessageBoxIcon();

            switch (MsgType)
            {
                case "err":
                    icon = MessageBoxIcon.Error;
                    break;
                case "inf":
                    icon = MessageBoxIcon.Information;
                    break;
            }

            MessageBox.Show(msg, title, MessageBoxButtons.OK, icon);
        }

        private void UncoverBtn_Click(object sender, EventArgs e)
        {
            //reset ticks then start timer
            _ticks = 0;
            Timer.Start();
            UsernameTxt.Text = Username;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _ticks++;

            if (_ticks >= 25)
            {
                Timer.Stop();
                for (int elm = 0; elm <= 10; elm++)
                {
                    UsernameTxt.Text = "*";
                }
            }
        }
    }
}
