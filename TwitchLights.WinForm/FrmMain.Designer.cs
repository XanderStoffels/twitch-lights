namespace TwitchLights.WinForm
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRoutines = new System.Windows.Forms.CheckBox();
            this.cbAlerts = new System.Windows.Forms.CheckBox();
            this.cbSubOnly = new System.Windows.Forms.CheckBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.lbCommands = new System.Windows.Forms.ListBox();
            this.ptbStatus = new System.Windows.Forms.PictureBox();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHealthCheck = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbRoutines);
            this.panel1.Controls.Add(this.cbAlerts);
            this.panel1.Controls.Add(this.cbSubOnly);
            this.panel1.Controls.Add(this.cbEnabled);
            this.panel1.Location = new System.Drawing.Point(12, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 185);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Options";
            // 
            // cbRoutines
            // 
            this.cbRoutines.AutoSize = true;
            this.cbRoutines.Enabled = false;
            this.cbRoutines.Location = new System.Drawing.Point(53, 134);
            this.cbRoutines.Name = "cbRoutines";
            this.cbRoutines.Size = new System.Drawing.Size(136, 24);
            this.cbRoutines.TabIndex = 1;
            this.cbRoutines.Text = "Special routines";
            this.cbRoutines.UseVisualStyleBackColor = true;
            // 
            // cbAlerts
            // 
            this.cbAlerts.AutoSize = true;
            this.cbAlerts.Enabled = false;
            this.cbAlerts.Location = new System.Drawing.Point(53, 104);
            this.cbAlerts.Name = "cbAlerts";
            this.cbAlerts.Size = new System.Drawing.Size(121, 24);
            this.cbAlerts.TabIndex = 1;
            this.cbAlerts.Text = "Alert reaction";
            this.cbAlerts.UseVisualStyleBackColor = true;
            // 
            // cbSubOnly
            // 
            this.cbSubOnly.AutoSize = true;
            this.cbSubOnly.Location = new System.Drawing.Point(53, 74);
            this.cbSubOnly.Name = "cbSubOnly";
            this.cbSubOnly.Size = new System.Drawing.Size(133, 24);
            this.cbSubOnly.TabIndex = 1;
            this.cbSubOnly.Text = "Sub Only mode";
            this.cbSubOnly.UseVisualStyleBackColor = true;
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Checked = true;
            this.cbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnabled.Location = new System.Drawing.Point(53, 44);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(85, 24);
            this.cbEnabled.TabIndex = 1;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // lbCommands
            // 
            this.lbCommands.FormattingEnabled = true;
            this.lbCommands.ItemHeight = 20;
            this.lbCommands.Location = new System.Drawing.Point(300, 11);
            this.lbCommands.Name = "lbCommands";
            this.lbCommands.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbCommands.Size = new System.Drawing.Size(294, 424);
            this.lbCommands.TabIndex = 1;
            // 
            // ptbStatus
            // 
            this.ptbStatus.Image = ((System.Drawing.Image)(resources.GetObject("ptbStatus.Image")));
            this.ptbStatus.Location = new System.Drawing.Point(199, 11);
            this.ptbStatus.Name = "ptbStatus";
            this.ptbStatus.Size = new System.Drawing.Size(95, 105);
            this.ptbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbStatus.TabIndex = 2;
            this.ptbStatus.TabStop = false;
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblStatusTitle.Location = new System.Drawing.Point(32, 11);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(52, 20);
            this.lblStatusTitle.TabIndex = 3;
            this.lblStatusTitle.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(32, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(93, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Connecting...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(12, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Latest KeepAlive:";
            // 
            // lblHealthCheck
            // 
            this.lblHealthCheck.AutoSize = true;
            this.lblHealthCheck.ForeColor = System.Drawing.Color.Silver;
            this.lblHealthCheck.Location = new System.Drawing.Point(137, 438);
            this.lblHealthCheck.Name = "lblHealthCheck";
            this.lblHealthCheck.Size = new System.Drawing.Size(45, 20);
            this.lblHealthCheck.TabIndex = 6;
            this.lblHealthCheck.Text = "None";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 465);
            this.Controls.Add(this.lblHealthCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblStatusTitle);
            this.Controls.Add(this.ptbStatus);
            this.Controls.Add(this.lbCommands);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Text = "Twitch Lights";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbCommands;
        private System.Windows.Forms.CheckBox cbSubOnly;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbRoutines;
        private System.Windows.Forms.CheckBox cbAlerts;
        private System.Windows.Forms.PictureBox ptbStatus;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHealthCheck;
    }
}