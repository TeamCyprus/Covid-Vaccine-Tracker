
namespace Covid_Vaccine_Tracker.UI
{
    partial class ProviderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProviderForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MaintenanceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewPatientItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdatePatientItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VaccineRecordItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ErrorPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ExtractTxt = new System.Windows.Forms.TextBox();
            this.Race2Cbx = new System.Windows.Forms.ComboBox();
            this.patientGB = new System.Windows.Forms.GroupBox();
            this.ErrorLbl = new System.Windows.Forms.Label();
            this.DOBpicker = new System.Windows.Forms.DateTimePicker();
            this.StatesCbx = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SexCbx = new System.Windows.Forms.ComboBox();
            this.PatientIdTxt = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CountyTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.MnameTxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.EthnicityCbx = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Race1Cbx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ZipTxt = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CityTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StreetTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LnameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FnameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitBtn = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).BeginInit();
            this.patientGB.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MaintenanceItem,
            this.ViewItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(994, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MaintenanceItem
            // 
            this.MaintenanceItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewPatientItem,
            this.UpdatePatientItem,
            this.VaccineRecordItem});
            this.MaintenanceItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaintenanceItem.Name = "MaintenanceItem";
            this.MaintenanceItem.Size = new System.Drawing.Size(111, 24);
            this.MaintenanceItem.Text = "Maintenance";
            this.MaintenanceItem.ToolTipText = "Perform maintenance on patient or vaccine data";
            // 
            // NewPatientItem
            // 
            this.NewPatientItem.Name = "NewPatientItem";
            this.NewPatientItem.Size = new System.Drawing.Size(253, 26);
            this.NewPatientItem.Text = "Add New Patient";
            this.NewPatientItem.ToolTipText = "Add a new patient to the system";
            this.NewPatientItem.Click += new System.EventHandler(this.NewPatientItem_Click);
            // 
            // UpdatePatientItem
            // 
            this.UpdatePatientItem.Name = "UpdatePatientItem";
            this.UpdatePatientItem.Size = new System.Drawing.Size(253, 26);
            this.UpdatePatientItem.Text = "Update Patient";
            this.UpdatePatientItem.ToolTipText = "Update a existing patient\'s information";
            this.UpdatePatientItem.Click += new System.EventHandler(this.UpdatePatientItem_Click);
            // 
            // VaccineRecordItem
            // 
            this.VaccineRecordItem.Name = "VaccineRecordItem";
            this.VaccineRecordItem.Size = new System.Drawing.Size(253, 26);
            this.VaccineRecordItem.Text = "Add New Vaccine Record";
            this.VaccineRecordItem.ToolTipText = "Add a new vaccine for an existing patient";
            this.VaccineRecordItem.Click += new System.EventHandler(this.VaccineRecordItem_Click);
            // 
            // ViewItem
            // 
            this.ViewItem.Name = "ViewItem";
            this.ViewItem.Size = new System.Drawing.Size(56, 24);
            this.ViewItem.Text = "View";
            this.ViewItem.ToolTipText = "View Vaccine Records";
            this.ViewItem.Click += new System.EventHandler(this.ViewItem_Click);
            // 
            // ErrorPv
            // 
            this.ErrorPv.ContainerControl = this;
            this.ErrorPv.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorPv.Icon")));
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.LemonChiffon;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ExtractTxt
            // 
            this.ExtractTxt.Enabled = false;
            this.ExtractTxt.Location = new System.Drawing.Point(34, 69);
            this.ExtractTxt.Name = "ExtractTxt";
            this.ExtractTxt.ReadOnly = true;
            this.ExtractTxt.Size = new System.Drawing.Size(131, 24);
            this.ExtractTxt.TabIndex = 2;
            this.ExtractTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.ExtractTxt, "Specifies if record is Personaly Identifying");
            // 
            // Race2Cbx
            // 
            this.Race2Cbx.Enabled = false;
            this.Race2Cbx.FormattingEnabled = true;
            this.Race2Cbx.Location = new System.Drawing.Point(342, 236);
            this.Race2Cbx.Name = "Race2Cbx";
            this.Race2Cbx.Size = new System.Drawing.Size(284, 26);
            this.Race2Cbx.TabIndex = 27;
            this.toolTip1.SetToolTip(this.Race2Cbx, "Patient Race 2 is not required");
            // 
            // patientGB
            // 
            this.patientGB.BackColor = System.Drawing.SystemColors.Control;
            this.patientGB.Controls.Add(this.ErrorLbl);
            this.patientGB.Controls.Add(this.DOBpicker);
            this.patientGB.Controls.Add(this.StatesCbx);
            this.patientGB.Controls.Add(this.label15);
            this.patientGB.Controls.Add(this.SexCbx);
            this.patientGB.Controls.Add(this.PatientIdTxt);
            this.patientGB.Controls.Add(this.label11);
            this.patientGB.Controls.Add(this.CountyTxt);
            this.patientGB.Controls.Add(this.label14);
            this.patientGB.Controls.Add(this.ExtractTxt);
            this.patientGB.Controls.Add(this.label13);
            this.patientGB.Controls.Add(this.MnameTxt);
            this.patientGB.Controls.Add(this.label12);
            this.patientGB.Controls.Add(this.EthnicityCbx);
            this.patientGB.Controls.Add(this.label10);
            this.patientGB.Controls.Add(this.Race2Cbx);
            this.patientGB.Controls.Add(this.label9);
            this.patientGB.Controls.Add(this.Race1Cbx);
            this.patientGB.Controls.Add(this.label8);
            this.patientGB.Controls.Add(this.ZipTxt);
            this.patientGB.Controls.Add(this.label7);
            this.patientGB.Controls.Add(this.label6);
            this.patientGB.Controls.Add(this.CityTxt);
            this.patientGB.Controls.Add(this.label5);
            this.patientGB.Controls.Add(this.StreetTxt);
            this.patientGB.Controls.Add(this.label4);
            this.patientGB.Controls.Add(this.label3);
            this.patientGB.Controls.Add(this.LnameTxt);
            this.patientGB.Controls.Add(this.label2);
            this.patientGB.Controls.Add(this.FnameTxt);
            this.patientGB.Controls.Add(this.label1);
            this.patientGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientGB.Location = new System.Drawing.Point(26, 79);
            this.patientGB.Name = "patientGB";
            this.patientGB.Size = new System.Drawing.Size(943, 310);
            this.patientGB.TabIndex = 1;
            this.patientGB.TabStop = false;
            this.patientGB.Text = "Patient Information";
            this.patientGB.Visible = false;
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.Enabled = false;
            this.ErrorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLbl.ForeColor = System.Drawing.Color.Red;
            this.ErrorLbl.Location = new System.Drawing.Point(450, 48);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(493, 20);
            this.ErrorLbl.TabIndex = 30;
            this.ErrorLbl.Text = "This error lbl will only be seen if an error occurs with patient properties";
            this.ErrorLbl.Visible = false;
            // 
            // DOBpicker
            // 
            this.DOBpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DOBpicker.Location = new System.Drawing.Point(674, 126);
            this.DOBpicker.Name = "DOBpicker";
            this.DOBpicker.ShowUpDown = true;
            this.DOBpicker.Size = new System.Drawing.Size(112, 24);
            this.DOBpicker.TabIndex = 11;
            this.DOBpicker.Value = new System.DateTime(1960, 11, 19, 0, 0, 0, 0);
            // 
            // StatesCbx
            // 
            this.StatesCbx.Enabled = false;
            this.StatesCbx.FormattingEnabled = true;
            this.StatesCbx.Location = new System.Drawing.Point(766, 177);
            this.StatesCbx.Name = "StatesCbx";
            this.StatesCbx.Size = new System.Drawing.Size(62, 26);
            this.StatesCbx.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(810, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 18);
            this.label15.TabIndex = 12;
            this.label15.Text = "Sex";
            // 
            // SexCbx
            // 
            this.SexCbx.Enabled = false;
            this.SexCbx.FormattingEnabled = true;
            this.SexCbx.Location = new System.Drawing.Point(813, 124);
            this.SexCbx.Name = "SexCbx";
            this.SexCbx.Size = new System.Drawing.Size(92, 26);
            this.SexCbx.TabIndex = 13;
            // 
            // PatientIdTxt
            // 
            this.PatientIdTxt.Enabled = false;
            this.PatientIdTxt.Location = new System.Drawing.Point(208, 69);
            this.PatientIdTxt.Mask = "0000000LLL";
            this.PatientIdTxt.Name = "PatientIdTxt";
            this.PatientIdTxt.ReadOnly = true;
            this.PatientIdTxt.Size = new System.Drawing.Size(100, 24);
            this.PatientIdTxt.TabIndex = 3;
            this.PatientIdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(519, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 18);
            this.label11.TabIndex = 18;
            this.label11.Text = "County";
            // 
            // CountyTxt
            // 
            this.CountyTxt.Enabled = false;
            this.CountyTxt.Location = new System.Drawing.Point(522, 179);
            this.CountyTxt.Name = "CountyTxt";
            this.CountyTxt.Size = new System.Drawing.Size(225, 24);
            this.CountyTxt.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "Extract Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(227, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 18);
            this.label13.TabIndex = 6;
            this.label13.Text = "Middle name";
            // 
            // MnameTxt
            // 
            this.MnameTxt.Enabled = false;
            this.MnameTxt.Location = new System.Drawing.Point(230, 126);
            this.MnameTxt.Name = "MnameTxt";
            this.MnameTxt.Size = new System.Drawing.Size(196, 24);
            this.MnameTxt.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(647, 215);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 18);
            this.label12.TabIndex = 28;
            this.label12.Text = "Ethnicity";
            // 
            // EthnicityCbx
            // 
            this.EthnicityCbx.Enabled = false;
            this.EthnicityCbx.FormattingEnabled = true;
            this.EthnicityCbx.Location = new System.Drawing.Point(650, 236);
            this.EthnicityCbx.Name = "EthnicityCbx";
            this.EthnicityCbx.Size = new System.Drawing.Size(166, 26);
            this.EthnicityCbx.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "Race 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 18);
            this.label9.TabIndex = 24;
            this.label9.Text = "Race 1";
            // 
            // Race1Cbx
            // 
            this.Race1Cbx.Enabled = false;
            this.Race1Cbx.FormattingEnabled = true;
            this.Race1Cbx.Location = new System.Drawing.Point(34, 236);
            this.Race1Cbx.Name = "Race1Cbx";
            this.Race1Cbx.Size = new System.Drawing.Size(284, 26);
            this.Race1Cbx.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(844, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "Zipcode";
            // 
            // ZipTxt
            // 
            this.ZipTxt.Enabled = false;
            this.ZipTxt.Location = new System.Drawing.Point(847, 177);
            this.ZipTxt.Mask = "00000";
            this.ZipTxt.Name = "ZipTxt";
            this.ZipTxt.Size = new System.Drawing.Size(58, 24);
            this.ZipTxt.TabIndex = 23;
            this.ZipTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZipTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(763, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "State";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "City";
            // 
            // CityTxt
            // 
            this.CityTxt.Enabled = false;
            this.CityTxt.Location = new System.Drawing.Point(278, 179);
            this.CityTxt.Name = "CityTxt";
            this.CityTxt.Size = new System.Drawing.Size(225, 24);
            this.CityTxt.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Street Address";
            // 
            // StreetTxt
            // 
            this.StreetTxt.Enabled = false;
            this.StreetTxt.Location = new System.Drawing.Point(34, 179);
            this.StreetTxt.Name = "StreetTxt";
            this.StreetTxt.Size = new System.Drawing.Size(225, 24);
            this.StreetTxt.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(671, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date of Birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Last name";
            // 
            // LnameTxt
            // 
            this.LnameTxt.Enabled = false;
            this.LnameTxt.Location = new System.Drawing.Point(452, 126);
            this.LnameTxt.Name = "LnameTxt";
            this.LnameTxt.Size = new System.Drawing.Size(196, 24);
            this.LnameTxt.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "First name";
            // 
            // FnameTxt
            // 
            this.FnameTxt.Enabled = false;
            this.FnameTxt.Location = new System.Drawing.Point(34, 126);
            this.FnameTxt.Name = "FnameTxt";
            this.FnameTxt.Size = new System.Drawing.Size(170, 24);
            this.FnameTxt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient Id";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.toolStripSeparator1,
            this.UpdateBtn,
            this.toolStripSeparator2,
            this.ClearBtn,
            this.toolStripSeparator3,
            this.ExitBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(994, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
            this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(57, 24);
            this.AddBtn.Text = "Add";
            this.AddBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.AddBtn.ToolTipText = "Add patient";
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.Image = ((System.Drawing.Image)(resources.GetObject("UpdateBtn.Image")));
            this.UpdateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(78, 24);
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.UpdateBtn.ToolTipText = "Update patient";
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("ClearBtn.Image")));
            this.ClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(63, 24);
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ClearBtn.ToolTipText = "Clear form";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(53, 24);
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ExitBtn.ToolTipText = "Exit Application";
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(994, 413);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.patientGB);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ProviderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Portal";
            this.Load += new System.EventHandler(this.ProviderForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).EndInit();
            this.patientGB.ResumeLayout(false);
            this.patientGB.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceItem;
        private System.Windows.Forms.ToolStripMenuItem NewPatientItem;
        private System.Windows.Forms.ToolStripMenuItem VaccineRecordItem;
        private System.Windows.Forms.ToolStripMenuItem ViewItem;
        private System.Windows.Forms.ErrorProvider ErrorPv;
        private System.Windows.Forms.ToolStripMenuItem UpdatePatientItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox patientGB;
        private System.Windows.Forms.ComboBox StatesCbx;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox SexCbx;
        private System.Windows.Forms.MaskedTextBox PatientIdTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CountyTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox ExtractTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox MnameTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox EthnicityCbx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Race2Cbx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Race1Cbx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox ZipTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CityTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StreetTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LnameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FnameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DOBpicker;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton UpdateBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ClearBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExitBtn;
        private System.Windows.Forms.Label ErrorLbl;
    }
}