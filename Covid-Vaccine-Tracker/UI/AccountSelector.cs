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
                    break;
                case "Disable":
                    VtckPinTxt.Enabled = false;
                    VtckPinTxt.Visible = false;
                    VtckPinTxt.ReadOnly = true;
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

            // If the provider option is selected then make sure that a number is entered in the VtcksPin textbox
            // If provider then double check that the vtcks is in the system with the VtcksDB.VerifyVtck method
            // if Vtck exists in system then call the SignUpform and pass in the Account Type and VtckPin like so 
            // SignUpForm SignUp = new SignUpForm("Provider", vtcksPin); NOTE vtcksPin is an optional arguemnt to this method
            // then call the form like so SignUp.ShowDialog();

            // if CDC user selected then jsut call the sign up form like above but only pass in the account type
            // Remember vtcksPin is an optional arguemnt to the SignUp form conctructor so you do not have to pass it in
            // unless the user type is Provider
        }

        // every time a new value is picked in the combobox this method below will be called
        private void AccountCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(AccountCbx.SelectedIndex) // checks what the selected index value is
            {
                case 0: // sets the value of each flag for account type having a flag for both is kinda redundant
                    IsProvider = true;
                    IsCDC = false;
                    break;
                case 1:
                    IsProvider = false;
                    IsCDC = true;
                    break;
            }
        }
    }
}
