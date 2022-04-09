using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Aspose.Words.Drawing.Charts;
using Covid_Vaccine_Tracker.Business_Objects;
using Covid_Vaccine_Tracker.Data_Access_Layer;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class ChartForm : Form
    {
        List<VaccineRollOut> Rollout = new List<VaccineRollOut>();
        int currentList = 1;
        // int holds the "index" of chart type from chart menu items
        int cIndex = 1;
        string AppTitle = "Covid Vaccine Tracker", DataErrorMsg = "Could not find data to match search filter, please try again later";
        bool dataSelected = false;
        bool barChart, lineChart, pieChart, dataClicked = false;
        Series series;
        // need a basic list to store data lists inorder to have only one Create bar&line chart method
        List<Stats> statsList = new List<Stats>();
        Dictionary<int, string> Titles = new Dictionary<int, string>()
        {
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
            pieChart = false;
        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            lineChart = true;
            barChart = false;
            pieChart = false;
            string cTitle = this.VaxChart.Titles.ToString();
            cIndex = 5;
        }
        private void PieBtn_Click(object sender, EventArgs e)
        {
            pieChart = true;
            lineChart = false;
            barChart = false;
            string cTitle = this.VaxChart.Titles.ToString();
            cIndex = 11;
        }

        private void StackedBarBtn_Click(object sender, EventArgs e)
        {
            cIndex = 2;
            string cTitle = this.VaxChart.Titles.ToString();
        }
        private void ColumnBtn_Click(object sender, EventArgs e)
        {
            cIndex = 3;
            string cTitle = this.VaxChart.Titles.ToString();

        }
        private void StackedColumnBtn_Click(object sender, EventArgs e)
        {
            cIndex = 4;
            string cTitle = this.VaxChart.Titles.ToString();

        }
        private void StepLineBtn_Click(object sender, EventArgs e)
        {
            cIndex = 6;
            string cTitle = this.VaxChart.Titles.ToString();

        }

        private void SplineAreaBtn_Click(object sender, EventArgs e)
        {
            cIndex = 7;
            string cTitle = this.VaxChart.Titles.ToString();

        }
        private void StackedAreaBtn_Click(object sender, EventArgs e)
        {
            cIndex = 8;
            string cTitle = this.VaxChart.Titles.ToString();

        }

        private void KagiBtn_Click(object sender, EventArgs e)
        {
            cIndex = 9;
            string cTitle = this.VaxChart.Titles.ToString();

        }

        private void BubbleBtn_Click(object sender, EventArgs e)
        {
            // buble chart requires atleaset 2 y values
            cIndex = 10;
            string cTitle = this.VaxChart.Titles.ToString();
        }


        private void FunnelBtn_Click(object sender, EventArgs e)
        {
            cIndex = 12;
            string cTitle = this.VaxChart.Titles.ToString();
        }

        private void PyrimidBtn_Click(object sender, EventArgs e)
        {
            cIndex = 13;
            string cTitle = this.VaxChart.Titles.ToString();
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
                    ChartControls("Enable");
                    //barChart, lineChart, pieChart, stackedBar, column, stackedCol, stepLine, area, stackedArea, kagi, bubble, funnel, pyrmaid;
                    // create selected chart pass in list and title key
                    //if (barChart)
                    //    CreateBarChart(statsList, 1);
                    //else if (lineChart)
                    //    CreateLineChart(statsList, 1);
                    //else if (pieChart)
                    //    CreatePieChart(statsList, 1);
                    //// if not any of 3 base charts get create specific chart
                    //else
                    //    CreateChart(statsList, cIndex, 1);
                }
                else // no data
                {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }
               
            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void TopDBtn_Click(object sender, EventArgs e)
        {
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
                    ChartControls("Enable");


                }
                else
                {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }    
                
            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void RollOutBtn_Click(object sender, EventArgs e)
        {
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
                    ChartControls("Enable");

                }
                else
                {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

            }
            catch(Exception ex)
            { DisplayError(ex.Message,AppTitle); }
        }

        private void SeriesBtn_Click(object sender, EventArgs e)
        {
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
                    ChartControls("Enable");  
                }
                else
                {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");

                 }

                
            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void CityBtn_Click(object sender, EventArgs e)
        {
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
                    ChartControls("Enable");
                }
                else
                {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void CountyBtn_Click(object sender, EventArgs e)
        {
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
                    ChartControls("Enable");
              
                }
                else
                    {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

              
            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void SexBtn_Click(object sender, EventArgs e)
        {
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
                    ChartControls("Enable");
                 
                }
                else
                    {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

              
            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void RaceBtn_Click(object sender, EventArgs e)
        {
            List<RaceVaccine> races = new List<RaceVaccine>();
            try
            {
                // need to double check that race1 and race2 list get merged correctly in StatsDB
                races = StatsDB.GetRaceVaccines();
                if (races.Count > 0)
                {
                    foreach (RaceVaccine r in races)
                    {
                        Stats stat = new Stats();
                        stat.DataName = r.Race;
                        stat.DataValue = r.Doses_Administered;
                        statsList.Add(stat);
                    }
                    ChartControls("Enable");
                  
                }
                else
                    {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

               
            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }

        private void EthnicityBtn_Click(object sender, EventArgs e)
        {
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
                    ChartControls("Enable");
                
                }
                else
                    {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

               
            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void manufacturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ManufacturerVaccine> manufacturers = new List<ManufacturerVaccine>();
            try
            {
                manufacturers = StatsDB.GetManufacturerVaccines();
                if (manufacturers.Count > 0)
                {
                    foreach (ManufacturerVaccine m in manufacturers)
                    {
                        Stats stat = new Stats();
                        stat.DataName = m.Vaccine_Manufacturer;
                        stat.DataValue = m.Doses_Administered;
                        statsList.Add(stat);
                    }
                    ChartControls("Enable");
                }
                else
                {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void TopMBtn_Click(object sender, EventArgs e)
        {
            List<ManufacturerVaccine> top3M = new List<ManufacturerVaccine>();
            try
            {
                top3M = StatsDB.GetTopManufacturerVaccines();
                if (top3M.Count > 0)
                {
                    foreach (ManufacturerVaccine m in top3M)
                    {
                        Stats stat = new Stats();
                        stat.DataName = m.Vaccine_Manufacturer;
                        stat.DataValue = m.Doses_Administered;
                        statsList.Add(stat);
                    }
                    ChartControls("Enable");
                }
                else
                {
                    DisplayError(DataErrorMsg, AppTitle);
                    ChartControls("Disable");
                    ViewControl("Disable");
                }

            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        // create a method that takes and returns a generic list that way any type of stat class list can be passed in
        private void CreateBarChart(List<Stats> vaccineList, int titleKey)
        {
            // clear any existing data
            ClearChartData();
            series = new Series();
            
            // if there is data in the list the create barchart
            if (vaccineList.Count > 0)
            {
                // create the chart title by using values stored in Titles dict
                this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
                //loop through each data item in list
                for (int datapoint = 0; datapoint < vaccineList.Count; datapoint++)
                {
                    // assign each data point name ie Dose Number to chart series
                    series = this.VaxChart.Series.Add(vaccineList.ElementAt(datapoint).DataName);
                    // now add the data values ie the number of doses administered for respective dose number
                    series.Points.Add(vaccineList.ElementAt(datapoint).DataValue);
                    VaxChart.Series.Add(series);
                }
                
                //for (int datapoint = 0; datapoint < vaccineList.Count; datapoint++)
                //{
                //    VaxChart.Series["Vaccines"].Points.Add(vaccineList[datapoint].DataValue);
                //    VaxChart.Series["Vaccines"].Points[datapoint].AxisLabel = vaccineList[datapoint].DataName;
                //    VaxChart.Series["Vaccines"].Points[datapoint].LegendText = vaccineList[datapoint].DataName;
                //    VaxChart.Series["Vaccines"].Points[datapoint].Label = vaccineList[datapoint].DataValue.ToString();
                //}
            }
            else // no data in list
                DisplayError(DataErrorMsg, AppTitle);
        }
        // create a method that takes and returns a generic list that way any type of stat class list can be passed in
        private void CreateLineChart(List<Stats> vaccineList, int titleKey)
        {
            // clear any existing data
            ClearChartData();

            // if there is data in the list create linechart
            if (vaccineList.Count > 0)
            {
                // use Titles dict to create chart title
                this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
                // loop through the list and assign each x,y cordinate to chart
                for (int dp = 0; dp < vaccineList.Count; dp++)
                {
                    // get the x y values for each item in list
                    string xPoint = vaccineList.ElementAt(dp).DataName;
                    int yPoint = vaccineList.ElementAt(dp).DataValue;
                    // create the name for the sereies ie the line
                    Series series = this.VaxChart.Series.Add(Titles[titleKey]);
                    // now add the x, y values
                    series.Points.AddXY(xPoint, yPoint);
                }
                VaxChart.Series.Add(series);
            }
            else // no data in list
                DisplayError(DataErrorMsg, AppTitle);
        }
        private void CreatePieChart(List<Stats> vaccineList, int titleKey)
        {
            ClearChartData();
            // set the chart type to pie
            VaxChart.Series[0].ChartType = SeriesChartType.Pie;
            // set the title
            this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
            // create the chart if there is data in list
            if (vaccineList.Count > 0)
            {
                for (int dp = 0; dp < vaccineList.Count; dp++)
                {
                    // get the datavalues for the chart from list
                    string xPoint = vaccineList.ElementAt(dp).DataName;
                    int yPoint = vaccineList.ElementAt(dp).DataValue;
                    VaxChart.Series[0].Points.AddXY(xPoint, yPoint);
                }
                VaxChart.Series.Add(series);
            }
            else // no data in list
                DisplayError(DataErrorMsg, AppTitle);
        }
        private void CreateChart(List<Stats> vaccineList, int chartIdx, int titleKey)
        {
            ClearChartData();
            VaxChart.DataSource = vaccineList;
            SetChartType(chartIdx);
            this.VaxChart.Titles.Add(Titles.ElementAt(titleKey).Value);
            // this.VaxChart.DataSource = vaccineList;
            if (vaccineList.Count > 0)
            {
                for (int dp = 0; dp < vaccineList.Count; dp++)
                {
                    string xPoint = vaccineList.ElementAt(dp).DataName;
                    int yPoint = vaccineList.ElementAt(dp).DataValue;
                    VaxChart.Series[0].Points.AddXY(xPoint, yPoint);
                }
            }
            else // no data in list
                DisplayError(DataErrorMsg, AppTitle);
        }
        private void CreateChart(List<Stats> vaccineList, int chartIdx, string title)
        {
            ClearChartData();
            SetChartType(chartIdx);
            this.VaxChart.Titles.Add(title);
            this.VaxChart.DataSource = vaccineList;
            if (vaccineList.Count > 0)
            {
                for (int dp = 0; dp < vaccineList.Count; dp++)
                {
                    string xPoint = vaccineList.ElementAt(dp).DataName;
                    int yPoint = vaccineList.ElementAt(dp).DataValue;
                    VaxChart.Series[0].Points.AddXY(xPoint, yPoint);
                }
            }
            else // no data in list
                DisplayError(DataErrorMsg, AppTitle);
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
        }

        private void ViewChart_Click(object sender, EventArgs e)
        {
            try
            {
                if (statsList.Count > 0)
                {
                    if (barChart)
                        CreateBarChart(statsList, 1);
                    if (lineChart)
                        CreateLineChart(statsList, 1);
                }
                else
                    DisplayError("Please select data to view in the chart", AppTitle);
            }
            catch(Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void DataControls(string command)
        {
            switch(command)
            {
                case "Disable":
                    DataBtn.Enabled = false;
                    break;
                case "Enable":
                    DataBtn.Enabled = true;
                    break;
            }
        }
        private void ChartControls(string command)
        {
            switch(command)
            {
                case "Disable":
                    BarBtn1.Enabled = false;
                    LineBtn1.Enabled = false;
                    PieBtn1.Enabled = false;
                    break;
                case "Enable":
                    BarBtn1.Enabled = true;
                    LineBtn1.Enabled = true;
                    PieBtn1.Enabled = true;
                    break;
            }
        }
        private void ViewControl(string commnad )
        {
            switch(commnad)
            {
                case "Disable":
                    ViewBtn.Enabled = false;
                    break;
                case "Enable":
                    ViewBtn.Enabled = true;
                    break;
            }
        }


        private void SetChartType(int chartIndx)
        {
            try
            {
                series = new Series();
                // determine the index of chart to determine chart type
                switch (chartIndx)
                {
                    case 1:
                        VaxChart.Series[0].ChartType = SeriesChartType.Bar;                       
                        //VaxChart.Series[0].ChartType = SeriesChartType.Bar;
                        break;
                    case 2:
                        series.ChartType = SeriesChartType.StackedBar;
                        break;
                    case 3:
                        series.ChartType = SeriesChartType.Column;
                        break;
                    case 4:
                        series.ChartType = SeriesChartType.StackedColumn;
                        break;
                    case 5:
                        series.ChartType = SeriesChartType.Line;
                        break;
                    case 6:
                        series.ChartType = SeriesChartType.StepLine;
                        break;
                    case 7:
                        series.ChartType = SeriesChartType.SplineArea;
                        break;
                    case 8:
                        series.ChartType = SeriesChartType.StackedArea;
                        break;
                    case 9:
                        series.ChartType = SeriesChartType.Kagi;
                        break;
                    case 10:
                        series.ChartType = SeriesChartType.Bubble;
                        break;
                    case 11:
                        series.ChartType = SeriesChartType.Pie;
                        break;
                    case 12:
                        series.ChartType = SeriesChartType.Funnel;
                        break;
                    case 13:
                        series.ChartType = SeriesChartType.Pyramid;
                        break;
                    default:
                        series.ChartType = SeriesChartType.Bar;
                        break;
                }

                VaxChart.Series.Add(series);
            }
            catch (Exception ex)
            { DisplayError(ex.Message, AppTitle); }
        }
        private void ClearChartData()
        {
            // clear out anything in chart
            this.VaxChart.Series.Clear();
            this.VaxChart.Titles.Clear();
            this.VaxChart.DataSource = null;
            this.VaxChart.ChartAreas.Clear();
            // clear the series
            if (series != null)
                series.Points.Clear();
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
