namespace RepetierHost.view
{
    partial class Slic3rSettings
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pagePrint = new System.Windows.Forms.TabPage();
            this.tlpPrint = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPrintSettingsCategories = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tlpLayers = new System.Windows.Forms.TableLayoutPanel();
            this.gbAdvanced = new System.Windows.Forms.GroupBox();
            this.cbExternalPerimetersFirst = new System.Windows.Forms.CheckBox();
            this.cboxSeamPosition = new System.Windows.Forms.ComboBox();
            this.lblSeamPosition = new System.Windows.Forms.Label();
            this.gbQuality = new System.Windows.Forms.GroupBox();
            this.cbOverhangs = new System.Windows.Forms.CheckBox();
            this.cbThinWalls = new System.Windows.Forms.CheckBox();
            this.cbAvoidCrossingPerimeters = new System.Windows.Forms.CheckBox();
            this.cbExtraPerimetersfNeeded = new System.Windows.Forms.CheckBox();
            this.gbHorizontalShells = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nbBottomSolidLayers = new System.Windows.Forms.NumericUpDown();
            this.nbTopSolidLayers = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSolidLayers = new System.Windows.Forms.Label();
            this.gbVerticalShells = new System.Windows.Forms.GroupBox();
            this.cbSpiralVase = new System.Windows.Forms.CheckBox();
            this.nbPerimeters = new System.Windows.Forms.NumericUpDown();
            this.lblPerimeters = new System.Windows.Forms.Label();
            this.gbLayerHeight = new System.Windows.Forms.GroupBox();
            this.lblFirstLayerHeightMmOrPercent = new System.Windows.Forms.Label();
            this.lblLayerHeightMm = new System.Windows.Forms.Label();
            this.lblFirstLayerHeight = new System.Windows.Forms.Label();
            this.tbFirstLayerHeight = new System.Windows.Forms.TextBox();
            this.tbLayerHeight = new System.Windows.Forms.TextBox();
            this.lblLayerHeight = new System.Windows.Forms.Label();
            this.pageFilament = new System.Windows.Forms.TabPage();
            this.pagePrinter = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.pagePrint.SuspendLayout();
            this.tlpPrint.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpLayers.SuspendLayout();
            this.gbAdvanced.SuspendLayout();
            this.gbQuality.SuspendLayout();
            this.gbHorizontalShells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbBottomSolidLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbTopSolidLayers)).BeginInit();
            this.gbVerticalShells.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbPerimeters)).BeginInit();
            this.gbLayerHeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pagePrint);
            this.tabControl.Controls.Add(this.pageFilament);
            this.tabControl.Controls.Add(this.pagePrinter);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 656);
            this.tabControl.TabIndex = 0;
            // 
            // pagePrint
            // 
            this.pagePrint.Controls.Add(this.tlpPrint);
            this.pagePrint.Location = new System.Drawing.Point(4, 22);
            this.pagePrint.Name = "pagePrint";
            this.pagePrint.Padding = new System.Windows.Forms.Padding(3);
            this.pagePrint.Size = new System.Drawing.Size(792, 630);
            this.pagePrint.TabIndex = 0;
            this.pagePrint.Text = "Print Settings";
            this.pagePrint.UseVisualStyleBackColor = true;
            // 
            // tlpPrint
            // 
            this.tlpPrint.ColumnCount = 2;
            this.tlpPrint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpPrint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrint.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpPrint.Controls.Add(this.tlpLayers, 1, 0);
            this.tlpPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrint.Location = new System.Drawing.Point(3, 3);
            this.tlpPrint.Name = "tlpPrint";
            this.tlpPrint.RowCount = 1;
            this.tlpPrint.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrint.Size = new System.Drawing.Size(786, 624);
            this.tlpPrint.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbPrintSettingsCategories, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 618);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbPrintSettingsCategories
            // 
            this.lbPrintSettingsCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPrintSettingsCategories.FormattingEnabled = true;
            this.lbPrintSettingsCategories.Items.AddRange(new object[] {
            "Layers and perimeters",
            "Infill",
            "Skirt and brim",
            "Support Material",
            "Speed",
            "Multiple Extruders",
            "Advanced",
            "Output options",
            "Notes"});
            this.lbPrintSettingsCategories.Location = new System.Drawing.Point(3, 43);
            this.lbPrintSettingsCategories.Name = "lbPrintSettingsCategories";
            this.lbPrintSettingsCategories.Size = new System.Drawing.Size(238, 572);
            this.lbPrintSettingsCategories.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tlpLayers
            // 
            this.tlpLayers.ColumnCount = 1;
            this.tlpLayers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayers.Controls.Add(this.gbAdvanced, 0, 4);
            this.tlpLayers.Controls.Add(this.gbQuality, 0, 3);
            this.tlpLayers.Controls.Add(this.gbHorizontalShells, 0, 2);
            this.tlpLayers.Controls.Add(this.gbVerticalShells, 0, 1);
            this.tlpLayers.Controls.Add(this.gbLayerHeight, 0, 0);
            this.tlpLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayers.Location = new System.Drawing.Point(253, 3);
            this.tlpLayers.Name = "tlpLayers";
            this.tlpLayers.RowCount = 6;
            this.tlpLayers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLayers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLayers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLayers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLayers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLayers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLayers.Size = new System.Drawing.Size(530, 618);
            this.tlpLayers.TabIndex = 1;
            // 
            // gbAdvanced
            // 
            this.gbAdvanced.Controls.Add(this.cbExternalPerimetersFirst);
            this.gbAdvanced.Controls.Add(this.cboxSeamPosition);
            this.gbAdvanced.Controls.Add(this.lblSeamPosition);
            this.gbAdvanced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAdvanced.Location = new System.Drawing.Point(3, 347);
            this.gbAdvanced.Name = "gbAdvanced";
            this.gbAdvanced.Size = new System.Drawing.Size(524, 80);
            this.gbAdvanced.TabIndex = 4;
            this.gbAdvanced.TabStop = false;
            this.gbAdvanced.Text = "Advanced";
            // 
            // cbExternalPerimetersFirst
            // 
            this.cbExternalPerimetersFirst.AutoSize = true;
            this.cbExternalPerimetersFirst.Location = new System.Drawing.Point(191, 46);
            this.cbExternalPerimetersFirst.Name = "cbExternalPerimetersFirst";
            this.cbExternalPerimetersFirst.Size = new System.Drawing.Size(134, 17);
            this.cbExternalPerimetersFirst.TabIndex = 8;
            this.cbExternalPerimetersFirst.Text = "External perimeters first";
            this.cbExternalPerimetersFirst.UseVisualStyleBackColor = true;
            // 
            // cboxSeamPosition
            // 
            this.cboxSeamPosition.FormattingEnabled = true;
            this.cboxSeamPosition.Location = new System.Drawing.Point(10, 44);
            this.cboxSeamPosition.Name = "cboxSeamPosition";
            this.cboxSeamPosition.Size = new System.Drawing.Size(121, 21);
            this.cboxSeamPosition.TabIndex = 6;
            // 
            // lblSeamPosition
            // 
            this.lblSeamPosition.AutoSize = true;
            this.lblSeamPosition.Location = new System.Drawing.Point(7, 28);
            this.lblSeamPosition.Name = "lblSeamPosition";
            this.lblSeamPosition.Size = new System.Drawing.Size(73, 13);
            this.lblSeamPosition.TabIndex = 0;
            this.lblSeamPosition.Text = "Seam position";
            // 
            // gbQuality
            // 
            this.gbQuality.Controls.Add(this.cbOverhangs);
            this.gbQuality.Controls.Add(this.cbThinWalls);
            this.gbQuality.Controls.Add(this.cbAvoidCrossingPerimeters);
            this.gbQuality.Controls.Add(this.cbExtraPerimetersfNeeded);
            this.gbQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQuality.Location = new System.Drawing.Point(3, 261);
            this.gbQuality.Name = "gbQuality";
            this.gbQuality.Size = new System.Drawing.Size(524, 80);
            this.gbQuality.TabIndex = 3;
            this.gbQuality.TabStop = false;
            this.gbQuality.Text = "Quality (slower slicing)";
            // 
            // cbOverhangs
            // 
            this.cbOverhangs.AutoSize = true;
            this.cbOverhangs.Location = new System.Drawing.Point(191, 51);
            this.cbOverhangs.Name = "cbOverhangs";
            this.cbOverhangs.Size = new System.Drawing.Size(149, 17);
            this.cbOverhangs.TabIndex = 11;
            this.cbOverhangs.Text = "Detect bridging perimeters";
            this.cbOverhangs.UseVisualStyleBackColor = true;
            // 
            // cbThinWalls
            // 
            this.cbThinWalls.AutoSize = true;
            this.cbThinWalls.Location = new System.Drawing.Point(191, 28);
            this.cbThinWalls.Name = "cbThinWalls";
            this.cbThinWalls.Size = new System.Drawing.Size(104, 17);
            this.cbThinWalls.TabIndex = 10;
            this.cbThinWalls.Text = "Detect thin walls";
            this.cbThinWalls.UseVisualStyleBackColor = true;
            // 
            // cbAvoidCrossingPerimeters
            // 
            this.cbAvoidCrossingPerimeters.AutoSize = true;
            this.cbAvoidCrossingPerimeters.Location = new System.Drawing.Point(10, 51);
            this.cbAvoidCrossingPerimeters.Name = "cbAvoidCrossingPerimeters";
            this.cbAvoidCrossingPerimeters.Size = new System.Drawing.Size(146, 17);
            this.cbAvoidCrossingPerimeters.TabIndex = 9;
            this.cbAvoidCrossingPerimeters.Text = "Avoid crossing perimeters";
            this.cbAvoidCrossingPerimeters.UseVisualStyleBackColor = true;
            // 
            // cbExtraPerimetersfNeeded
            // 
            this.cbExtraPerimetersfNeeded.AutoSize = true;
            this.cbExtraPerimetersfNeeded.Location = new System.Drawing.Point(10, 28);
            this.cbExtraPerimetersfNeeded.Name = "cbExtraPerimetersfNeeded";
            this.cbExtraPerimetersfNeeded.Size = new System.Drawing.Size(148, 17);
            this.cbExtraPerimetersfNeeded.TabIndex = 8;
            this.cbExtraPerimetersfNeeded.Text = "Extra perimeters if needed";
            this.cbExtraPerimetersfNeeded.UseVisualStyleBackColor = true;
            // 
            // gbHorizontalShells
            // 
            this.gbHorizontalShells.Controls.Add(this.label5);
            this.gbHorizontalShells.Controls.Add(this.nbBottomSolidLayers);
            this.gbHorizontalShells.Controls.Add(this.nbTopSolidLayers);
            this.gbHorizontalShells.Controls.Add(this.label6);
            this.gbHorizontalShells.Controls.Add(this.lblSolidLayers);
            this.gbHorizontalShells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHorizontalShells.Location = new System.Drawing.Point(3, 175);
            this.gbHorizontalShells.Name = "gbHorizontalShells";
            this.gbHorizontalShells.Size = new System.Drawing.Size(524, 80);
            this.gbHorizontalShells.TabIndex = 2;
            this.gbHorizontalShells.TabStop = false;
            this.gbHorizontalShells.Text = "Horizontal shells";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bottom";
            // 
            // nbBottomSolidLayers
            // 
            this.nbBottomSolidLayers.Location = new System.Drawing.Point(191, 44);
            this.nbBottomSolidLayers.Name = "nbBottomSolidLayers";
            this.nbBottomSolidLayers.Size = new System.Drawing.Size(100, 20);
            this.nbBottomSolidLayers.TabIndex = 8;
            // 
            // nbTopSolidLayers
            // 
            this.nbTopSolidLayers.Location = new System.Drawing.Point(39, 44);
            this.nbTopSolidLayers.Name = "nbTopSolidLayers";
            this.nbTopSolidLayers.Size = new System.Drawing.Size(100, 20);
            this.nbTopSolidLayers.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Top";
            // 
            // lblSolidLayers
            // 
            this.lblSolidLayers.AutoSize = true;
            this.lblSolidLayers.Location = new System.Drawing.Point(7, 28);
            this.lblSolidLayers.Name = "lblSolidLayers";
            this.lblSolidLayers.Size = new System.Drawing.Size(60, 13);
            this.lblSolidLayers.TabIndex = 0;
            this.lblSolidLayers.Text = "Solid layers";
            // 
            // gbVerticalShells
            // 
            this.gbVerticalShells.Controls.Add(this.cbSpiralVase);
            this.gbVerticalShells.Controls.Add(this.nbPerimeters);
            this.gbVerticalShells.Controls.Add(this.lblPerimeters);
            this.gbVerticalShells.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbVerticalShells.Location = new System.Drawing.Point(3, 89);
            this.gbVerticalShells.Name = "gbVerticalShells";
            this.gbVerticalShells.Size = new System.Drawing.Size(524, 80);
            this.gbVerticalShells.TabIndex = 1;
            this.gbVerticalShells.TabStop = false;
            this.gbVerticalShells.Text = "Vertical shells";
            // 
            // cbSpiralVase
            // 
            this.cbSpiralVase.AutoSize = true;
            this.cbSpiralVase.Location = new System.Drawing.Point(191, 37);
            this.cbSpiralVase.Name = "cbSpiralVase";
            this.cbSpiralVase.Size = new System.Drawing.Size(78, 17);
            this.cbSpiralVase.TabIndex = 7;
            this.cbSpiralVase.Text = "Spiral vase";
            this.cbSpiralVase.UseVisualStyleBackColor = true;
            // 
            // nbPerimeters
            // 
            this.nbPerimeters.Location = new System.Drawing.Point(10, 36);
            this.nbPerimeters.Name = "nbPerimeters";
            this.nbPerimeters.Size = new System.Drawing.Size(100, 20);
            this.nbPerimeters.TabIndex = 6;
            // 
            // lblPerimeters
            // 
            this.lblPerimeters.AutoSize = true;
            this.lblPerimeters.Location = new System.Drawing.Point(7, 20);
            this.lblPerimeters.Name = "lblPerimeters";
            this.lblPerimeters.Size = new System.Drawing.Size(56, 13);
            this.lblPerimeters.TabIndex = 0;
            this.lblPerimeters.Text = "Perimeters";
            // 
            // gbLayerHeight
            // 
            this.gbLayerHeight.Controls.Add(this.lblFirstLayerHeightMmOrPercent);
            this.gbLayerHeight.Controls.Add(this.lblLayerHeightMm);
            this.gbLayerHeight.Controls.Add(this.lblFirstLayerHeight);
            this.gbLayerHeight.Controls.Add(this.tbFirstLayerHeight);
            this.gbLayerHeight.Controls.Add(this.tbLayerHeight);
            this.gbLayerHeight.Controls.Add(this.lblLayerHeight);
            this.gbLayerHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLayerHeight.Location = new System.Drawing.Point(3, 3);
            this.gbLayerHeight.Name = "gbLayerHeight";
            this.gbLayerHeight.Size = new System.Drawing.Size(524, 80);
            this.gbLayerHeight.TabIndex = 0;
            this.gbLayerHeight.TabStop = false;
            this.gbLayerHeight.Text = "Layer height";
            // 
            // lblFirstLayerHeightMmOrPercent
            // 
            this.lblFirstLayerHeightMmOrPercent.AutoSize = true;
            this.lblFirstLayerHeightMmOrPercent.Location = new System.Drawing.Point(297, 47);
            this.lblFirstLayerHeightMmOrPercent.Name = "lblFirstLayerHeightMmOrPercent";
            this.lblFirstLayerHeightMmOrPercent.Size = new System.Drawing.Size(46, 13);
            this.lblFirstLayerHeightMmOrPercent.TabIndex = 5;
            this.lblFirstLayerHeightMmOrPercent.Text = "mm or %";
            // 
            // lblLayerHeightMm
            // 
            this.lblLayerHeightMm.AutoSize = true;
            this.lblLayerHeightMm.Location = new System.Drawing.Point(116, 47);
            this.lblLayerHeightMm.Name = "lblLayerHeightMm";
            this.lblLayerHeightMm.Size = new System.Drawing.Size(23, 13);
            this.lblLayerHeightMm.TabIndex = 4;
            this.lblLayerHeightMm.Text = "mm";
            // 
            // lblFirstLayerHeight
            // 
            this.lblFirstLayerHeight.AutoSize = true;
            this.lblFirstLayerHeight.Location = new System.Drawing.Point(188, 28);
            this.lblFirstLayerHeight.Name = "lblFirstLayerHeight";
            this.lblFirstLayerHeight.Size = new System.Drawing.Size(83, 13);
            this.lblFirstLayerHeight.TabIndex = 3;
            this.lblFirstLayerHeight.Text = "First layer height";
            // 
            // tbFirstLayerHeight
            // 
            this.tbFirstLayerHeight.Location = new System.Drawing.Point(191, 44);
            this.tbFirstLayerHeight.Name = "tbFirstLayerHeight";
            this.tbFirstLayerHeight.Size = new System.Drawing.Size(100, 20);
            this.tbFirstLayerHeight.TabIndex = 2;
            // 
            // tbLayerHeight
            // 
            this.tbLayerHeight.Location = new System.Drawing.Point(10, 44);
            this.tbLayerHeight.Name = "tbLayerHeight";
            this.tbLayerHeight.Size = new System.Drawing.Size(100, 20);
            this.tbLayerHeight.TabIndex = 1;
            // 
            // lblLayerHeight
            // 
            this.lblLayerHeight.AutoSize = true;
            this.lblLayerHeight.Location = new System.Drawing.Point(7, 28);
            this.lblLayerHeight.Name = "lblLayerHeight";
            this.lblLayerHeight.Size = new System.Drawing.Size(65, 13);
            this.lblLayerHeight.TabIndex = 0;
            this.lblLayerHeight.Text = "Layer height";
            // 
            // pageFilament
            // 
            this.pageFilament.Location = new System.Drawing.Point(4, 22);
            this.pageFilament.Name = "pageFilament";
            this.pageFilament.Padding = new System.Windows.Forms.Padding(3);
            this.pageFilament.Size = new System.Drawing.Size(792, 630);
            this.pageFilament.TabIndex = 1;
            this.pageFilament.Text = "Filament Settings";
            this.pageFilament.UseVisualStyleBackColor = true;
            // 
            // pagePrinter
            // 
            this.pagePrinter.Location = new System.Drawing.Point(4, 22);
            this.pagePrinter.Name = "pagePrinter";
            this.pagePrinter.Padding = new System.Windows.Forms.Padding(3);
            this.pagePrinter.Size = new System.Drawing.Size(792, 630);
            this.pagePrinter.TabIndex = 2;
            this.pagePrinter.Text = "Printer Settings";
            this.pagePrinter.UseVisualStyleBackColor = true;
            // 
            // Slic3rSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 656);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Slic3rSettings";
            this.ShowIcon = false;
            this.Text = "Slic3r Settings";
            this.tabControl.ResumeLayout(false);
            this.pagePrint.ResumeLayout(false);
            this.tlpPrint.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpLayers.ResumeLayout(false);
            this.gbAdvanced.ResumeLayout(false);
            this.gbAdvanced.PerformLayout();
            this.gbQuality.ResumeLayout(false);
            this.gbQuality.PerformLayout();
            this.gbHorizontalShells.ResumeLayout(false);
            this.gbHorizontalShells.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbBottomSolidLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbTopSolidLayers)).EndInit();
            this.gbVerticalShells.ResumeLayout(false);
            this.gbVerticalShells.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbPerimeters)).EndInit();
            this.gbLayerHeight.ResumeLayout(false);
            this.gbLayerHeight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pagePrint;
        private System.Windows.Forms.TabPage pageFilament;
        private System.Windows.Forms.TabPage pagePrinter;
        private System.Windows.Forms.TableLayoutPanel tlpPrint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lbPrintSettingsCategories;
        private System.Windows.Forms.TableLayoutPanel tlpLayers;
        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.Label lblSeamPosition;
        private System.Windows.Forms.GroupBox gbQuality;
        private System.Windows.Forms.GroupBox gbHorizontalShells;
        private System.Windows.Forms.Label lblSolidLayers;
        private System.Windows.Forms.GroupBox gbVerticalShells;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPerimeters;
        private System.Windows.Forms.GroupBox gbLayerHeight;
        private System.Windows.Forms.Label lblFirstLayerHeightMmOrPercent;
        private System.Windows.Forms.Label lblLayerHeightMm;
        private System.Windows.Forms.Label lblFirstLayerHeight;
        private System.Windows.Forms.TextBox tbFirstLayerHeight;
        private System.Windows.Forms.TextBox tbLayerHeight;
        private System.Windows.Forms.Label lblLayerHeight;
        private System.Windows.Forms.CheckBox cbExternalPerimetersFirst;
        private System.Windows.Forms.ComboBox cboxSeamPosition;
        private System.Windows.Forms.CheckBox cbOverhangs;
        private System.Windows.Forms.CheckBox cbThinWalls;
        private System.Windows.Forms.CheckBox cbAvoidCrossingPerimeters;
        private System.Windows.Forms.CheckBox cbExtraPerimetersfNeeded;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nbBottomSolidLayers;
        private System.Windows.Forms.NumericUpDown nbTopSolidLayers;
        private System.Windows.Forms.CheckBox cbSpiralVase;
        private System.Windows.Forms.NumericUpDown nbPerimeters;
        private System.Windows.Forms.Button button1;
    }
}