﻿namespace BioPrint.view
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textLicence = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelLicenceAndLibraries = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRepetierInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 158);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textLicence
            // 
            this.textLicence.Location = new System.Drawing.Point(16, 206);
            this.textLicence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textLicence.Multiline = true;
            this.textLicence.Name = "textLicence";
            this.textLicence.ReadOnly = true;
            this.textLicence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLicence.Size = new System.Drawing.Size(739, 293);
            this.textLicence.TabIndex = 1;
            this.textLicence.Text = resources.GetString("textLicence.Text");
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(336, 518);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 28);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelLicenceAndLibraries
            // 
            this.labelLicenceAndLibraries.AutoSize = true;
            this.labelLicenceAndLibraries.Location = new System.Drawing.Point(18, 181);
            this.labelLicenceAndLibraries.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLicenceAndLibraries.Name = "labelLicenceAndLibraries";
            this.labelLicenceAndLibraries.Size = new System.Drawing.Size(144, 17);
            this.labelLicenceAndLibraries.TabIndex = 3;
            this.labelLicenceAndLibraries.Text = "Licence and Libraries";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(196, 31);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(133, 17);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://duelaser.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "DUE BioPrint (C) 2018 - DUE Laser";
            // 
            // labelRepetierInfo
            // 
            this.labelRepetierInfo.Location = new System.Drawing.Point(200, 65);
            this.labelRepetierInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRepetierInfo.Name = "labelRepetierInfo";
            this.labelRepetierInfo.Size = new System.Drawing.Size(556, 108);
            this.labelRepetierInfo.TabIndex = 6;
            this.labelRepetierInfo.Text = "DUE BioPrint (C) 2018 - DUE Laser\r\nhttp://duelaser.com/\r\n\r\nThis Software was deve" +
    "loped to controll the 3D bioprint \"DUE BioPrint\"";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(772, 560);
            this.ControlBox = false;
            this.Controls.Add(this.labelRepetierInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.labelLicenceAndLibraries);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textLicence);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.Text = "About DUE BioPrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.About_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textLicence;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelLicenceAndLibraries;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelRepetierInfo;
    }
}