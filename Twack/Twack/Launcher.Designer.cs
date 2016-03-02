namespace Twack
{
    partial class Launcher
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbPlay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbArt2 = new System.Windows.Forms.PictureBox();
            this.pbArt0 = new System.Windows.Forms.PictureBox();
            this.pbArt4 = new System.Windows.Forms.PictureBox();
            this.pbArt1 = new System.Windows.Forms.PictureBox();
            this.pbArt3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("HelveticaNeueLT Com 107 XBlkCn", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 79);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Twack!";
            // 
            // pbPlay
            // 
            this.pbPlay.AutoSize = true;
            this.pbPlay.BackColor = System.Drawing.Color.Transparent;
            this.pbPlay.Font = new System.Drawing.Font("HelveticaNeueLT Com 107 XBlkCn", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbPlay.Location = new System.Drawing.Point(12, 140);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(147, 30);
            this.pbPlay.TabIndex = 1;
            this.pbPlay.Text = "START GAME!";
            this.pbPlay.Click += new System.EventHandler(this.pbPlay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("HelveticaNeueLT Com 107 XBlkCn", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "CREDITS!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pbArt2
            // 
            this.pbArt2.BackColor = System.Drawing.Color.Lime;
            this.pbArt2.Location = new System.Drawing.Point(366, 64);
            this.pbArt2.Name = "pbArt2";
            this.pbArt2.Size = new System.Drawing.Size(50, 50);
            this.pbArt2.TabIndex = 7;
            this.pbArt2.TabStop = false;
            // 
            // pbArt0
            // 
            this.pbArt0.BackColor = System.Drawing.Color.Orange;
            this.pbArt0.Location = new System.Drawing.Point(268, 64);
            this.pbArt0.Name = "pbArt0";
            this.pbArt0.Size = new System.Drawing.Size(50, 50);
            this.pbArt0.TabIndex = 6;
            this.pbArt0.TabStop = false;
            // 
            // pbArt4
            // 
            this.pbArt4.BackColor = System.Drawing.Color.DodgerBlue;
            this.pbArt4.Location = new System.Drawing.Point(317, 162);
            this.pbArt4.Name = "pbArt4";
            this.pbArt4.Size = new System.Drawing.Size(50, 50);
            this.pbArt4.TabIndex = 5;
            this.pbArt4.TabStop = false;
            // 
            // pbArt1
            // 
            this.pbArt1.BackColor = System.Drawing.Color.Aqua;
            this.pbArt1.Location = new System.Drawing.Point(317, 64);
            this.pbArt1.Name = "pbArt1";
            this.pbArt1.Size = new System.Drawing.Size(50, 50);
            this.pbArt1.TabIndex = 3;
            this.pbArt1.TabStop = false;
            // 
            // pbArt3
            // 
            this.pbArt3.BackColor = System.Drawing.Color.Red;
            this.pbArt3.Location = new System.Drawing.Point(317, 113);
            this.pbArt3.Name = "pbArt3";
            this.pbArt3.Size = new System.Drawing.Size(50, 50);
            this.pbArt3.TabIndex = 2;
            this.pbArt3.TabStop = false;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(429, 225);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbArt2);
            this.Controls.Add(this.pbArt0);
            this.Controls.Add(this.pbArt4);
            this.Controls.Add(this.pbArt1);
            this.Controls.Add(this.pbArt3);
            this.Controls.Add(this.pbPlay);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Launcher";
            this.Text = "Twack!";
            ((System.ComponentModel.ISupportInitialize)(this.pbArt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArt3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label pbPlay;
        private System.Windows.Forms.PictureBox pbArt3;
        private System.Windows.Forms.PictureBox pbArt1;
        private System.Windows.Forms.PictureBox pbArt4;
        private System.Windows.Forms.PictureBox pbArt0;
        private System.Windows.Forms.PictureBox pbArt2;
        private System.Windows.Forms.Label label1;
    }
}

