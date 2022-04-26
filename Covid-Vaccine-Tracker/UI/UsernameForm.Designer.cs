
namespace Covid_Vaccine_Tracker.UI
{
    partial class UsernameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsernameForm));
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.UncoverBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Location = new System.Drawing.Point(73, 36);
            this.UsernameTxt.Multiline = true;
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(276, 39);
            this.UsernameTxt.TabIndex = 0;
            this.UsernameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UncoverBtn
            // 
            this.UncoverBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.UncoverBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UncoverBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.UncoverBtn.Location = new System.Drawing.Point(63, 127);
            this.UncoverBtn.Name = "UncoverBtn";
            this.UncoverBtn.Size = new System.Drawing.Size(126, 31);
            this.UncoverBtn.TabIndex = 1;
            this.UncoverBtn.Text = "Uncover";
            this.UncoverBtn.UseVisualStyleBackColor = false;
            this.UncoverBtn.Click += new System.EventHandler(this.UncoverBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.ExitBtn.Location = new System.Drawing.Point(257, 127);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(126, 31);
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(130, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Your username is:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(104)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.UsernameTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 100);
            this.panel1.TabIndex = 4;
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // UsernameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(447, 166);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.UncoverBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UsernameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Username Recovery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UsernameForm_FormClosing);
            this.Load += new System.EventHandler(this.UsernameForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.Button UncoverBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer Timer;
    }
}