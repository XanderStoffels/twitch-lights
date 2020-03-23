namespace TwitchLights.WinForm
{
    partial class FrmLightSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLightSetup));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lbLights = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-169, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 366);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(200, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Light selection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the lights Twitch chat will be able \r\nto control.";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(462, 307);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(94, 29);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Ok";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lbLights
            // 
            this.lbLights.FormattingEnabled = true;
            this.lbLights.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbLights.ItemHeight = 20;
            this.lbLights.Location = new System.Drawing.Point(200, 132);
            this.lbLights.Name = "lbLights";
            this.lbLights.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbLights.Size = new System.Drawing.Size(256, 204);
            this.lbLights.TabIndex = 5;
            // 
            // FrmLightSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 363);
            this.Controls.Add(this.lbLights);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(586, 410);
            this.MinimumSize = new System.Drawing.Size(586, 410);
            this.Name = "FrmLightSetup";
            this.Text = "Twitch Lights";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLightSetup_FormClosing);
            this.Load += new System.EventHandler(this.FrmLightSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lbLights;
    }
}