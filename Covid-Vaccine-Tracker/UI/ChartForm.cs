using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class ChartForm : Form
    {
        List<VaccineRollOut> Rollout = new List<VaccineRollOut>();
        // int holds the "index" of chart type from chart menu items
        int cIndex = -1, DataIndex = 0, tIndex = 1;
        string AppTitle = "Covid Vaccine Tracker", DataErrorMsg = "Could not find data to match search filter, please try again later";
        bool dataSelected = false;
        bool barChart, lineChart, pieChart;
        string currentAxisLabel = string.Empty;
        // need a basic list to store data lists inorder to have only one Create bar&line chart method
        List<Stats> statsList = new List<Stats>();
        Dictionary<int, string> Titles = new Dictionary<int, string>()
        {
            {0, "Vaccine Information" },
            {1, "Dose Ranking" },
            {2, "Top 3 Doses" },
            {3, "Vaccine Roll Out" },
            {4, "Vaccines Series Complete" },
            {5, "City Vaccine Numbers" },
            {6, "County Vaccine Numbers" },
            {7, "Vaccines by Sex" },
            {8, "Vaccines by Race" },
            {9, "Vaccines by Ethnicity" },
            {10, "Vaccine Administered by Manufacturer" },
            {11, "Top 3 Vaccine Manufacturers" }
        };
        
        public ChartForm()
        {
            InitializeComponent();
        }

        private void BarBtn_Click(object sender, EventArgs e)
        {
            barChart = true;
            lineChart = false;
            cIndex = 1;
            // enable load btn
            LoadControl("enable");
        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            lineChart = true;
            barChart = false;
            cIndex = 2;
            // enable load btn
            LoadControl("enable");
        }

        private void PieBtn_Click(object sender, EventArgs e)
        {
            pieChart = true;
            lineChart = false;
            barChart = false;
            cIndex = 3;
            // enable load btn
            LoadControl("enable");
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
        private void RankingBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Ranking";
            tIndex = 1;
            
            // create a list to store data from db
            List<DoseRank> rankings = new List<DoseRank>();
            try
            {
                // get the data from db
                rankings = StatsDB.GetDoseRanks();
                // check there is data in the list then fill base list with data list items
                if (rankings.Count > 0)
                {
                    foreach (DoseRank obj in rankings)
                    {
                        // create stats obj and fill properties with current ranking objs values
                        Stats stat = new Stats();
                        // if dose number == 999 then dose number name = Unknown
                        if (obj.Dose_Number == 999)
                            stat.DataName = "Unknown";
                        else // dose number known
                            stat.DataName = obj.Dose_Number.ToString();
                        stat.DataValue = obj.Doses_Administered;
                        // add to stat list
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else // no data
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void TopDBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Doses";
            tIndex = 2;
            // create list to hold data
            List<TopDose> Top3D = new List<TopDose>();
            try
            {
                // get data from db
                Top3D = StatsDB.GetTop3Doses();
                // check there is data in the list then fill the stats list with data
                if (Top3D.Count > 0)
                {
                    foreach (TopDose td in Top3D)
                    {
                        // create a stats obj to hold each data items values
                        Stats stat = new Stats();
                        // assign values
                        // if dose number == 999 then dose number name = Unknown
                        if (td.Dose_Number == 999)
                            stat.DataName = "Unknown";
                        else // dose number known
                            stat.DataName = td.Dose_Number.ToString();
                        stat.DataValue = td.Doses_Administered;
                        // add to the stats list
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void RollOutBtn_Click(object sender, EventArgs e)
        {
            // clear out old list values
            statsList.Clear();
            currentAxisLabel = "Dates";
            tIndex = 3;
            // follow the same logic as above
            //List<VaccineRollOut> rollout = new List<VaccineRollOut>();
            try
            {
                //Rollout = StatsDB.GetVaccineRollout();
                if (Rollout.Count > 0)
                {
                    foreach (VaccineRollOut vr in Rollout)
                    {
                        Stats stat = new Stats();
                        // convert the date to short date 00/00/0000 format
                        stat.DataName = vr.Date.ToShortDateString();
                        stat.DataValue = vr.Vaccines_Administered;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch(Exception ex)
            { DisplayError(ex.Message,AppTitle); }
        }

        private void SeriesBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Sereis Status";
            tIndex = 4;
            List<VaccineStatus> statuses = new List<VaccineStatus>();
            try
            {
                statuses = StatsDB.GetVaccineStatuses();
                if (statuses.Count > 0)
                {
                    foreach (VaccineStatus vs in statuses)
                    {
                        Stats stat = new Stats();
                        stat.DataName = vs.Complete;
                        stat.DataValue = vs.Patients;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void CityBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "City";
            tIndex = 5;
            List<VaccineCity> cities = new List<VaccineCity>();
            try
            {
                cities = StatsDB.GetCityVaccines();
                if (cities.Count > 0)
                {
                    foreach (VaccineCity c in cities)
                    {
                        Stats stat = new Stats();
                        stat.DataName = c.City;
                        stat.DataValue = c.People_Vaccinated;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);


            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void CountyBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "County";
            tIndex = 6;
            List<VaccineCounty> counties = new List<VaccineCounty>();
            try
            {
                counties = StatsDB.GetCountyVaccines();
                if (counties.Count > 0)
                {
                    foreach (VaccineCounty c in counties)
                    {
                        Stats stat = new Stats();
                        stat.DataName = c.County;
                        stat.DataValue = c.People_Vaccinated;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);


            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void SexBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Sex";
            tIndex = 7;
            List<SexVaccine> sexes = new List<SexVaccine>();
            try
            {
                sexes = StatsDB.GetSexVaccines();
                if (sexes.Count > 0)
                {
                    foreach (SexVaccine s in sexes)
                    {
                        Stats stat = new Stats();
                        stat.DataName = s.Sex;
                        stat.DataValue = s.People_Vaccinated;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void RaceBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Primary Race";
            tIndex = 8;
            List<RaceVaccine> races = new List<RaceVaccine>();
            try
            {
                // need to double check that race1 and race2 list get merged correctly in StatsDB
                races = StatsDB.GetPrimaryRaceVaccines();
                if (races.Count > 0)
                {
                    foreach (RaceVaccine r in races)
                    {
                        Stats stat = new Stats();
                        stat.DataName = r.Race;
                        stat.DataValue = r.Doses_Administered;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void SecondaryRaceBtn_Click_1(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Secondary Race";
            tIndex = 9;
            List<RaceVaccine> races = new List<RaceVaccine>();
            try
            {
                // need to double check that race1 and race2 list get merged correctly in StatsDB
                races = StatsDB.GetSecondaryRaceVaccines();
                if (races.Count > 0)
                {
                    foreach (RaceVaccine r in races)
                    {
                        Stats stat = new Stats();
                        stat.DataName = r.Race;
                        stat.DataValue = r.Doses_Administered;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void EthnicityBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Ethnicity";
            tIndex = 10;
            List<EthnicityVaccine> ethnicities = new List<EthnicityVaccine>();
            try
            {
                ethnicities = StatsDB.GetEthnicityVaccines();
                if (ethnicities.Count > 0)
                {
                    foreach (EthnicityVaccine ev in ethnicities)
                    {
                        Stats stat = new Stats();
                        stat.DataName = ev.Ethnicity;
                        stat.DataValue = ev.People_Vaccinated;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void manufacturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Manufacturer";
            tIndex = 11;
            List<ManufacturerVaccine> manufacturers = new List<ManufacturerVaccine>();
            try
            {
                manufacturers = StatsDB.GetManufacturerVaccines();
                if (manufacturers.Count > 0)
                {
                    foreach (ManufacturerVaccine m in manufacturers)
                    {
                        Stats stat = new Stats();
                        stat.DataName = m.Manufacturer;
                        stat.DataValue = m.Doses_Administered;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);


            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void TopMBtn_Click(object sender, EventArgs e)
        {
            // clear out old list
            statsList.Clear();
            currentAxisLabel = "Manufacturer";
            tIndex = 12;
            List<ManufacturerVaccine> top3M = new List<ManufacturerVaccine>();
            try
            {
                top3M = StatsDB.GetTopManufacturerVaccines();
                if (top3M.Count > 0)
                {
                    foreach (ManufacturerVaccine m in top3M)
                    {
                        Stats stat = new Stats();
                        stat.DataName = m.Manufacturer;
                        stat.DataValue = m.Doses_Administered;
                        statsList.Add(stat);
                    }
                    // enable controls
                    ChartControl("enable");
                }
                else
                    DisplayError(DataErrorMsg, AppTitle);

            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            if (statsList.Count > 0)
            {
                if (barChart)
                    CreateBarChart(statsList, cIndex, currentAxisLabel);
                else if (lineChart)
                    CreateLineChart(statsList, cIndex, currentAxisLabel);
                else if (pieChart)
                    CreatePieChart(statsList, cIndex, currentAxisLabel);
            }
        }

        // create a method that takes and returns a generic list that way any type of stat class list can be passed in
        private void CreateBarChart(List<Stats> vaccineList, int titleKey, string axisLabel)
        {
            // clear any existing data
            ClearChartData();
            Series series = this.VaxChart.Series.Add(Titles[titleKey]);
            // if there is data in the list the create barchart
            if (vaccineList.Count > 0)
            {
                this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
                //this.VaxChart.Titles.FindByName(axisLabel);
                this.VaxChart.DataSource = vaccineList;
                // create the name for the sereies ie the line
                //series.ChartType = SeriesChartType.Bar;
                series.AxisLabel = axisLabel;
                // create the chart title by using values stored in Titles dict
                //this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
                // loop through each data item in list
                for (int datapoint = 0; datapoint < vaccineList.Count; datapoint++)
                {
                    //// assign each data point name ie Dose Number to chart series
                    ////Series series = this.VaxChart.Series.Add(vaccineList.ElementAt(datapoint).DataName);
                    series = this.VaxChart.Series.Add(vaccineList.ElementAt(datapoint).DataName);
                    series.AxisLabel = axisLabel;
                    //// now add the data values ie the number of doses administered for respective dose number
                    series.Points.Add(vaccineList.ElementAt(datapoint).DataValue);
                    VaxChart.Series[datapoint].LegendText = vaccineList.ElementAt(datapoint).DataName;
                    VaxChart.Series[datapoint].Label = vaccineList.ElementAt(datapoint).DataValue.ToString();

                }
                
            }
            else // no data in list
                DisplayError(DataErrorMsg, AppTitle);
        }
        // create a method that takes and returns a generic list that way any type of stat class list can be passed in
        private void CreateLineChart(List<Stats> vaccineList, int titleKey, string axisLabel)
        {
            // clear any existing data
            ClearChartData();

            try
            {
                // if there is data in the list create linechart
                if (vaccineList.Count > 0)
                {
                    // use Titles dict to create chart title
                    this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
                    this.VaxChart.DataSource = vaccineList;
                    // create the name for the sereies ie the line
                    Series series = this.VaxChart.Series.Add(Titles[titleKey]);
                    series.ChartType = SeriesChartType.Line;
                    series.AxisLabel = axisLabel;
                    // loop through the list and assign each x,y cordinate to chart
                    for (int dp = 0; dp < vaccineList.Count; dp++)
                    {
                        // get the x y values for each item in list
                        string xPoint = vaccineList.ElementAt(dp).DataName;
                        int yPoint = vaccineList.ElementAt(dp).DataValue;
                        // now add the x, y values
                        series.Points.AddXY(xPoint, yPoint);
                    }

                }
                else // no data in list
                    DisplayError(DataErrorMsg, AppTitle);
            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void CreatePieChart(List<Stats> vaccineList, int titleKey, string axisLabel)
        {
            ClearChartData();
            // set the title
            try
            {
                this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
                Series series = this.VaxChart.Series.Add(Titles[titleKey]);
                series.ChartType = SeriesChartType.Pie;
                series.AxisLabel = axisLabel;
                // create the chart if there is data in list
                if (vaccineList.Count > 0)
                {
                    for (int dp = 0; dp < vaccineList.Count; dp++)
                    {
                        // get the datavalues for the chart from list
                        string xPoint = vaccineList.ElementAt(dp).DataName;
                        int yPoint = vaccineList.ElementAt(dp).DataValue;
                        series.Points.AddXY(xPoint, yPoint);
                    }
                }
                else // no data in list
                    DisplayError(DataErrorMsg, AppTitle);
            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void ChartForm_Load(object sender, EventArgs e)
        {
            int totalDose = 0, numPpl = 0;
            double mean = 0, movinAvg = 0, std = 0, variance = 0;           

            try
            {
                Rollout = StatsDB.GetVaccineRollout();
                // calc some descriptive statistics
                totalDose = StatsDB.GetDoseCount();
                numPpl = StatsDB.GetPatientCount();
                mean = Math.Round(StatsDB.GetAverageDose(),4);
                // calculate a 7 day rolling average
                movinAvg = Math.Round(VaccineStatistics.CalculateMovingAverage(totalDose, 7),4);
                // Get the the list of data
                std = Math.Round(VaccineStatistics.CalculateSampleStandardDev(Rollout),4);
                variance = Math.Round(VaccineStatistics.CalculateSampleVarriance(Rollout),4);
            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }

            // display statistics in textboxs
            TotalDoseTxt.Text = totalDose.ToString();
            TotalPatientTxt.Text = numPpl.ToString();
            AvgTxt.Text = mean.ToString();
            MovingAvgTxt.Text = movinAvg.ToString();
            StdTxt.Text = std.ToString();
            VarTxt.Text = variance.ToString();
            

            // disable controls
            DataControl("enable");
            ChartControl("Disable");
            LoadControl("Disable");
            // give chart the focus
            VaxChart.Focus();
        }
        private void SetChartType(int chartIndx)
        {
            try
            {
                // determine the index of chart to determine chart type
                switch (chartIndx)
                {
                    case 1:
                        VaxChart.Series[0].ChartType = SeriesChartType.StackedBar;
                        break;
                    case 2:
                        VaxChart.Series[0].ChartType = SeriesChartType.Column;
                        break;
                    case 3:
                        VaxChart.Series[0].ChartType = SeriesChartType.StackedColumn;
                        break;
                    case 4:
                        VaxChart.Series[0].ChartType = SeriesChartType.StepLine;
                        break;
                    case 5:
                        VaxChart.Series[0].ChartType = SeriesChartType.SplineArea;
                        break;
                    case 6:
                        VaxChart.Series[0].ChartType = SeriesChartType.StackedArea;
                        break;
                    case 7:
                        VaxChart.Series[0].ChartType = SeriesChartType.Kagi;
                        break;
                    case 8:
                        VaxChart.Series[0].ChartType = SeriesChartType.Bubble;
                        break;
                    case 9:
                        VaxChart.Series[0].ChartType = SeriesChartType.Funnel;
                        break;
                    case 10:
                        VaxChart.Series[0].ChartType = SeriesChartType.Pyramid;
                        break;
                }
            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void ClearChartData()
        {
            // clear out anything in chart
            this.VaxChart.Series.Clear();
            this.VaxChart.Titles.Clear();
        }

        private void DataControl(string command)
        {
            string commandLOWER = command.ToLower();
            switch(commandLOWER)
            {
                case "disable":
                    DataBtn.Enabled = false;
                    break;
                case "enable":
                    DataBtn.Enabled = true;
                    break;
            }
        }
        private void ChartControl(string command)
        {
            string commandLOWER = command.ToLower();
            switch (commandLOWER)
            {
                case "disable":
                    BarBtn.Enabled = false;
                    LineBtn.Enabled = false;
                    PieBtn.Enabled = false;
                    break;
                case "enable":
                    BarBtn.Enabled = true;
                    LineBtn.Enabled = true;
                    PieBtn.Enabled = true;
                    break;
            }
        }
        private void LoadControl(string command)
        {
            string commandLOWER = command.ToLower();
            switch (commandLOWER)
            {
                case "disable":
                    LoadBtn.Enabled = false;
                    break;
                case "enable":
                    LoadBtn.Enabled = true;
                    break;
            }
        }

        private void DisplaySuccess(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void DisplayError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
