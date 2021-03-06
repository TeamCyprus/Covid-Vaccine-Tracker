
namespace Covid_Vaccine_Tracker.UI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateAccountLbl = new System.Windows.Forms.Label();
            this.ErrorPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.PwdRecoveryBtn = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.UsrRecoverBtn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.LoginBtn.Location = new System.Drawing.Point(247, 251);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(115, 37);
            this.LoginBtn.TabIndex = 2;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.PasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.PasswordTxt.Location = new System.Drawing.Point(127, 104);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(162, 26);
            this.PasswordTxt.TabIndex = 1;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.UsernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.UsernameTxt.Location = new System.Drawing.Point(127, 52);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(162, 26);
            this.UsernameTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(123, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(123, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // CreateAccountLbl
            // 
            this.CreateAccountLbl.AutoSize = true;
            this.CreateAccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccountLbl.ForeColor = System.Drawing.Color.Yellow;
            this.CreateAccountLbl.Location = new System.Drawing.Point(160, 133);
            this.CreateAccountLbl.Name = "CreateAccountLbl";
            this.CreateAccountLbl.Size = new System.Drawing.Size(167, 16);
            this.CreateAccountLbl.TabIndex = 2;
            this.CreateAccountLbl.Text = "Create Account, Click Here";
            this.CreateAccountLbl.Click += new System.EventHandler(this.CreateAccountLbl_Click);
            // 
            // ErrorPv
            // 
            this.ErrorPv.ContainerControl = this;
            this.ErrorPv.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorPv.Icon")));
            // 
            // PwdRecoveryBtn
            // 
            this.PwdRecoveryBtn.AutoSize = true;
            this.PwdRecoveryBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PwdRecoveryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.PwdRecoveryBtn.Location = new System.Drawing.Point(248, 291);
            this.PwdRecoveryBtn.Name = "PwdRecoveryBtn";
            this.PwdRecoveryBtn.Size = new System.Drawing.Size(110, 16);
            this.PwdRecoveryBtn.TabIndex = 1;
            this.PwdRecoveryBtn.Text = "Forgot Password";
            this.PwdRecoveryBtn.Click += new System.EventHandler(this.ForgotPwdLbl_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.groupBox1.Controls.Add(this.UsernameTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CreateAccountLbl);
            this.groupBox1.Controls.Add(this.PasswordTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(69, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 179);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.toolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // UsrRecoverBtn
            // 
            this.UsrRecoverBtn.AutoSize = true;
            this.UsrRecoverBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrRecoverBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(85)))), ((int)(((byte)(35)))));
            this.UsrRecoverBtn.Location = new System.Drawing.Point(248, 308);
            this.UsrRecoverBtn.Name = "UsrRecoverBtn";
            this.UsrRecoverBtn.Size = new System.Drawing.Size(113, 16);
            this.UsrRecoverBtn.TabIndex = 9;
            this.UsrRecoverBtn.Text = "Forgot Username";
            this.UsrRecoverBtn.Click += new System.EventHandler(this.UsrRecoverBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(608, 332);
            this.Controls.Add(this.UsrRecoverBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PwdRecoveryBtn);
            this.Controls.Add(this.LoginBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(624, 371);
            this.MinimumSize = new System.Drawing.Size(624, 371);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CreateAccountLbl;
        private System.Windows.Forms.ErrorProvider ErrorPv;
        private System.Windows.Forms.Label PwdRecoveryBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label UsrRecoverBtn;
        private System.Windows.Forms.Label label3;
    }
}