using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Covid_Vaccine_Tracker.Data_Access_Layer;
using Covid_Vaccine_Tracker.Business_Objects;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class UpdateAccountForm : Form
    {
        bool usernameRecovery = false, passwordRecovery = false;
        (bool, string) IsValid;
        string _Username, _Fname, _Lname;
        string appTitle = "Covid Vaccine Trackdr";
        string _AccountType;
        bool possibleDataLoss = true;

        public event EventHandler GoToLogin;
        // event for closing this form and prev form
        private void RaiseGoToLogin()
        {
            var handler = GoToLogin;
            if (handler != null)
                GoToLogin(this, EventArgs.Empty);
        }
        public UpdateAccountForm()
        {
            InitializeComponent();
        }
        public UpdateAccountForm(string username)
        {
            InitializeComponent();
            passwordRecovery = true;
            _Username = username;
        }
        public UpdateAccountForm(string fname, string lname, string account)
        {
            InitializeComponent();
            usernameRecovery = true;
            _Fname = fname;
            _Lname = lname;
            _AccountType = account;
        }

        private void UpdateAccountForm_Load(object sender, EventArgs e)
        {
            if (usernameRecovery && !passwordRecovery)
            {
                try
                {
                    string usrname = string.Empty;
                    // enable the username display disable the password display
                    UsernameControls("Enable");
                    PasswordControls("Disable");
                    // set the button layout
                    SetButtonLayout("Username");
                    // now get the username from the db

                    switch(_AccountType.ToLower())
                    {
                        case "provider":
                            usrname = UserDB.RecoverProviderUsername(_Fname, _Lname);
                            break;
                        case "cdc":
                            usrname = UserDB.RecoverCDCUsername(_Fname, _Lname);
                            break;
                    }
                    // then display the usrname in the textbox
                    UsernameTxt.Text = usrname;
                }
                catch(Exception ex)
                { DisplayError(ex.Message, appTitle); }
            }
            else if (passwordRecovery && !usernameRecovery)
            {
                UsernameControls("Disable");
                PasswordControls("Enable");
                SetButtonLayout("Password");
            }    
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            int tbox = -1;

            IsValid = CheckForm(ref tbox);

            if (IsValid.Item1)
            {
                string pwd = PwdVerifyTxt.Text.Trim();
                bool wasSuccess = UserDB.UpdatePassword(_Username, pwd);

                if (wasSuccess)
                {
                    DisplaySuccess("Your password has been updated succesfully", appTitle);
                    // go back to login
                    RaiseGoToLogin();
                }
                else if (!wasSuccess)
                    DisplayError(Errors.GetGeneralError(11, "Password"), appTitle);
            }
            else if (!IsValid.Item1)
                SetErrorPv(tbox, IsValid.Item2);
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            PasswordTxt.Text = string.Empty;
            PwdVerifyTxt.Text = string.Empty;
        }
        public (bool,string) CheckForm(ref int tbx)
        {
            bool valid = true;
            string eMsg = string.Empty;

            if (string.IsNullOrEmpty(PasswordTxt.Text))
            {
                tbx = 0;
                valid = false;
                eMsg = Errors.GetGeneralError2(0, "Password");
            }
            else if (string.IsNullOrEmpty(PwdVerifyTxt.Text))
            {
                tbx = 1;
                valid = false;
                eMsg = Errors.GetGeneralError2(8, "your new password");
            }
            else if (PwdVerifyTxt.Text != PasswordTxt.Text)
            {
                tbx = 1;
                valid = false;
                eMsg = Errors.GetError(9);
            }

            return (valid, eMsg);
        }
        private void UsernameControls(string command)
        {
            switch (command.ToLower())
            {
                case "enable":
                    UsernameRecovPanel.Enabled = true;
                    UsernameRecovPanel.Visible = true;
                    UsernameTxt.Enabled = true;
                    UsernameTxt.Visible = true;
                    UsrLbl.Enabled = true;
                    UsrLbl.Visible = true;
                    break;
                case "disable":
                    UsernameRecovPanel.Enabled = false;
                    UsernameRecovPanel.Visible = false;
                    UsernameTxt.Enabled = false;
                    UsernameTxt.Visible = false;
                    UsrLbl.Enabled = false;
                    UsrLbl.Visible = false;
                    break;
            }
        }
        private void PasswordControls(string command)
        {
            switch (command.ToLower())
            {
                case "enable":
                    PasswordRecovPanel.Enabled = true;
                    PasswordRecovPanel.Visible = true;
                    InputLbl1.Enabled = true;
                    InputLbl1.Visible = true;
                    InputLbl2.Visible = true;
                    InputLbl2.Enabled = true;
                    PasswordTxt.Enabled = true;
                    PasswordTxt.Visible = true;
                    break;
                case "disable":
                    PasswordRecovPanel.Enabled = false;
                    PasswordRecovPanel.Visible = false;
                    InputLbl1.Enabled = false;
                    InputLbl1.Visible = false;
                    InputLbl2.Visible = false;
                    InputLbl2.Enabled = false;
                    PasswordTxt.Enabled = false;
                    PasswordTxt.Visible = false;                    
                    break;
            }
        }
        public void SetButtonLayout(string layout)
        {
            switch(layout.ToLower())
            {
                case "username":
                    // diable clear button and move it out of the way
                    ClearBtn.Enabled = false;
                    ClearBtn.Visible = false;
                    ClearBtn.Location = new Point(37, 201);
                    // move submit butn to middle of form
                    SubmitBtn.Location = new Point(222, 201);
                    break;
                case "password":
                    ClearBtn.Enabled = true;
                    ClearBtn.Visible = true;
                    ClearBtn.Location = new Point(108, 201);
                    SubmitBtn.Location = new Point(337, 201);
                    break;
            }
        }
        private void DisplaySuccess(string msg, string title)
        {
            // displays a message box with ok button and information icon used for successful actions
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateAccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if data has not been entered to db
            if (possibleDataLoss)
            {
                // if the user clicked the X btn or Alt F4
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    // closeForm is a DialogResult object it holds the value of the button selected in the messagebox
                    DialogResult closeForm = MessageBox.Show(Errors.GetError(16), appTitle,
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    // Checks to see if yes button was selected
                    if (closeForm == DialogResult.Yes)
                        RaiseGoToLogin();
                    // Check to see if no btn was selected the raise closeSelectir event
                    else if (closeForm == DialogResult.No)
                        e.Cancel = true;
                }
            }
            
        }

        private void DisplayError(string msg, string title)
        {
            // displays a message box iwth ok button and error icon used for unsuccessful actions
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void SetErrorPv(int txtBx, string emsg)
        {
            // Switch statement looks at the value of txtBx, when txtBx matches the value of a case
            // it will set the errorprovier and error message
            switch (txtBx)
            {
                case 0:
                    ErrorPv.SetError(PasswordTxt, emsg);
                    break;
                case 1:
                    ErrorPv.SetError(PwdVerifyTxt, emsg);
                    break;

            }
        }
        private void ResetErrorPv()
        {
            ErrorPv.Clear();
        }
    }
}
