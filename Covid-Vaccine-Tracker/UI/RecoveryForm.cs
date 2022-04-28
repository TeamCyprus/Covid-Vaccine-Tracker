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
        string appTitle = "Covid Vaccine Tracker", id;
        List<User_Type> accountTypes = new List<User_Type>();
        // add event to form class
        UsernameForm userForm;
        List<SecurityAnwser> userSecAnswers = new List<SecurityAnwser>();
        SecurityAnwser userAnswer;
        User user = new User();
        UpdateAccountForm resetPWForm;
        private bool errorOccurred = default;
        private bool isSecondPanel = false;
        bool possibleDataLoss = false;

        // event handler for closeing this and username form
        private void HandleGoToPrevForm(object sender, EventArgs args)
        {
            this.Close();
        }
        // event handler for clsing this form and updateAccount form
        private void HandleGoToLogin(object sender, EventArgs args)
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
                    AnswerTxt.Enabled = false;
                    AnswerTxt.Visible = false;
                }
                else if(usernameRecovery && !passwordRecovery)
                {
                    InputLbl1.Text = "First Name";
                    InputLbl2.Text = "Last Name";
                    ClearBtn.Top -= 98;
                    SubmitBtn.Top -= 98;
                    this.Height -= 98;
                    groupBox1.Enabled = false;
                    groupBox1.Visible = false;
                    AnswerTxt.Enabled = false;
                    AnswerTxt.Visible = false;
                }
                // if username recovery set InputLbl and InputLbl2 text with the InputLbl2.Text = "Firt Name" ..etc
            } catch(Exception ex)
            {
               DisplayError(ex.Message,appTitle);
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
            AnswerTxt.Text = string.Empty;
            // give input1Txt focus
            InputTxt1.Focus();
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            errorOccurred = false;
            ResetErrorPv();
            int Tbx = -1;
            IsValid = CheckForm(ref Tbx);
            bool validAns;
            string username = string.Empty;
            string fname, lname, anwser;
            //Checks that the form is filled in...
            // when the user submits check the recovery type
            if (!isSecondPanel)
            {
                // when the user submits check the recovery type
                // Coded by Sergio
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
                                        AnswerLbl.Text = userAnswer.Question;
                                        SwitchPanels();
                                    }
                                    catch (Exception ex)
                                    {
                                        DisplayError(Errors.GetError(23), appTitle);
                                        AnswerLbl.Text = "Your answer";
                                    }
                                }
                                else
                                {
                                    DisplayError(Errors.GetError(18), appTitle);
                                    AnswerLbl.Text = "Your answer";
                                }
                            }
                        }
                        catch (Exception ex) 
                        { DisplayError(ex.Message, appTitle); }
                    }
                    else SetErrorPv(Tbx, IsValid.Item2);
                }
                // Coded by Amar. Modified by Sergio
                else if (usernameRecovery && !passwordRecovery)
                {
                    if(IsValid.Item1)
                    {
                        // check the provider table and the cdc table for the first name and last name amd account type
                        // and then check that the answer matches 
                        try
                        {
                            fname = InputTxt1.Text.Trim();
                            lname = InputTxt2.Text.Trim();
                            //Retrieve Provider/CDC ID based on first and last name
                            id = GetUserId(accountTypes[AccountCbx.SelectedIndex].UserType, fname, lname);
                            try
                            {
                                //Gets security question(s) and answer(s) from the database linked to the user based on user ID
                                userSecAnswers = SecurityQuestionDB.GetUserSecurityQuestions(id);
                                userAnswer = userSecAnswers[0];
                                //Presets the question and hides current panel; shows security question group box
                                AnswerLbl.Text = userAnswer.Question;
                                SwitchPanels();
                            }
                            catch (Exception ex)
                            {
                                DisplayError(Errors.GetError(23), appTitle);
                                AnswerLbl.Text = "Your answer";
                            }
                        }
                        catch (Exception ex) { DisplayError(ex.Message, appTitle); }
                    }
                    else SetErrorPv(Tbx, IsValid.Item2);
                }
            }
            //If program is on the security question panel
            else if (isSecondPanel)
            {
                if(passwordRecovery)
                {
                    if (IsValid.Item1)
                    {
                        //Compares user's answer with that of the database's
                        validAns = Protector.Compare(userAnswer.Anwser, AnswerTxt.Text);
                        if (validAns)
                        {
                            //If correct, calls the UpdateAccountForm with username passed as a parameter
                            resetPWForm = new UpdateAccountForm(user.Username);
                            resetPWForm.GoToLogin += HandleGoToLogin;
                            this.Hide();
                            resetPWForm.ShowDialog();
                            this.Show();
                        }
                        else DisplayError("That answer is incorrect.", appTitle);
                    }
                    else SetErrorPv(Tbx, IsValid.Item2);
                }
                else if(usernameRecovery)
                {
                    bool correctAnwser;
                    if (IsValid.Item1)
                    {
                        string account = accountTypes[AccountCbx.SelectedIndex].UserType;
                        //Encrypt answer
                        anwser = Protector.Encryptor(AnswerTxt.Text);
                        //Checks if user's answer is correct
                        correctAnwser = SecurityQuestionDB.CheckSecurityQuestion(id, anwser);
                        // if userid and anwser matcheed
                        if (correctAnwser)
                        {
                            switch (account.ToLower())
                            {
                                case "healthcare provider":
                                    username = UserDB.GetUsername_ProviderId(id);
                                    break;
                                case "cdc user":
                                    username = UserDB.GetUsername_CdcId(id);
                                    break;
                            }
                            userForm = new UsernameForm(username);
                            userForm.GoToPrevForm += HandleGoToPrevForm;
                            this.Hide();
                            userForm.ShowDialog();
                            this.Show();
                        }
                        else if (!correctAnwser)
                            DisplayError(Errors.GetError(21), appTitle);
                    }
                    else SetErrorPv(Tbx, IsValid.Item2);
                }
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
            AnswerTxt.Enabled = true;
            AnswerTxt.Visible = true;
            AnswerTxt.Focus();
            if(usernameRecovery)
            {
                SubmitBtn.Top -= 65;
                this.Height -= 65;
            }
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
            }
            catch (Exception ex)
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
            catch (Exception ex) { DisplayError("We couldn't find that user.", appTitle); }
            return returnedId;
        }
        private string GetUserId(string type, string fname, string lname)
        {
            //Overloaded method that gets ID by first and last name
            string returnedId = string.Empty;
            //type helps determine what method to use for getting the ID
            try
            {
                if (type == "Healthcare Provider")
                    returnedId = UserDB.RecoverProviderUserId(fname, lname);
                else if (type == "CDC User")
                    returnedId = UserDB.RecoverCDCUserId(fname, lname);
            }
            catch (Exception ex) { DisplayError("We couldn't find that user.", appTitle); }
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
            }
            catch (Exception ex) { DisplayError(ex.Message, appTitle); }
            return usernameFound;
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
                case 2:
                    ErrorPv.SetError(AnswerTxt, emsg);
                    break;
                case 3:
                    ErrorPv.SetError(InputTxt2, emsg);
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

        private void RecoveryForm_FormClosing(object sender, FormClosingEventArgs e)
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
                        this.Close();
                    // Check to see if no btn was selected the raise closeSelectir event
                    else if (closeForm == DialogResult.No)
                        e.Cancel = true;
                    // after they are told reset the flag
                    possibleDataLoss = false;
                }
            }
        }

        public (bool,string) CheckForm(ref int tbx)
        {
            bool valid = true;
            string errMsg = string.Empty;
            //while on first panel
            if(!isSecondPanel)
            {
                //if it's the PwdReset panel
                if(passwordRecovery && !usernameRecovery)
                {
                    if (string.IsNullOrEmpty(InputTxt1.Text))
                    {
                        valid = false;
                        errMsg = Errors.GetGeneralError2(0, "Username");
                        tbx = 0;
                    }
                    else if (AccountCbx.SelectedIndex <= -1)
                    {
                        valid = false;
                        errMsg = Errors.GetGeneralError2(2, "Account type");
                        tbx = 1;
                    }
                }
                //if it's the usernameRecovery panel
                else if(usernameRecovery && !passwordRecovery) 
                {
                    if (string.IsNullOrEmpty(InputTxt1.Text))
                    {
                        valid = false;
                        errMsg = Errors.GetGeneralError2(0, "First Name");
                        tbx = 0;
                    }
                    else if (string.IsNullOrEmpty(InputTxt2.Text))
                    {
                        valid = false;
                        errMsg = Errors.GetGeneralError2(0, "Last Name");
                        tbx = 3;
                    }
                    else if (AccountCbx.SelectedIndex <= -1)
                    {
                        valid = false;
                        errMsg = Errors.GetGeneralError2(2, "Account type");
                        tbx = 1;
                    }
                }
 
            }
            //if it's the security questions panel
            else
            {
                if (string.IsNullOrEmpty(AnswerTxt.Text))
                {
                    valid = false;
                    errMsg = Errors.GetGeneralError2(0, " response");
                    tbx = 2;
                }
            }
            return (valid, errMsg);
        }
    }
}