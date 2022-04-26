// Covid Vax Tracker - View Form
// By Zachary Palmer 2/15/2022

///<summary>
/// This form is used by Providers and CDC Users
/// when an instance of this form is created a
/// a bool is passed in that determines if the current
/// user is a CDC. Certain views are only available to Providers.
/// After view is selected then it is displayed in a Data Grid View
/// The graph shows the selected view data value versus the value for Mo and the for the Country
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
// Using statements needed to access other namespaces in the project
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;


namespace Covid_Vaccine_Tracker.UI
{
    public partial class ViewForm : Form
    {
        readonly bool IsCdcUser;
        List<Views> RecordViews = new List<Views>();
        readonly string AppTitle = "Covid Vaccine Tracker";
        Patient patient;

        public ViewForm()
        {
            InitializeComponent();
        }
        public ViewForm(bool cView)
        {
            // Method needed to setup form boilerplate code
            InitializeComponent();

            // Determine truth values; these values will be used to get correct views
            if (cView)
                IsCdcUser = true;
            else if (!cView)
                IsCdcUser = false;
        }
        // When the form loads determine user type and bind view options to combo-boxs
        private void ViewForm_Load(object sender, EventArgs e)
        {


            // Make sure Datagrid view has no persisting data from before
            RecordsDg.DataSource = null;
            // Ceck to see which type of user to get respective views
            if (IsCdcUser)
                RecordViews = ViewDB.GetCdcViews();

            if (!IsCdcUser)
            {
                RecordViews = ViewDB.GetProviderViews();

                //disables reporting
                ReportBtn.Enabled = false;
            }

            // Bind views to combo box
            ViewsCbx.DataSource = RecordViews;
            ViewsCbx.DisplayMember = "View_Type";
            ViewsCbx.ValueMember = "Id";
            // Disable chart button
            //ChartControl("Disable");
        }
        private void ChartControl(string command)
        {
            switch(command)
            {
                case "Disable":
                    ChartBtn.Enabled = false;
                    break;
                case "Enable":
                    ChartBtn.Enabled = true;
                    break;
            }
        }
        private void ValueInput(string command)
        {
            switch(command)
            {
                case "Disable":
                    IdLbl.Visible = false;
                    IdLbl.Enabled = false;
                    SearchValTxt.Visible = false;
                    SearchValTxt.Enabled = false;
                    break;
                case "Enable":
                    IdLbl.Visible = true;
                    IdLbl.Enabled = true;
                    SearchValTxt.Visible = true;
                    SearchValTxt.Enabled = true;
                    break;
            }
        }
        private void SetLabelText(string txt)
        {
            IdLbl.Text = txt;
        }
        private (bool,string) CheckForm(ref int tbx)
        {
            bool valid = true;
            string errMsg = string.Empty;

            if (string.IsNullOrEmpty(SearchValTxt.Text))
            {
                valid = false;
                errMsg = "You must enter a value to search by";
                tbx = 1;
            }
            return (valid, errMsg);
        }
        private void SetErrorPv(int tbx, string errMsg)
        {
            // This checks the value of tbx then places errorPV icon next to control with errmsg on form
            switch(tbx)
            {
                case 0:
                    ErrorPv.SetError(ViewsCbx, errMsg);
                    break;
                case 1:
                    ErrorPv.SetError(SearchValTxt, errMsg);
                    break;
            }
        }
        private void ResetErrorPv()
        { ErrorPv.Clear(); }
        private void DisplaySuccess(string msg, string title)
        { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information); }
        private void DisplayError(string msg, string title)
        { MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        private (bool,string) VerifyItemSelected()
        {
            // This checks to make sure that the user selected a record view type
            bool valid;
            string eMsg = string.Empty;

            if (ViewsCbx.SelectedIndex <= -1)
            {
                valid = false;
                eMsg = "You must select a record view type";
            }
            else
                valid = true;

            return (valid, eMsg);
        }
        private List<VaccineRecords_View> GetRecords_CDC(int indx)
        {
            // Create lists that will store respective record type
            List<VaccineRecords_View> vaccineRecords = new List<VaccineRecords_View>();
            (bool, string) isValid;
            int Tbx = -1;
            //determine the view selected index vale then get data from the database and then stores it in a list
            try
            {
                switch (indx)
                {
                    case 0:
                        vaccineRecords = VaccineRecordDB.GetVaccineRecords_D();
                        break;
                    case 1:
                        vaccineRecords = VaccineRecordDB.GetVaccinesBySeriesStatus_D("Yes");
                        break;
                    case 2:
                        vaccineRecords = VaccineRecordDB.GetVaccinesBySeriesStatus_D("No");
                        break;
                    case 3:
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1)
                        {
                            string doseNumber = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccinesByDose_D(doseNumber);
                        }
                        else
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                    case 4:
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1)
                        {
                            string city = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccinesByCity_D(city);
                        }
                        else
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                    case 5:
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1)
                        {
                            string county = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccineByCounty_D(county);
                        }
                        else
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                }
            }
            catch (Exception ex)
            { throw ex; }

            return vaccineRecords;
        }
        private List<Identifying_VaccineRecords_View> GetVaccineRecords_Provider(int indx)
        {
            // This method determines what vaccine records view was selected
            // Create lists that will store respective record type
            List<Identifying_VaccineRecords_View> vaccineRecords = new List<Identifying_VaccineRecords_View>();
            // Create a list to hold patient objects incase patinet(s) info is viewed
            List<Patient> patientRecords = new List<Patient>();
            (bool, string) isValid;
            int Tbx = -1;
            // determine the view selected index vale then get data from the database and then stores it in a list

            // Double check that the selected index matches the correct method to be called
            try
            {
                switch (indx)
                {
                    case 0: // All vaccine records                        
                        vaccineRecords = VaccineRecordDB.GetVaccineRecords_I();
                        break;
                    case 1: // Vaccine series complete = yes
                        vaccineRecords = VaccineRecordDB.GetVaxSeries_I("Yes");
                        break;
                    case 2: // Vaccine sereis complete = no
                        vaccineRecords = VaccineRecordDB.GetVaxSeries_I("No");
                        break;
                    case 3: // Vaccine by dose
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1)
                        {
                            string doseNumber = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccinesByDose_I(doseNumber);
                        }
                        else
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                    case 4: // vax by city
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1)
                        {
                            string city = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccineByCity_I(city);
                        }
                        else
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                    case 5: // vax by county
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1)
                        {
                            string county = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccineByCounty_I(county);
                        }
                        else
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                    case 6: // vax by race
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1)
                        {
                            string race = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccinesByRace_I(race);
                        }
                        else
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                    case 7: // Vaccine records by patient
                        isValid = CheckForm(ref Tbx);
                        if (isValid.Item1) // If patient id is not null or empty then find patient's records
                        {
                            string patientId = SearchValTxt.Text.Trim();
                            vaccineRecords = VaccineRecordDB.GetVaccineRecord_I(patientId);
                        }
                        else // patient id was null or empty so display error msg with error provider
                            SetErrorPv(Tbx, isValid.Item2);
                        break;
                }
            }
            catch (Exception ex)
            { throw ex; }

            return vaccineRecords;
        }
        private List<Patient> GetPatientRecords_Provider(int indx)
        {
            // This method determins what patient records view was selected
            // Used to determine if patient id is entered 
            (bool, string) isValid;
            int Tbx = -1;
            // Create a list to hold patient objs
            List<Patient> patientRecords = new List<Patient>();

            //double check that these call the correct methods
            switch (indx)
            {
                case 8: // Patient information
                    isValid = CheckForm(ref Tbx);
                    if (isValid.Item1) // If patient id is not null or empty assign first element in list to patient 
                    {
                        string patientId = SearchValTxt.Text.Trim();
                        // add patient to patient list
                        patientRecords.Add(PatientDB.GetPatient(patientId));
                    }
                    else
                        SetErrorPv(Tbx, isValid.Item2);
                    break;
                case 9: // All patient information
                    patientRecords = PatientDB.GetPatients();
                    break;
            }

            return patientRecords;
        }
        private void CreatePatient(List<string> cols, DateTime dob)
        {
            int valueIndex;            // try blocks go around code that could throw an error then passes any errors to the catch block
            try
            {
                patient = new Patient();
                patient.Id = cols[0];
                patient.First_name = cols[1];
                patient.Middle_name = cols[2];
                patient.Last_name = cols[3];
                patient.Date_of_birth = dob;
                patient.Street_address = cols[4];
                patient.City = cols[5];
                patient.County = cols[6];
                patient.State = cols[7];
                patient.Zipcode = cols[8];
                patient.Race1 = cols[9];
                patient.Race2 = cols[10];
                patient.Ethnicity = cols[11];
                patient.Sex = cols[12];
                patient.Extract_Type = cols[13];
            }
            catch (Exception ex)
            { throw ex; }

        }
        private void EnterBtn_Click(object sender, EventArgs e)
        {           
            // Lists to hold respective records
            List<VaccineRecords_View> vaxRecords_CDC = new List<VaccineRecords_View>();
            List<Identifying_VaccineRecords_View> vaxRecords_Provider = new List<Identifying_VaccineRecords_View>();
            List<Patient> patientRecords = new List<Patient>();
            // Single patient to hold patient record
            Patient patientRequest = new Patient();
            // Holds the index of the view selected in view combo-box
            int selectedView;
            // Check user selected a view option
            (bool, string) optionSelected = VerifyItemSelected();

            if (optionSelected.Item1)
            {
                try
                {
                    // Get the selected index of view combo box
                    selectedView = ViewsCbx.SelectedIndex;

                    if (IsCdcUser)
                    {
                        // If IsCdcUser is true then get the records for selected view
                        vaxRecords_CDC = GetRecords_CDC(selectedView);
                        // Then bind the list to the Records Datagrid control
                        RecordsDg.DataSource = vaxRecords_CDC;
                    }
                    else if (!IsCdcUser)
                    {
                        // If IsCdcUser is false & combo-bx selected index <= 4 then get the records for selected view
                        if (selectedView <= 7)
                        {
                            vaxRecords_Provider = GetVaccineRecords_Provider(selectedView);
                            // Then bind the list to the Records Datagrid control
                            RecordsDg.DataSource = vaxRecords_Provider;

                            // if no record was found then tell the user and then pull up all records
                            if (vaxRecords_Provider.Count() <= 0)
                            { 
                                DisplaySuccess("There were no vaccine records found for specified search criteria", AppTitle);
                                vaxRecords_Provider = VaccineRecordDB.GetVaccineRecords_I();
                                RecordsDg.DataSource = vaxRecords_Provider;
                            }
                        }
                        // If IsCdcUser false & combo-bx selected index > 4
                        else if (selectedView >= 8)
                        {
                            patientRecords = GetPatientRecords_Provider(selectedView);
                            RecordsDg.DataSource = patientRecords;
                            // if no record was found then tell teh user and then pull up all records
                            if (patientRecords.Count() <= 0)
                            {
                                DisplaySuccess("There were no patient records found for specified search criteria", AppTitle);
                                patientRecords = PatientDB.GetPatients();
                                RecordsDg.DataSource = patientRecords;
                            }
                        }
                    }
                    else // something unexpected happened this is probably unessacary and redundant
                        DisplayError("Error, unknown operation please select a view type in combo-box", AppTitle);

                    // Check to make sure that list being used has values before enabling chart button
                    if (vaxRecords_CDC.Count > 0 || vaxRecords_Provider.Count > 0 || patientRecords.Count > 0)
                        ChartControl("Enable");

                }
                catch (Exception ex)
                { DisplayError(ex.Message, AppTitle); }
            }
            else // If the didnt pick a view option.. combo-box is index 0
                SetErrorPv(0, optionSelected.Item2);

        }
        // The chart button is out of scope for sprint on 2/17/22 so just display notification 
        private void ChartBtn_Click(object sender, EventArgs e)
        {
            ChartForm charts = new ChartForm();
            charts.ShowDialog();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            // If a provider is viewing records give them an option to go back to provider form to enter more data
            // or close out the entire app. But if it is a cdc user close out app
            if (!IsCdcUser)
            {
                // closeForm is a DialogResult object it holds the value of the button selected in the messagebox
                DialogResult closeForm = MessageBox.Show("Do You wish to close the entire application?", AppTitle,
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                // Checks to see if yes button was selected
                if (closeForm == DialogResult.Yes)
                    this.Close();
                // Check to see if no btn was selected
                else if (closeForm == DialogResult.No)
                    this.Close();
                // Dont need to check if cancel was selected because not closing app or not closing form
                // is what cancel should do
            }
            else
                Application.Exit();
        }
        private void ViewsCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // double check that these are the correct selected index values

            // If provider wants to view patient vaccine info or patient info display patient id txtbox
            if (!IsCdcUser)
            {
                if (ViewsCbx.SelectedIndex <= 2 || ViewsCbx.SelectedIndex == 9)
                    ValueInput("Disable");

                else if (ViewsCbx.SelectedIndex == 7 || ViewsCbx.SelectedIndex == 8)
                {
                    SetLabelText("Patient Id");
                    ValueInput("Enable");
                }
                else
                {
                    ValueInput("Enable");

                    switch(ViewsCbx.SelectedIndex)
                    {
                        case 3:
                            SetLabelText("Dose Number");
                            break;
                        case 4:
                            SetLabelText("City");
                            break;
                        case 5:
                            SetLabelText("County");
                            break;
                        case 6:
                            SetLabelText("Race");
                            break;
                    }
                }
            }
            else // If cdc user then disable patient lbl and txtbx
            {
                // If index > 2 then need textbox
                if (ViewsCbx.SelectedIndex > 2)
                {
                    ValueInput("Enable");

                    switch (ViewsCbx.SelectedIndex)
                    {
                        case 3:
                            SetLabelText("Dose Number");
                            break;
                        case 4:
                            SetLabelText("City");
                            break;
                        case 5:
                            SetLabelText("County");
                            break;
                    }  
                }
                else
                    ValueInput("Disable");
            }
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            // need to add code that disables the report btn for providers
            VaccineReportForm vaccineReport = new VaccineReportForm();
            vaccineReport.ShowDialog();
        }

        // get the current cell data and then update
        private void RecordsDg_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ViewsCbx.SelectedIndex == 8 || ViewsCbx.SelectedIndex == 9)
            {
                string id, fname, mname, lname, street, city, county, state, zip, race1, race2, ethnicity, sex, extract, bday;
                
                DateTime dob, d;

                try
                {
                    id = RecordsDg.CurrentRow.Cells[0].Value.ToString();
                    fname = RecordsDg.CurrentRow.Cells[1].Value.ToString();
                    mname = RecordsDg.CurrentRow.Cells[2].Value.ToString();
                    lname = RecordsDg.CurrentRow.Cells[3].Value.ToString();
                    //bday = RecordsDg.CurrentRow.Cells[4].Value.ToString();
                    dob = DateTime.Parse(RecordsDg.CurrentRow.Cells[4].Value.ToString());
                    street = RecordsDg.CurrentRow.Cells[5].Value.ToString();
                    city = RecordsDg.CurrentRow.Cells[6].Value.ToString();
                    county = RecordsDg.CurrentRow.Cells[7].Value.ToString();
                    state = RecordsDg.CurrentRow.Cells[8].Value.ToString();
                    zip = RecordsDg.CurrentRow.Cells[9].Value.ToString();
                    race1 = RecordsDg.CurrentRow.Cells[10].Value.ToString();
                    race2 = RecordsDg.CurrentRow.Cells[11].Value.ToString();
                    ethnicity = RecordsDg.CurrentRow.Cells[12].Value.ToString();
                    sex = RecordsDg.CurrentRow.Cells[13].Value.ToString();
                    extract = RecordsDg.CurrentRow.Cells[14].Value.ToString();

                    // put values in list then create patient obj
                    List<string> columns = new List<string> { id, fname, mname, lname, street, city, county, state, zip, race1, race2, ethnicity, sex, extract};
                    CreatePatient(columns, dob);
                    ProviderForm pForm = new ProviderForm(patient);
                    pForm.ShowDialog();
                }
                catch(Exception ex)
                { DisplayError(ex.Message, AppTitle); }
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult closeForm = MessageBox.Show(Errors.GetError(27), AppTitle,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Checks to see if yes button was selected
            if (closeForm == DialogResult.Yes)
                Application.Exit();
        }
    }
}
