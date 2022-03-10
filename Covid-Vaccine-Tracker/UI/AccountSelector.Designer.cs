
namespace Covid_Vaccine_Tracker.UI
{
    partial class AccountSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountSelector));
            this.AccountCbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vtckLbl = new System.Windows.Forms.Label();
            this.ErrorPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.VtckPinTxt = new System.Windows.Forms.MaskedTextBox();
            this.NextBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountCbx
            // 
            this.AccountCbx.FormattingEnabled = true;
            this.AccountCbx.Location = new System.Drawing.Point(130, 41);
            this.AccountCbx.Name = "AccountCbx";
            this.AccountCbx.Size = new System.Drawing.Size(217, 21);
            this.AccountCbx.TabIndex = 0;
            this.AccountCbx.SelectedIndexChanged += new System.EventHandler(this.AccountCbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Account Type";
            // 
            // vtckLbl
            // 
            this.vtckLbl.AutoSize = true;
            this.vtckLbl.Enabled = false;
            this.vtckLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vtckLbl.Location = new System.Drawing.Point(197, 65);
            this.vtckLbl.Name = "vtckLbl";
            this.vtckLbl.Size = new System.Drawing.Size(75, 20);
            this.vtckLbl.TabIndex = 3;
            this.vtckLbl.Text = "Vtcks Pin";
            this.vtckLbl.Visible = false;
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
            // VtckPinTxt
            // 
            this.VtckPinTxt.Enabled = false;
            this.VtckPinTxt.Location = new System.Drawing.Point(188, 88);
            this.VtckPinTxt.Mask = "0000LL";
            this.VtckPinTxt.Name = "VtckPinTxt";
            this.VtckPinTxt.ReadOnly = true;
            this.VtckPinTxt.Size = new System.Drawing.Size(93, 20);
            this.VtckPinTxt.TabIndex = 20;
            this.VtckPinTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VtckPinTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.toolTip1.SetToolTip(this.VtckPinTxt, "Administering provider\'s vticks pin");
            this.VtckPinTxt.Visible = false;
            // 
            // NextBtn
            // 
            this.NextBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextBtn.Location = new System.Drawing.Point(176, 126);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(123, 34);
            this.NextBtn.TabIndex = 4;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // AccountSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(475, 172);
            this.Controls.Add(this.VtckPinTxt);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.vtckLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AccountCbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Creator";
            this.Load += new System.EventHandler(this.AccountSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AccountCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label vtckLbl;
        private System.Windows.Forms.ErrorProvider ErrorPv;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MaskedTextBox VtckPinTxt;
    }
}