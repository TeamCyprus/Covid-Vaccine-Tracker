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
        List<User_Type> accountTypes = new List<User_Type>();
        List<SecurityAnwser> userSecAnswers = new List<SecurityAnwser>();
        SecurityAnwser userAnswer;
        User user = new User();
        UpdateAccountForm resetPWForm;
        (bool, string) IsValid;
        private bool usernameRecovery = false, passwordRecovery = false;
        private bool errorOccurred = default;
        private bool isSecondPanel = false;
        string appTitle = "Covid Vaccine Tracker";

        private void HandleCloseRecoveryForm(object sender, EventArgs args)
        {
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
                    //Disable "password" textbox
                    InputLbl2.Enabled = false;
                    InputLbl2.Visible = false;
                    InputTxt2.Enabled = false;
                    InputTxt2.Visible = false;
                    //Re-adjust the AccountCbx and panel1
                    AccountLbl.Top -= 75;
                    AccountCbx.Top -= 75;
                    panel1.Height -= 75;
                    ClearBtn.Top -= 173;
                    SubmitBtn.Top -= 173;
                    this.Height -= 173;
                    //Disable the security question group box
                    groupBox1.Enabled = false;
                    groupBox1.Visible = false;
                }
                // if username recovery set InputLbl and InputLbl2 text with the InputLbl2.Text = "Firt Name" ..etc
            } catch(Exception ex)
            {
                throw ex;
            }

        }
        public (bool, string) CheckForm(ref int tbx)
        {
            // add the validation for your story here see provider form UpdateAccountForm and login form for example of checkform method
            // note that i started implementing the new error messages in the provider and started on the login form
            bool valid = true;
            string errMsg = string.Empty;
            if(!isSecondPanel)
            {
                if (string.IsNullOrEmpty(InputTxt1.Text))
                {
                    valid = false;
                    errMsg = Errors.GetInputErrorMsg(0, "Username");
                    tbx = 0;
                }
                else if (AccountCbx.SelectedIndex <= -1)
                {
                    valid = false;
                    errMsg = Errors.GetInputErrorMsg(11, "Account type");
                    tbx = 1;
                }
            } else
            {
                if (string.IsNullOrEmpty(AnwserTxt.Text))
                {
                    valid = false;
                    errMsg = Errors.GetInputErrorMsg(0, " response");
                    tbx = 2;
                }
            }
            return (valid, errMsg);
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // clear labels
            InputLbl2.Text = string.Empty;
            // clear text boxs
            InputTxt1.Text = string.Empty;
            InputTxt2.Text = string.Empty;
            AccountCbx.SelectedIndex = -1;
            AnwserTxt.Text = string.Empty;
            AnwserLbl.Text = "Your answer";  
            // give input1Txt focus
            InputTxt1.Focus();
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            //Resets the flag and error provider
            errorOccurred = false;
            ResetErrorPv();
            int Tbx = -1;
            bool validAns;
            //Checks that the form is filled in...
            IsValid = CheckForm(ref Tbx);
            //Checks if the program is in the user info panel or security question panel
            if (!isSecondPanel)
            {
                string id;
                // when the user submits check the recovery type
                if (passwordRecovery && !usernameRecovery)
                {
                    if (IsValid.Item1)
                    {
                        try
                        {
                            //Create an object based on what the user is
                            if (accountTypes[AccountCbx.SelectedIndex].UserType == "CDC User")
                                CreateUser("CDC");
                            else if (accountTypes[AccountCbx.SelectedIndex].UserType == "Healthcare Provider")
                                CreateUser("Provider");
                            if (!errorOccurred)
                            {
                                //Verifies that the username exists in the database
                                if (VerifyUsername())
                                {
                                    //Gets ID from the database based on what the user is (CDC/Provider)
                                    id = GetUserId(user);
                                    try
                                    {
                                        //Gets security question(s) and answer(s) from the database linked to the user based on user ID
                                        userSecAnswers = SecurityQuestionDB.GetUserSecurityQuestions(id);
                                        userAnswer = userSecAnswers[0];
                                        //Presets the question and hides current panel; shows security question group box
                                        AnwserLbl.Text = userAnswer.Question;
                                        SwitchPanels();
                                    }
                                    catch (Exception ex) { DisplayError("Question doesn't exist", appTitle); AnwserLbl.Text = "Your answer"; }
                                }
                                else
                                {
                                    DisplayError("We couldn't find that username", appTitle);
                                    AnwserLbl.Text = "Your answer";
                                }
                            }
                        }
                        catch (Exception ex) { DisplayError(ex.Message, appTitle); }
                    }
                    else SetErrorPv(Tbx, IsValid.Item2);
                }
                // Amar's section
                if (usernameRecovery)
                {
                    // check the provider table and the cdc table for the first name and last name amd account type
                    // and then check that the anwser matches 

                    // if the first name last name and anwser match then call the
                    // UpdateAccountForm  and pass in the first name last name

                    // if anwser does not match display error message with DisplayError and use the new Errors class
                    // you might have to look up the specific message code but a example of the new way to get error messages and
                    // display through a DisplayErorrMethod would be :
                    // DisplayError(Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id"), AppTitle);
                    // Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id") returns a string with Patient and Patient Id inserted into string
                }
            } 
            //If program is on the security question panel
            else if(isSecondPanel)
            {
                if(IsValid.Item1)
                {
                    //Compares user's answer with that of the database's
                    validAns = Protector.Compare(userAnswer.Anwser, AnwserTxt.Text);
                    if (validAns)
                    {
                        //If correct, calls the UpdateAccountForm with username passed as a parameter
                        resetPWForm = new UpdateAccountForm(user.Username);
                        resetPWForm.CloseRecoveryForm += HandleCloseRecoveryForm;
                        resetPWForm.ShowDialog();
                    }
                    else DisplayError("That answer is incorrect.", appTitle);
                } 
                else SetErrorPv(Tbx, IsValid.Item2);
            }
        }
        private void SwitchPanels()
        {
            //Set flag and toggle panels
            isSecondPanel = true;
            panel1.Enabled = false;
            panel1.Visible = false;
            SubmitBtn.Text = "Submit";
            groupBox1.Enabled = true;
            groupBox1.Visible = true;
            groupBox1.Top = 26;
            ClearBtn.Enabled = false;
            ClearBtn.Visible = false;
            SubmitBtn.Left = 162;
        }
        private void CreateUser(string type)
        {
            try
            {
                //Sets User object depending on user type. 
                //This object holds Username and Account Type.
                //Account type determines from which table to get ID from in database.
                user.Username = InputTxt1.Text.Trim();
                switch (type)
                {
                    case "CDC":
                        user.user_type = "CDC";
                        break;
                    case "Provider":
                        user.user_type = "Provider";
                        break;
                }
            } catch(Exception ex)
            {
                errorOccurred = true;
                throw ex;
            }
        }
        private string GetUserId(User user)
        {
            string returnedId = string.Empty;
            //UserType helps determine what method to use for getting the ID
            try
            {
                if (user.user_type == "CDC")
                    returnedId = UserDB.GetUserId_Cdc(user.Username);
                else if (user.user_type == "Provider")
                    returnedId = UserDB.GetUserId_Provider(user.Username);
            }
            catch(Exception ex) { DisplayError("We couldn't find that user.", appTitle); }
            return returnedId;
        }
        private bool VerifyUsername()
        {
            bool usernameFound = default;
            string username = user.username;
            //Checks the username in the database
            try
            {
                usernameFound = UserDB.VerifyUsername(username);
            } catch(Exception ex) { DisplayError(ex.Message, appTitle); }
            return usernameFound;
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
                case 2:
                    ErrorPv.SetError(AnwserTxt, emsg);
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
    }
}
