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
    public partial class RecoveryForm : Form
    {
        bool usernameRecovery = false, passwordRecovery = false;
        (bool, string) IsValid;
        string appTitle = "Covid Vaccine Tracker";
        List<User_Type> accountTypes = new List<User_Type>();
        // add event to form class
        UsernameForm userForm;
        
       // event handler method
       private void HandleCloseBothForms(object sender, EventArgs args)
        {
            userForm.Close();
            this.Close();
        }
        public RecoveryForm()
        {
            InitializeComponent();
        }

        // overloaded constructor to set which type of account recovery story
        // the LoginForm calls this constructor and passes either true or false in and then the code below on line 23 excecutes then
        // the load event executes
        public RecoveryForm(string recoveryType)
        {
            InitializeComponent();
            // make sure every letter is lowercase
            string recoveryMy = recoveryType.ToLower();

            // determine what the user is trying to recover then set flag
            switch(recoveryMy)
            {
                case "username":
                    usernameRecovery = true;
                    break;
                case "password":
                    passwordRecovery = true;
                    break;
            }
        }
        private void RecoveryForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                // load the account options combo box
                accountTypes = User_TypesDB.GetUserTypes();
                AccountCbx.DataSource = accountTypes;
                AccountCbx.DisplayMember = "UserType";
                AccountCbx.ValueMember = "Id";

                //detemine if they are trying to get the username or password

                // if password recovery set InputLbl1 and InputLbl2 text with the InputLbl1.Text = "Username" ..etc
                if(passwordRecovery && !usernameRecovery)
                {
                    InputLbl1.Text = "Username";
                    InputLbl2.Enabled = false;
                    InputLbl2.Visible = false;
                    InputTxt2.Enabled = false;
                    InputTxt2.Visible = false;
                    AccountLbl.Top -= 75;
                    AccountCbx.Top -= 75;
                    panel1.Height -= 75;
                    groupBox1.Top -= 75;
                    ClearBtn.Top -= 75;
                    SubmitBtn.Top -= 75;
                    this.Height -= 75;
                    AnwserTxt.Enabled = false;
                }

                // if username recovery set InputLbl and InputLbl2 text with the InputLbl2.Text = "Firt Name" ..etc
            } catch(Exception ex)
            {
                throw ex;
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // clear labels
            //InputLbl1.Text = string.Empty;
            InputLbl2.Text = string.Empty;
            // clear text boxs
            InputTxt1.Text = string.Empty;
            InputTxt2.Text = string.Empty;
            AccountCbx.SelectedIndex = -1;
            AnwserTxt.Text = string.Empty;
            // give input1Txt focus
            InputTxt1.Focus();
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            ResetErrorPv();
            // Sergio's section
            // when the user submits check the recovery type
            if (passwordRecovery)
            {
                int Tbx = -1;
                IsValid = CheckForm(ref Tbx);
                if (IsValid.Item1)
                {
                    AnwserTxt.Enabled = true;
                }
                else
                    SetErrorPv(Tbx, IsValid.Item2);
                // use UserDB to check that the username is in the database and get the user id associated with username
                // then use the id to get the question from the database using one of the SecurityQuestionDB class methods 

                // if the anwser matches then call the UpdateAccountForm and pass in the username

                // if anwser dont match display error message with DisplayError and use the new Errors class
                // you might have to look up the specific message code but a example of the new way to get error messages and
                // display through a DisplayErorrMethod would be :
                // DisplayError(Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id"), AppTitle);
                // Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id") returns a string with Patient and Patient Id inserted into string


            }
            // Amar's section
            if (usernameRecovery)
            {

                // check the provider table and the cdc table for the first name and last name amd account type
                // and then check that the anwser matches 
                bool correctAnwser;
                string userId = string.Empty;
                string username = string.Empty;
                string fname, lname, anwser;
                string account = accountTypes[AccountCbx.SelectedIndex].UserType;
                try
                {
                    fname = InputTxt1.Text.Trim();
                    lname = InputTxt2.Text.Trim();
                    anwser = AnwserTxt.Text.Trim();

                    switch (account.ToLower())
                    {
                        case "provider":
                            userId = UserDB.RecoverProviderUserId(fname, lname);
                            break;
                        case "cdc":
                            userId = UserDB.RecoverCDCUserId(fname, lname);
                            break;
                    }

                    // check database for user id with matching anwser
                    correctAnwser = SecurityQuestionDB.CheckSecurityQuestion(userId, anwser);

                    // if userid and anwser matcheed
                    if (correctAnwser)
                    {
                        switch(account.ToLower())
                        {
                            case "provider":
                                username = UserDB.GetUsername_ProviderId(userId);
                                break;
                            case "cdc":
                                username = UserDB.GetUsername_CdcId(userId);
                                break;
                        }

                        userForm = new UsernameForm(username);
                        userForm.CloseBothForms += HandleCloseBothForms;
                        userForm.ShowDialog();
                    }
                    else if (!correctAnwser)
                    { 
                        DisplayError(Errors.GetError(21), appTitle);
                    }
                }
                catch(Exception ex)
                { DisplayError(ex.Message, appTitle); }
                // if the first name last name and anwser match then call the
                // UpdateAccountForm  and pass in the first name last name

                // if anwser does not match display error message with DisplayError and use the new Errors class
                // you might have to look up the specific message code but a example of the new way to get error messages and
                // display through a DisplayErorrMethod would be :
                // DisplayError(Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id"), AppTitle);
                // Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id") returns a string with Patient and Patient Id inserted into string
            }
        }
        private void DisplayUsername(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void SetErrorPv(int tbx, string emsg)
        {
            switch(tbx)
            {
                case 0:
                    ErrorPv.SetError(InputTxt1, emsg);
                    break;
                case 1:
                    ErrorPv.SetError(AccountCbx, emsg);
                    break;
            }
        }
        private void ResetErrorPv()
        {
            // clears the current positionn of ErrorProvider if any
            ErrorPv.Clear();
        }
        private void DisplaySuccess(string msg, string title)
        {
            // displays a message box with ok button and information icon used for successful actions
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void DisplayError(string msg, string title)
        {
            // displays a message box iwth ok button and error icon used for unsuccessful actions
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //private void InputTxt1_Leave(object sender, EventArgs e)
        //{
        //    //check if username exists. If yes, gets the security question, if not, displays an error. 
        //    string username = InputTxt1.Text.Trim();
        //    bool usernameFound = UserDB.VerifyUsername(username);
        //    if(usernameFound)
        //    {
        //        //if username is found, retrieve the user's security question and update the sec ? label

        //    }
        //}

        public (bool,string) CheckForm(ref int tbx)
        {
            // add the validation for your story here see provider form UpdateAccountForm and login form for example of checkform method
            // note that i started implementing the new error messages in the provider and started on the login form
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(InputTxt1.Text))
            {
                valid = false;
                errMsg = Errors.GetGeneralError2(0, "Username");
                tbx = 0;
            }
            else if (AccountCbx.SelectedIndex <=-1)
            {
                valid = false;
                errMsg = Errors.GetGeneralError2(2, "Account type");
                tbx = 1;
            }

            return (valid, errMsg);
        }
    }
}
