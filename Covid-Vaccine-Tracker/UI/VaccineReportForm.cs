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
    public partial class VaccineReportForm : Form
    {
        public VaccineReportForm()
        {
            InitializeComponent();
        }

        private void VaccineReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'newDataSet.Vaccine_Records' table. You can move, or remove it, as needed.
            this.vaccine_RecordsTableAdapter.Fill(this.newDataSet.Vaccine_Records);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
