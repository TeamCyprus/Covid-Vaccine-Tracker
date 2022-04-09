
namespace Covid_Vaccine_Tracker.UI
{
    partial class VaccineReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.newDataSet = new Covid_Vaccine_Tracker.NewDataSet();
            this.vaccineRecordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vaccine_RecordsTableAdapter = new Covid_Vaccine_Tracker.NewDataSetTableAdapters.Vaccine_RecordsTableAdapter();
            this.vaccineRecordsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.vaccineRecordsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineRecordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineRecordsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineRecordsBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Again";
            reportDataSource1.Value = this.vaccineRecordsBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Covid_Vaccine_Tracker.UI.Rpt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1445, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // newDataSet
            // 
            this.newDataSet.DataSetName = "NewDataSet";
            this.newDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vaccineRecordsBindingSource
            // 
            this.vaccineRecordsBindingSource.DataMember = "Vaccine_Records";
            this.vaccineRecordsBindingSource.DataSource = this.newDataSet;
            // 
            // vaccine_RecordsTableAdapter
            // 
            this.vaccine_RecordsTableAdapter.ClearBeforeFill = true;
            // 
            // vaccineRecordsBindingSource1
            // 
            this.vaccineRecordsBindingSource1.DataMember = "Vaccine_Records";
            this.vaccineRecordsBindingSource1.DataSource = this.newDataSet;
            // 
            // vaccineRecordsBindingSource2
            // 
            this.vaccineRecordsBindingSource2.DataMember = "Vaccine_Records";
            this.vaccineRecordsBindingSource2.DataSource = this.newDataSet;
            // 
            // VaccineReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VaccineReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VaccineReportForm";
            this.Load += new System.EventHandler(this.VaccineReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineRecordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineRecordsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vaccineRecordsBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private NewDataSet newDataSet;
        private System.Windows.Forms.BindingSource vaccineRecordsBindingSource;
        private NewDataSetTableAdapters.Vaccine_RecordsTableAdapter vaccine_RecordsTableAdapter;
        private System.Windows.Forms.BindingSource vaccineRecordsBindingSource1;
        private System.Windows.Forms.BindingSource vaccineRecordsBindingSource2;
    }
}