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
        string appTitle = "Covid Vaccine Trackdr";
        List<User_Type> accountTypes = new List<User_Type>();
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
                AccountCbx.DisplayMember = "User_Type";
                AccountCbx.ValueMember = "Id";

                //detemine if they are trying to get the username or password

                // if password recovery set InputLbl1 and InputLbl2 text with the InputLbl1.Text = "Username" ..etc

                // if username recovery set InputLbl and InputLbl2 text with the InputLbl2.Text = "Firt Name" ..etc
            } catch(Exception ex)
            {
                throw ex;
            }

        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // clear labels
            InputLbl1.Text = string.Empty;
            InputLbl2.Text = string.Empty;
            // clear text boxs
            InputTxt1.Text = string.Empty;
            InputTxt2.Text = string.Empty;
            AccountCbx.SelectedIndex = -1;
            // give input1Txt focus
            InputTxt1.Focus();
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            // Sergio's section
            // when the user submits check the recovery type
            if (passwordRecovery)
            {
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

                // if the first name last name and anwser match then call the
                // UpdateAccountForm  and pass in the first name last name

                // if anwser does not match display error message with DisplayError and use the new Errors class
                // you might have to look up the specific message code but a example of the new way to get error messages and
                // display through a DisplayErorrMethod would be :
                // DisplayError(Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id"), AppTitle);
                // Errors.GetGeneralErrorMsg(33, "Patient", "Patient Id") returns a string with Patient and Patient Id inserted into string
            }
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
        public (bool,string) CheckForm(ref int tbx)
        {
            // add the validation for your story here see provider form UpdateAccountForm and login form for example of checkform method
            // note that i started implementing the new error messages in the provider and started on the login form
            throw new NotImplementedException();
        }
    }
}
