namespace TwitchLights.WinForm
{
    partial class FrmStartup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStartup));
            this.ptbWelcome = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescribtion = new System.Windows.Forms.Label();
            this.lblProcessTime = new System.Windows.Forms.Label();
            this.lbBridges = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbWelcome
            // 
            this.ptbWelcome.Image = ((System.Drawing.Image)(resources.GetObject("ptbWelcome.Image")));
            this.ptbWelcome.Location = new System.Drawing.Point(-169, -1);
            this.ptbWelcome.Name = "ptbWelcome";
            this.ptbWelcome.Size = new System.Drawing.Size(349, 366);
            this.ptbWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbWelcome.TabIndex = 0;
            this.ptbWelcome.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(186, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(299, 41);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Looking for bridges...";
            // 
            // lblDescribtion
            // 
            this.lblDescribtion.AutoSize = true;
            this.lblDescribtion.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDescribtion.Location = new System.Drawing.Point(192, 77);
            this.lblDescribtion.Name = "lblDescribtion";
            this.lblDescribtion.Size = new System.Drawing.Size(364, 60);
            this.lblDescribtion.TabIndex = 2;
            this.lblDescribtion.Text = "The application is now scanning your network for Hue\r\nBridges™. A firewall warnin" +
    "g might pop up. Please\r\nallow this application to scan the network.\r\n";
            // 
            // lblProcessTime
            // 
            this.lblProcessTime.AutoSize = true;
            this.lblProcessTime.Location = new System.Drawing.Point(192, 168);
            this.lblProcessTime.Name = "lblProcessTime";
            this.lblProcessTime.Size = new System.Drawing.Size(227, 20);
            this.lblProcessTime.TabIndex = 4;
            this.lblProcessTime.Text = "This could take up to 10 seconds.";
            // 
            // lbBridges
            // 
            this.lbBridges.Enabled = false;
            this.lbBridges.FormattingEnabled = true;
            this.lbBridges.ItemHeight = 20;
            this.lbBridges.Location = new System.Drawing.Point(192, 203);
            this.lbBridges.Name = "lbBridges";
            this.lbBridges.Size = new System.Drawing.Size(227, 124);
            this.lbBridges.TabIndex = 5;
            this.lbBridges.Visible = false;
            this.lbBridges.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbBridges_MouseDoubleClick);
            // 
            // FrmStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 363);
            this.Controls.Add(this.lbBridges);
            this.Controls.Add(this.lblProcessTime);
            this.Controls.Add(this.lblDescribtion);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ptbWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(586, 410);
            this.MinimumSize = new System.Drawing.Size(586, 410);
            this.Name = "FrmStartup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch Lights";
            this.Load += new System.EventHandler(this.FormStartup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbWelcome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescribtion;
        private System.Windows.Forms.Label lblProcessTime;
        private System.Windows.Forms.ListBox lbBridges;
    }
}

