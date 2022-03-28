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
    public partial class SignupForm : Form
    {
        string VtcksPin;
        string AppTitle = "Covid Vaccine Tracker";
        string AccountType;

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
            bool userFound = default;

            switch(usertype)
            {
                case "Provider":
                    userFound = ProviderDB.VerifyProvider("","",""); // need to pass in id, fname, lname
                    break;
                case "CDC":
                    userFound = CDCDB.VerifyCDCUser("","","","");// need to pass in id, fname, lname
                    break;
            }

            return userFound;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            // This method will add the provider or CDC user into the db
            // You need to check that all fields on form are filled out and has correct data
            // use the provider class & the providerDB class 

            // if user is found tell them that they already have an account and then use this.Close to go 
            // back to login form

            // If user not found then verify all data and then

            // Insert Username and Password and Account Type in to the Usertable with UserDB
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
