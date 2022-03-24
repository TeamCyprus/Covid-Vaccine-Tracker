using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Need these to access namespace with this projects data models (Business Objects) & DataAccess layer
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;

namespace Covid_Vaccine_Tracker.UI
{
    // Form needs to use ID generator class to generate id for provider to be stored in db see ProviderForm for example
    public partial class SignupForm : Form
    {
        string VtcksPin;
        string AppTitle = "Covid Vaccine Tracker";
        string AccountType;
        string GeneratedProviderId;

        // List to hold combo box values
        List<States> daStates = new List<States>();
        List<Provider_Suffix> suffixes = new List<Provider_Suffix>();

        public SignupForm()
        {
            InitializeComponent();
        }
        // Use the method that has Vtcks pin passed in from Account Selection Form only if provider usertype
        public SignupForm(string accountType, string vtckPin= "none") // vtcksPin is an optional arg
        {
            InitializeComponent();
            // Set global VtcksPin and AccountType
            if (vtckPin != "none")
                VtcksPin = vtckPin;
            AccountType = accountType;
        }
        public bool VerifyUserStatus(string usertype)
        {
            // new user type obj should be set at this point
            bool userFound = false;
            string vtck = string.Empty;
            string firstname = FnameTxt.Text.Trim();
            string lastname = LnameTxt.Text.Trim();

            switch (usertype)
            {
                case "Provider":
                    // check that the vtck pin and providers first & last name do not exist in DB
                    // need to pull the id and first name and last name from the form to verify provider
                    vtck = VtckPinTxt.Text.Trim();
                    userFound = ProviderDB.VerifyProvider(vtck, firstname,lastname); // need to pass in id, fname, lname
                    break;
                case "CDC":
                    // same as above but for a cdc user just verify the first and last name do not exist
                    userFound = CDCDB.VerifyCDCUser(firstname,lastname);// need to pass in id, fname, lname
                    break;
            }

            return userFound;
        }
        private string GenerateId()
        {
            bool IdExist = true;
            string newID = string.Empty;

            do
            {
                // Generate a random string 10 chars long with with 4 letters use digits 0-9 and letter A-Z
                GeneratedProviderId = IdGenerator.GenerateId(10, 3, 0, 9, 'A', 'Z');
                // Check that id does not exist already
                IdExist = PatientDB.CheckPatientId(GeneratedProviderId);

            }
            while (IdExist);

            return newID;
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
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // This method will add the provider or CDC user into the db
            // You need to check that all fields on form are filled out and has correct data
            // use the provider class & the providerDB class 

            // if user is found tell them that they already have an account and then use this.Close to go 
            // back to login form

            // Use VerifyUserStatus to make sure user does not already exist
            // if patient exist then display message saying so can use display success or display error method

            // if patient does not exist in DB already then use GenerateID method to create a new id
            // Note** GenerateID returns a string so set the global variable GeneratedProviderID and set it to the methods return val


            // If user not found then verify all data and then

            // Insert Username and Password and Account Type in to the Usertable with UserDB
            // user UserDB.AddUser valid account types are "Provider" and "CDC" they need to be passed in as strings to the DB Crud methods


            // and then Insert the the rest of information on form in to the Provider or CDC table 
            // then use this.Close to exit to go back to the login form
            

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // This method clears out the form
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // closeForm is a DialogResult object it holds the value of the button selected in the messagebox
            DialogResult closeForm = MessageBox.Show("Do You wish to close the entire application?", AppTitle,
             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            // Checks to see if yes button was selected
            if (closeForm == DialogResult.Yes)
                Application.Exit();
            // Check to see if no btn was selected
            else if (closeForm == DialogResult.No)
                this.Close();
            // Dont need to check if cancel was selected because not closing app or not closing form
            // is what cancel should do
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
            // Set the Vtcks textbox to pin that was passed in
            VtckPinTxt.Text = VtcksPin;

            // get vlaues from db then bind to combo boxs
            daStates = StatesDB.GetStates();
            StateCbx.DataSource = daStates;
            StateCbx.DisplayMember = "Name";
            StateCbx.ValueMember = "Abbreviation";

            suffixes = Provider_SuffixDB.GetSuffixes();
            ProviderSuffixCBX.DataSource = suffixes;
            ProviderSuffixCBX.DisplayMember = "Suffix";
            ProviderSuffixCBX.ValueMember = "Code";
        }
    }
}
