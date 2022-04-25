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
        // events
        public event EventHandler CloseBothForms;

        private void RaiseCloseForms()
        {
            var handler = CloseBothForms;
            if (handler != null)
                CloseBothForms(this, EventArgs.Empty);
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

        }

    }
}
