// Login Form by Zach Palmer & Ryan Gerhardt
///<summary>
/// This form is the begining point of finished app
/// A user either logs in with their existing credentials or
/// a user creates an account passwords are encrypted using a Sha Hash function and salt then stored in database
/// </summary>

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
        // Check that username and password were entered
        private (bool,string) CheckForm(ref int Tbx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(UsernameTxt.Text))
            {
                valid = false;
                errMsg = Errors.GetGeneralError2(0, "username.");
                Tbx = 0;
            }
            else if (string.IsNullOrEmpty(PasswordTxt.Text))
            {
                valid = false;
                errMsg = Errors.GetGeneralError2(0, "password.");
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
        // Method that verifys that the username exists 
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
            // Check that form has been filled
            IsValid = CheckForm(ref textBx);
            
            if (IsValid.Item1) // If form has been filled then..
            {
                try
                {
                    // Create an activeUser and usr 
                    User ActiveUsr = new User();
                    User usr = new User();
                    // Set the credentails that were entered in usr obj
                    SetUser(usr);
                    // Verify that the user exists in the db
                    validUser = VerifyUser(usr.Username);

                    // if usr is found in db the verify password and get usertype
                    if (validUser)
                    {
                        // Get the stored pwd for that user
                        storedPwd = UserDB.GetPassword(usr.Username);
                        int storedPwdLen = storedPwd.Length;
                        // verify that the entered pwd and stored pwd are the same the entered pwd is 
                        // passed into the method then encrypted and compared
                        validPwd = Protector.Compare(storedPwd, usr.Password);

                        if (validPwd)
                        {
                            // Set the active user to the credentails returned *note is kind of redundant
                            ActiveUsr = UserDB.GetUserCredentials(usr.Username);

                            // Now check the user type and call the correct form
                            switch(ActiveUsr.User_Type)
                            {
                                case "Provider":
                                    Provider provider = new Provider();
                                    provider = ProviderDB.GetProvider(ActiveUsr.Username);
                                    ProviderForm Pform = new ProviderForm(provider);
                                    Pform.ShowDialog();
                                    break;
                                case "CDC":
                                    //CDC cdc = new CDC();
                                    //cdc = CDCDB.GetCDCUser(ActiveUsr.Username);
                                    ViewForm CdcView = new ViewForm(true);
                                    CdcView.ShowDialog();
                                    break;
                                default:
                                    DisplayError(Errors.GetGeneralError2(1, "user type"), appTitle);
                                    break;
                            }
                            
                        }
                        else
                            DisplayError(Errors.GetError(10), appTitle);
                    }
                    else
                        DisplayError(Errors.GetError(18), appTitle);


                }
                catch (Exception ex)
                { DisplayError(ex.Message, appTitle); }
            }
            else
                SetErrorPV(IsValid.Item2, textBx);
        }

        private void CreateAccountLbl_Click(object sender, EventArgs e)
        {
            AccountSelector selector = new AccountSelector();
            this.Hide();
            selector.ShowDialog();
            this.Show();
        }

        private void ForgotPwdLbl_Click(object sender, EventArgs e)
        {
            // user is trying to recover password so pass in "Password"
            RecoveryForm Rform = new RecoveryForm("Password");
            this.Hide();
            Rform.ShowDialog();
            this.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // displays the splash screen .. splash screen is set on a timer then will close
            //SplashForm splash = new SplashForm();
            //this.Hide();
            //splash.ShowDialog();
            //this.Show();
        }

        private void UsrRecoverBtn_Click(object sender, EventArgs e)
        {
            // user is trying to recover their username so pass "Username" into constructor
            RecoveryForm Rform = new RecoveryForm("Username");
            this.Hide();
            Rform.ShowDialog();
            this.Show();
        }
    }
}
