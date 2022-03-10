// Login Form by Zach Palmer & Ryan G
///<summary>
/// This form is the begining point of finished app
/// A user either logs in with their existing credentials or
/// a user creates an account passwords are encrypted then stored in database
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
            // this event needs the sign up form to be called
        }

        private void ForgotPwdLbl_Click(object sender, EventArgs e)
        {
            // account recovery form needs to be called not sure if we are putting this in the current sprint
        }
    }
}
