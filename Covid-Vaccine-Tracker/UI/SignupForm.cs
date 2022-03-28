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
        string GenerateProviderOrCdcId;
        string encryptedPW;
        (bool, string) isValid;
        bool ErrorOccured;
        Provider NewProvider = new Provider();
        CDC NewCDCuser = new CDC();
        User newUser = new User();

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
            isCDC();
            GenerateId();
        }

        private void isCDC()
        {
            //disables groupbox2, provider suffix, and vtcks pin textboxes if its CDC user.
            if(AccountType == "CDC")
            {
                DisableFacilityControls();
                groupBox2.Enabled = false;
                groupBox2.Visible = false;
                VtckPinTxt.Enabled = false;
                ProviderSuffixCBX.Enabled = false;
                Size = new Size(719, 255);
            }
        }
        private void DisableFacilityControls()
        {
            try
            {
                OrganizationTxt.Enabled = false;
                OrganizationTxt.Visible = false;
                FacilityTxt.Enabled = false;
                FacilityTxt.Visible = false;
                LocationTypeTxt.Enabled = false;
                LocationTypeTxt.Visible = false;
                StreetAddressTxt.Enabled = false;
                StreetAddressTxt.Visible = false;
                CityTxt.Enabled = false;
                CityTxt.Visible = false;
                CountyTxt.Enabled = false;
                CountyTxt.Visible = false;
                StateCbx.Enabled = false;
                StateCbx.Visible = false;
                ZipTxt.Enabled = false;
                ZipTxt.Visible = false;
            }
            catch(Exception ex)
            { throw ex; }
        }
        //checks if user already exists with vtcks pin passed from AccountSelector.cs
        public bool VerifyUserStatus(string usertype)
        {
            bool userFound;
            bool usernameFound = false ;
            string vtcks = VtckPinTxt.Text.Trim();
            string firstname = FnameTxt.Text.Trim();
            string lastname = LnameTxt.Text.Trim();
            string username = UsernameTxt.Text.Trim();

            // new user type obj should be set at this point
            switch (usertype)
            {
                case "Provider":
                    // check that the vtck pin and providers first & last name do not exist in DB
                    try
                    {
                        //rename to userFound. Exit out here? 
                        userFound = ProviderDB.VerifyProviderVtck(vtcks, firstname, lastname); //could this be for updating?
                        if (userFound)
                        {
                            DisplaySuccess("That Vtcks pin, first and last name already exists.", AppTitle);
                            this.Close(); //closes out because vtcks already linked with first and last name
                        }
                    }
                    catch (Exception ex) { throw ex; }
                    // need to pull the id and first name and last name from the form to verify provider
                    //vtck = VtckPinTxt.Text.Trim();
                    try
                    {
                        usernameFound = CDCDB.VerifyUsername(username);
                    }
                    catch (Exception ex)
                    { throw ex; }
                    break;
                case "CDC":
                    // same as above but for a cdc user just verify the first and last name do not exist
                    userFound = CDCDB.VerifyCDCUser(firstname, lastname); //could this be for updating?
                    if (userFound)
                    {
                        DisplaySuccess("That CDC user already exists.", AppTitle);
                        this.Close(); //closes out because vtcks already linked with first and last name
                    }
                    try
                    {
                        usernameFound = CDCDB.VerifyUsername(username);

                    }
                    catch (Exception ex)
                    { throw ex; }
                    break;
            }

            return usernameFound;
        }
        private string GenerateId()
        {
            bool IdExist = true;
            string newID = string.Empty;

            do
            {
                // Generate a random string 10 chars long with with 4 letters use digits 0-9 and letter A-Z
                GenerateProviderOrCdcId = IdGenerator.GenerateId(10, 3, 0, 9, 'A', 'Z');
                // Check that id does not exist already
                if (AccountType == "CDC")
                    IdExist = CDCDB.VerifyCDCId(GenerateProviderOrCdcId);
                else if (AccountType == "Provider")
                    IdExist = ProviderDB.VerifyProviderId(GenerateProviderOrCdcId);

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
        private void SetErrorPv(int txtBx, string emsg)
        {
            switch (txtBx)
            {
                case 0:
                    ErrorPv.SetError(FnameTxt, emsg);
                    break;
                case 1:
                    ErrorPv.SetError(LnameTxt, emsg);
                    break;
                case 2:
                    ErrorPv.SetError(VtckPinTxt, emsg);
                    break;
                case 3:
                    ErrorPv.SetError(ProviderSuffixCBX, emsg);
                    break;
                case 4:
                    ErrorPv.SetError(UsernameTxt, emsg);
                    break;
                case 5:
                    ErrorPv.SetError(PwdTxt, emsg);
                    break;
                case 6:
                    ErrorPv.SetError(VerifyPwdTxt, emsg);
                    break;
                case 7:
                    ErrorPv.SetError(OrganizationTxt, emsg);
                    break;
                case 8:
                    ErrorPv.SetError(FacilityTxt, emsg);
                    break;
                case 9:
                    ErrorPv.SetError(LocationTypeTxt, emsg);
                    break;
                case 10:
                    ErrorPv.SetError(StreetAddressTxt, emsg);
                    break;
                case 11:
                    ErrorPv.SetError(CityTxt, emsg);
                    break;
                case 12:
                    ErrorPv.SetError(CountyTxt, emsg);
                    break;
                case 13:
                    ErrorPv.SetError(StateCbx, emsg);
                    break;
                case 14:
                    ErrorPv.SetError(ZipTxt, emsg);
                    break;
            }
        }
        private void ResetErrorPv()
        {
            // clears the current positionn of ErrorProvider if any
            ErrorPv.Clear();
        }
        private void CreateProvider(Provider newProvider)
            //provider class properties need validation
        {
            int valueindex;
            try
            {
                newProvider.Id = GenerateProviderOrCdcId.Trim();
                newProvider.First_Name = FnameTxt.Text.Trim();
                newProvider.Last_Name = LnameTxt.Text.Trim();
                newProvider.Vtcks_Pin= VtckPinTxt.Text.Trim();

                valueindex = ProviderSuffixCBX.SelectedIndex;
                newProvider.Provider_Suffix = suffixes[valueindex].Code;
                newProvider.Username = UsernameTxt.Text.Trim();
                newProvider.Parent_Organization= OrganizationTxt.Text.Trim();
                newProvider.Administered_Location = FacilityTxt.Text.Trim();
                newProvider.Location_Type = LocationTypeTxt.Text.Trim();
                newProvider.Location_Street_Address= StreetAddressTxt.Text.Trim();
                newProvider.Location_City= CityTxt.Text.Trim();
                newProvider.Location_County= CountyTxt.Text.Trim();
                valueindex = StateCbx.SelectedIndex;
                newProvider.Location_State= daStates[valueindex].Name;
                newProvider.Location_Zipcode= ZipTxt.Text;
                CreateUser(newProvider.Username, "Provider");
            }catch(Exception ex)
            {
                ErrorOccured = true;
                throw ex;
            }


        }
        private void CreateCDC(CDC newCDCusr)
        {
            int valueindex;
            try
            {
                newCDCusr.Id = GenerateProviderOrCdcId.Trim();
                newCDCusr.First_name= FnameTxt.Text.Trim();
                newCDCusr.Last_name = LnameTxt.Text.Trim();
                newCDCusr.Username= UsernameTxt.Text.Trim();
                CreateUser(newCDCusr.Username, "CDC");
            }
            catch (Exception ex)
            {
                ErrorOccured = true;
                throw ex;
            }
        }

        private void CreateUser(string username, string userType)
        {
            try
            {
                newUser.Username = username;
                newUser.Password = PwdTxt.Text;
                if (PwdTxt.Text != VerifyPwdTxt.Text)
                    throw new Exception("Passwords don't match");
                encryptedPW = Protector.Encryptor(PwdTxt.Text);
                newUser.User_Type = userType;
            } catch(Exception ex)
            { throw ex; }


        }
        private (bool,string) CheckForm(ref int Tbx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if(AccountType == "CDC")
            {
                try
                {
                    if (string.IsNullOrEmpty(FnameTxt.Text))
                    {
                        Tbx = 0;
                        valid = false;
                        errMsg = "Must enter a first name";
                    }
                    else if (string.IsNullOrEmpty(LnameTxt.Text))
                    {
                        Tbx = 1;
                        valid = false;
                        errMsg = "Must enter a last name";
                    }
                    else if (string.IsNullOrEmpty(UsernameTxt.Text))
                    {
                        Tbx = 4;
                        valid = false;
                        errMsg = "Must enter a username";
                    }
                    else if (string.IsNullOrEmpty(PwdTxt.Text))
                    {
                        Tbx = 5;
                        valid = false;
                        errMsg = "Must enter a password";
                    }
                    else if (string.IsNullOrEmpty(VerifyPwdTxt.Text))
                    {
                        Tbx = 6;
                        valid = false;
                        errMsg = "This field cannot be empty";
                    }
                } catch(Exception ex)
                {
                    throw ex;
                }
            }
            else if(AccountType == "Provider")
            {
                try
                {
                    if (string.IsNullOrEmpty(FnameTxt.Text))
                    {
                        Tbx = 0;
                        valid = false;
                        errMsg = "Must enter a first name";
                    }
                    else if (string.IsNullOrEmpty(LnameTxt.Text))
                    {
                        Tbx = 1;
                        valid = false;
                        errMsg = "Must enter a last name";
                    }
                    else if (string.IsNullOrEmpty(VtckPinTxt.Text))
                    {
                        Tbx = 2;
                        valid = false;
                        errMsg = "Vtcks pin cannot be blank";
                    }
                    else if (ProviderSuffixCBX.SelectedIndex <= -1)
                    {
                        Tbx = 3;
                        valid = false;
                        errMsg = "A suffix must be selected";
                    }
                    else if (string.IsNullOrEmpty(UsernameTxt.Text))
                    {
                        Tbx = 4;
                        valid = false;
                        errMsg = "Must enter a username";
                    }
                    else if (string.IsNullOrEmpty(PwdTxt.Text))
                    {
                        Tbx = 5;
                        valid = false;
                        errMsg = "Must enter a password";
                    }
                    else if (string.IsNullOrEmpty(VerifyPwdTxt.Text))
                    {
                        Tbx = 6;
                        valid = false;
                        errMsg = "Must verify password";
                    }
                    else if (string.IsNullOrEmpty(OrganizationTxt.Text))
                    {
                        Tbx = 7;
                        valid = false;
                        errMsg = "Organization name cannot be blank";
                    }
                    else if (string.IsNullOrEmpty(FacilityTxt.Text))
                    {
                        Tbx = 8;
                        valid = false;
                        errMsg = "Primary facility cannot be blank";
                    }
                    else if (string.IsNullOrEmpty(LocationTypeTxt.Text))
                    {
                        Tbx = 9;
                        valid = false;
                        errMsg = "Location type cannot be blank";
                    }
                    else if (string.IsNullOrEmpty(StreetAddressTxt.Text))
                    {
                        Tbx = 10;
                        valid = false;
                        errMsg = "Street address cannot be blank";
                    }
                    else if (string.IsNullOrEmpty(CityTxt.Text))
                    {
                        Tbx = 11;
                        valid = false;
                        errMsg = "City cannot be blank";
                    }
                    else if (string.IsNullOrEmpty(CountyTxt.Text))
                    {
                        Tbx = 12;
                        valid = false;
                        errMsg = "County cannot be blank";
                    }
                    else if (StateCbx.SelectedIndex <= -1)
                    {
                        Tbx = 13;
                        valid = false;
                        errMsg = "A state must be selected";
                    }
                    else if (string.IsNullOrEmpty(ZipTxt.Text))
                    {
                        Tbx = 14;
                        valid = false;
                        errMsg = "Zip code cannot be blank";
                    }
                } catch(Exception ex)
                {
                    throw ex;
                }
            }
            return (valid, errMsg);

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            ErrorOccured = false;
            ResetErrorPv();
            int tbx = -1;
            isValid = CheckForm(ref tbx);
            bool Success = default, userSuccess = default;
            if (isValid.Item1)
            {
                try
                {

                    if (AccountType == "CDC")
                        CreateCDC(NewCDCuser);
                    else if (AccountType == "Provider")
                        CreateProvider(NewProvider);
                    if(!ErrorOccured)
                    {
                        if (!VerifyUserStatus(AccountType))
                        {
                            userSuccess = UserDB.AddUser(newUser, encryptedPW);
                            if (AccountType == "Provider")
                                Success = ProviderDB.AddProvider(NewProvider);
                            else if (AccountType == "CDC")
                                Success = CDCDB.AddCDCuser(NewCDCuser);
                            if (userSuccess && Success)
                            {
                                DisplaySuccess("User created successfully", AppTitle);
                                this.Close(); //wouldn't this go to account selector? 
                                //
                            }
                            else
                                DisplayError("Error. User has not been added", AppTitle);
                        }
                        else
                        {
                            DisplayError("Account with that username already exists.", AppTitle);
                        }


                        //if(!VerifyUserStatus(AccountType)) add this if statement before line 427, "userSucess = UserDB....."
                        //{
                        //    DisplaySuccess("Success", AppTitle);
                        //} else {
                        //      display user already exists and close signup form, open login form. 
                    }

                }
                catch (Exception ex)
                {
                    DisplayError(ex.Message, AppTitle);
                }
            }
            else
                SetErrorPv(tbx, isValid.Item2);
                
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
            FnameTxt.Text = string.Empty;
            LnameTxt.Text = string.Empty;
            ProviderSuffixCBX.SelectedIndex = -1;
            UsernameTxt.Text = string.Empty;
            PwdTxt.Text = string.Empty;
            VerifyPwdTxt.Text = string.Empty;
            OrganizationTxt.Text = string.Empty;
            FacilityTxt.Text = string.Empty;
            LocationTypeTxt.Text = string.Empty;
            StreetAddressTxt.Text = string.Empty;
            CityTxt.Text = string.Empty;
            CountyTxt.Text = string.Empty;
            StateCbx.SelectedIndex = -1;
            ZipTxt.Text = string.Empty;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // closeForm is a DialogResult object it holds the value of the button selected in the messagebox
            DialogResult closeForm = MessageBox.Show("Do you wish to close the entire application?", AppTitle,
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

        private void ZipTxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            ToolTip ErrorTip = new ToolTip();
;
            if (ZipTxt.MaskFull)
            {
                ErrorTip.ToolTipTitle = "Max Digits";
                ErrorTip.Show("Max number of digits reached for Zipcode", ZipTxt, 25, -20, 2500);
            }
            else if (e.Position == ZipTxt.Mask.Length)
            {
                ErrorTip.ToolTipTitle = "End of Field";
                ErrorTip.Show("You cannot add extra digits to end of Zipcode", ZipTxt, 25, -20, 2500);
            }
            else
            {
                ErrorTip.ToolTipTitle = "Input Rejected";
                ErrorTip.Show("Invalid Zipcode format, Zipcode must be in 00000 format", ZipTxt, 25, -20, 2500);           
            }
        }
    }
}
