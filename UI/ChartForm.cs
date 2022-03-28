using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid_Vaccine_Tracker.UI
{
    public partial class ChartForm : Form
    {
        // Should be able to just bind the chart to the CovidVaccineTracker DataSet I dont know how the data would look tho
        // Will have to test it out
        // Also there is the Stats & StatsDB class to use the data stored procedures can use those if we must, to bind a stats obj
        // to the chart.
        public ChartForm()
        {
            InitializeComponent();
        }
    }
}
