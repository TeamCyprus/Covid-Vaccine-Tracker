
namespace Covid_Vaccine_Tracker.UI
{
    partial class UpdateAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAccountForm));
            this.PasswordRecovPanel = new System.Windows.Forms.Panel();
            this.InputLbl2 = new System.Windows.Forms.Label();
            this.PwdVerifyTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.InputLbl1 = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.UsernameRecovPanel = new System.Windows.Forms.Panel();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.UsrLbl = new System.Windows.Forms.Label();
            this.ErrorPv = new System.Windows.Forms.ErrorProvider(this.components);
            this.PasswordRecovPanel.SuspendLayout();
            this.UsernameRecovPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordRecovPanel
            // 
            this.PasswordRecovPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.PasswordRecovPanel.Controls.Add(this.InputLbl2);
            this.PasswordRecovPanel.Controls.Add(this.PwdVerifyTxt);
            this.PasswordRecovPanel.Controls.Add(this.PasswordTxt);
            this.PasswordRecovPanel.Controls.Add(this.InputLbl1);
            this.PasswordRecovPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.PasswordRecovPanel.Location = new System.Drawing.Point(67, 30);
            this.PasswordRecovPanel.Name = "PasswordRecovPanel";
            this.PasswordRecovPanel.Size = new System.Drawing.Size(484, 137);
            this.PasswordRecovPanel.TabIndex = 3;
            // 
            // InputLbl2
            // 
            this.InputLbl2.AutoSize = true;
            this.InputLbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLbl2.Location = new System.Drawing.Point(100, 70);
            this.InputLbl2.Name = "InputLbl2";
            this.InputLbl2.Size = new System.Drawing.Size(115, 18);
            this.InputLbl2.TabIndex = 3;
            this.InputLbl2.Text = "Verify Password";
            // 
            // PwdVerifyTxt
            // 
            this.PwdVerifyTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PwdVerifyTxt.Location = new System.Drawing.Point(105, 91);
            this.PwdVerifyTxt.Name = "PwdVerifyTxt";
            this.PwdVerifyTxt.Size = new System.Drawing.Size(277, 24);
            this.PwdVerifyTxt.TabIndex = 2;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTxt.Location = new System.Drawing.Point(103, 35);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(279, 24);
            this.PasswordTxt.TabIndex = 1;
            // 
            // InputLbl1
            // 
            this.InputLbl1.AutoSize = true;
            this.InputLbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLbl1.Location = new System.Drawing.Point(100, 14);
            this.InputLbl1.Name = "InputLbl1";
            this.InputLbl1.Size = new System.Drawing.Size(109, 18);
            this.InputLbl1.TabIndex = 0;
            this.InputLbl1.Text = "New Password";
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.ClearBtn.Location = new System.Drawing.Point(114, 201);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(174, 32);
            this.ClearBtn.TabIndex = 7;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.SubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.SubmitBtn.Location = new System.Drawing.Point(331, 201);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(174, 32);
            this.SubmitBtn.TabIndex = 8;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // UsernameRecovPanel
            // 
            this.UsernameRecovPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.UsernameRecovPanel.Controls.Add(this.UsernameTxt);
            this.UsernameRecovPanel.Controls.Add(this.UsrLbl);
            this.UsernameRecovPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.UsernameRecovPanel.Location = new System.Drawing.Point(67, 30);
            this.UsernameRecovPanel.Name = "UsernameRecovPanel";
            this.UsernameRecovPanel.Size = new System.Drawing.Size(484, 137);
            this.UsernameRecovPanel.TabIndex = 4;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.UsernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.UsernameTxt.Location = new System.Drawing.Point(157, 67);
            this.UsernameTxt.Multiline = true;
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(168, 29);
            this.UsernameTxt.TabIndex = 1;
            this.UsernameTxt.Text = "username goes here";
            this.UsernameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UsrLbl
            // 
            this.UsrLbl.AutoSize = true;
            this.UsrLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsrLbl.Location = new System.Drawing.Point(177, 32);
            this.UsrLbl.Name = "UsrLbl";
            this.UsrLbl.Size = new System.Drawing.Size(124, 18);
            this.UsrLbl.TabIndex = 0;
            this.UsrLbl.Text = "Your username is";
            // 
            // ErrorPv
            // 
            this.ErrorPv.ContainerControl = this;
            this.ErrorPv.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorPv.Icon")));
            // 
            // UpdateAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(619, 245);
            this.Controls.Add(this.UsernameRecovPanel);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.PasswordRecovPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Account Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateAccountForm_FormClosing);
            this.Load += new System.EventHandler(this.UpdateAccountForm_Load);
            this.PasswordRecovPanel.ResumeLayout(false);
            this.PasswordRecovPanel.PerformLayout();
            this.UsernameRecovPanel.ResumeLayout(false);
            this.UsernameRecovPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PasswordRecovPanel;
        private System.Windows.Forms.Label InputLbl2;
        private System.Windows.Forms.TextBox PwdVerifyTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.Label InputLbl1;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Panel UsernameRecovPanel;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.Label UsrLbl;
        private System.Windows.Forms.ErrorProvider ErrorPv;
    }
}