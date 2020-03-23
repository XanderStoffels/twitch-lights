namespace TwitchLights.WinForm
{
    partial class FrmHandshake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHandshake));
            this.ptbBanner = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.ptbLink = new System.Windows.Forms.PictureBox();
            this.btnPressed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLink)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbBanner
            // 
            this.ptbBanner.Image = ((System.Drawing.Image)(resources.GetObject("ptbBanner.Image")));
            this.ptbBanner.Location = new System.Drawing.Point(-169, -1);
            this.ptbBanner.Name = "ptbBanner";
            this.ptbBanner.Size = new System.Drawing.Size(349, 366);
            this.ptbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbBanner.TabIndex = 0;
            this.ptbBanner.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(200, 28);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(192, 41);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Connecting...";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(200, 88);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(320, 60);
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = "Please press the Bridge Button™ on the Bridge \r\nto allow the Twitch Lights to pai" +
    "r and interact\r\nwith the Lights.";
            this.lblInstructions.Visible = false;
            // 
            // ptbLink
            // 
            this.ptbLink.BackColor = System.Drawing.Color.Transparent;
            this.ptbLink.Image = ((System.Drawing.Image)(resources.GetObject("ptbLink.Image")));
            this.ptbLink.Location = new System.Drawing.Point(200, 170);
            this.ptbLink.Name = "ptbLink";
            this.ptbLink.Size = new System.Drawing.Size(175, 170);
            this.ptbLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbLink.TabIndex = 3;
            this.ptbLink.TabStop = false;
            this.ptbLink.Visible = false;
            // 
            // btnPressed
            // 
            this.btnPressed.Location = new System.Drawing.Point(390, 311);
            this.btnPressed.Name = "btnPressed";
            this.btnPressed.Size = new System.Drawing.Size(166, 29);
            this.btnPressed.TabIndex = 4;
            this.btnPressed.Text = "I pressed it!";
            this.btnPressed.UseVisualStyleBackColor = true;
            this.btnPressed.Visible = false;
            this.btnPressed.Click += new System.EventHandler(this.btnPressed_Click);
            // 
            // FrmHandshake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 363);
            this.Controls.Add(this.btnPressed);
            this.Controls.Add(this.ptbLink);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ptbBanner);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(586, 410);
            this.MinimumSize = new System.Drawing.Size(586, 410);
            this.Name = "FrmHandshake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch Lights";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHandshake_FormClosing);
            this.Load += new System.EventHandler(this.FrmHandshake_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbBanner;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.PictureBox ptbLink;
        private System.Windows.Forms.Button btnPressed;
    }
}