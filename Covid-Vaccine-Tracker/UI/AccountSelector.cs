// Account Selector form Template by Zach Palmer - Coded by Omar Arshad
///<summary>
/// This form is used by the user to select an account type
/// the two account types as of now are Provider and CDC
/// if provider account type is selected then the form prompts the user to enter a vtcks pin number 
/// that is associated with the organization the provider works for
/// if the vtcks pin does matches the user is allowed to create provider account
/// if not the user is not allowed to create a provider account
/// since data a cdc user would see is deidentified and can not be manipulated by a cdc user
/// no validation is needed for a cdc user
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
// need this using statements below to access project name spaces for the project models (business objects) &
// the data access layer
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class AccountSelector : Form
    {
        List<User_Type> types = new List<User_Type>();
        bool IsProvider, IsCDC;
        string AppTitle = "Covid Vaccine Tracker";

        // Inorder to close the signup form with event need to have a global variable for the SignUpScreen name
        SignupForm SignUp;
        // this is the method that recieves the event sent from SignUpForm to close this screen
        // and that way after exiting the signUpForm user returns to login screen

        private void HandleCloseAccountSelector(object sender, EventArgs args)
        {
            SignUp.Close();
            this.Close();
        }
        public AccountSelector()
        {
            InitializeComponent();
        }
        public void VtckInput(string command)
        {
            // VtckPin input should be displayed if account type is set to provider 
            switch(command)
            {
                case "Enable":
                    VtckPinTxt.Enabled = true;
                    VtckPinTxt.Visible = true;
                    VtckPinTxt.ReadOnly = false;
                    vtckLbl.Enabled = true;
                    vtckLbl.Visible = true;
                    break;
                case "Disable":
                    VtckPinTxt.Enabled = false;
                    VtckPinTxt.Visible = false;
                    VtckPinTxt.ReadOnly = true;
                    vtckLbl.Enabled = false;
                    vtckLbl.Visible = false;
                    break;
            }
        }

        private void AccountSelector_Load(object sender, EventArgs e)
        {
            // During load event populate list with values form db then bind to the combobox
            types = User_TypesDB.GetUserTypes();
            AccountCbx.DataSource = types;
            AccountCbx.DisplayMember = "UserType";
            AccountCbx.ValueMember = "Id";
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            // Make sure that the selected index on combobox is not -1 when the Next button is clicked

            // If the provider option is selected then verify a vtcks pin  is entered in the VtcksPin textbox

            // If provider account type then double check that the vtcks is in the system with the VtcksDB.VerifyVtck method

           if (IsCDC)
            {
                // use the global variable for signupform
                SignUp = new SignupForm("CDC");
                // adds event handler so when signup form is closed it will send event
                // to this form then both forms will close so login screen is active form
                SignUp.CloseAccountSelector += HandleCloseAccountSelector;
                SignUp.Show();
                SignUp.TopMost = true;
                this.Close();
            }
           else if (IsProvider)
            {
                string enteredVtck = VtckPinTxt.Text;
                bool vtckExists = VtcksDB.VerifyProviderAccess(enteredVtck);
                bool accountExists = VtcksDB.VerifyVtck(enteredVtck);
                if (vtckExists && !accountExists)
                {
                    // use the global variable for signupform
                    SignUp = new SignupForm("Provider", enteredVtck);
                    // adds event handler so when signup form is closed it will send event
                    // to this form then both forms will close so login screen is active form
                    SignUp.CloseAccountSelector += HandleCloseAccountSelector;
                    SignUp.Show();
                    SignUp.TopMost = true;
                    this.Close();
                }
                else if (!vtckExists)
                    DisplayError(Errors.GetGeneralError(12, "Vtcks Pin"), AppTitle);
                else if (accountExists)
                    DisplayError(Errors.GetGeneralError(7, "Vtcks Pin"), AppTitle);
            }


            // if Vtck exists in system then call the SignUpform and pass in the Account Type and VtckPin like so 
            // SignUpForm SignUp = new SignUpForm("Provider", vtcksPin); NOTE vtcksPin is an optional arguemnt to this method
            // then call the form like so SignUp.ShowDialog();

            // if CDC user selected then jsut call the sign up form like above but only pass in the account type
            // Remember vtcksPin is an optional arguemnt to the SignUp form conctructor so you do not have to pass it in
            // unless the user type is Provider
            // still use SignUpForm SignUp = new SignUpForm();
            // SignUp.ShowDialog()  only pass in "CDC" as a string for cdc user types
        }

        // every time a new value is picked in the combobox this method below will be called
        private void AccountCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(AccountCbx.SelectedIndex) // checks what the selected index value is
            {
                case 0: // sets the value of each flag for account type having a flag for both is kinda redundant
                    IsProvider = true;
                    IsCDC = false;
                    VtckInput("Enable");
                    break;
                case 1:
                    IsProvider = false;
                    IsCDC = true;
                    VtckInput("Disable");
                    break;
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
    }
}
