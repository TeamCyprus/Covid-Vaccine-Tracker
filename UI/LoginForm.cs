using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class LoginForm : Form
    {
        (bool, string) IsValid;
        string appTitle = "Covid Tracking System";

        public LoginForm()
        {
            InitializeComponent();
        }
        private (bool,string) CheckForm(ref int Tbx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(UsernameTxt.Text))
            {
                valid = false;
                errMsg = "Enter a username";
                Tbx = 0;
            }
            else if (string.IsNullOrEmpty(PasswordTxt.Text))
            {
                valid = false;
                errMsg = "Enter a password";
                Tbx = 1;
            }

            return (valid, errMsg);
        }
        private void SetErrorPV(string emsg, int tbx)
        {
            switch(tbx)
            {
                case 0:
                    ErrorPv.SetError(UsernameTxt, emsg);
                    break;
                case 1:
                    ErrorPv.SetError(PasswordTxt, emsg);
                    break;
            }
        }
        private void ResetErrorPV()
        { ErrorPv.Clear(); }
        private void DisplaySuccess(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DisplayError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool VerifyUser(string username)
        {
            bool validUser;
            try
            {
                validUser = UserDB.VerifyUsername(username);
            }
            catch(Exception ex)
            { throw ex; }

            return validUser;
        }
        private void SetUser(User usr)
        {
            bool validUsr;

            try
            {
                usr.Username = UsernameTxt.Text;
                usr.Password = PasswordTxt.Text;
            }
            catch(Exception ex)
            { throw ex; }
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            int textBx = -1;
            bool validUser, validPwd;
            string storedPwd;           
            IsValid = CheckForm(ref textBx);
            
            if (IsValid.Item1)
            {
                try
                {
                    User ActiveUsr = new User();
                    User usr = new User();
                    SetUser(usr);
                    validUser = VerifyUser(usr.Username);

                    // if usr is found in db the verify password and get usertype
                    if (validUser)
                    {
                        storedPwd = UserDB.GetPassword(usr.Username);
                        validPwd = Protector.Compare(storedPwd, usr.Password);

                        if (validPwd)
                        {
                            ActiveUsr = UserDB.GetUserCredentials(usr.Username);

                            switch(ActiveUsr.User_Type)
                            {
                                case "Healthcare Provider":
                                    Provider provider = new Provider();
                                    provider = ProviderDB.GetProvider(ActiveUsr.Username);
                                    ProviderForm Pform = new ProviderForm(provider);
                                    Pform.ShowDialog();
                                    break;
                                case "CDC User":
                                    ViewForm CdcView = new ViewForm(true);
                                    CdcView.ShowDialog();
                                    break;
                                default:
                                    DisplayError("Error unknown user type", appTitle);
                                    break;
                            }
                            
                        }
                        else
                            DisplayError("Error invalid password", appTitle);
                    }
                    else
                        DisplayError("Error invalid username", appTitle);


                }
                catch (Exception ex)
                { DisplayError(ex.Message, appTitle); }
            }
            else
                SetErrorPV(IsValid.Item2, textBx);
        }

        private void CreateAccountLbl_Click(object sender, EventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void ForgotPwdLbl_Click(object sender, EventArgs e)
        {
            // pull new form usr must denter and verify all data
        }
    }
}
