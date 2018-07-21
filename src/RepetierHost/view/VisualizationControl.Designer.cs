namespace RepetierHost.view
{
    partial class VisualizationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPageVisualization = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioShowAll = new System.Windows.Forms.RadioButton();
            this.radioShowSingleLayer = new System.Windows.Forms.RadioButton();
            this.radioShowLayerRange = new System.Windows.Forms.RadioButton();
            this.buttonGoLastLayer = new System.Windows.Forms.Button();
            this.buttonGoFirstLayer = new System.Windows.Forms.Button();
            this.labelMaxLayer = new System.Windows.Forms.Label();
            this.numericShowMaxLayer = new System.Windows.Forms.NumericUpDown();
            this.numericShowMinLayer = new System.Windows.Forms.NumericUpDown();
            this.sliderShowMaxLayer = new MB.Controls.ColorSlider();
            this.sliderShowFirstLayer = new MB.Controls.ColorSlider();
            this.tabPageVisualization.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericShowMaxLayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShowMinLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageVisualization
            // 
            this.tabPageVisualization.Controls.Add(this.flowLayoutPanel1);
            this.tabPageVisualization.Controls.Add(this.buttonGoLastLayer);
            this.tabPageVisualization.Controls.Add(this.buttonGoFirstLayer);
            this.tabPageVisualization.Controls.Add(this.labelMaxLayer);
            this.tabPageVisualization.Controls.Add(this.numericShowMaxLayer);
            this.tabPageVisualization.Controls.Add(this.numericShowMinLayer);
            this.tabPageVisualization.Controls.Add(this.sliderShowMaxLayer);
            this.tabPageVisualization.Controls.Add(this.sliderShowFirstLayer);
            this.tabPageVisualization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageVisualization.Location = new System.Drawing.Point(0, 0);
            this.tabPageVisualization.Name = "tabPageVisualization";
            this.tabPageVisualization.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVisualization.Size = new System.Drawing.Size(615, 100);
            this.tabPageVisualization.TabIndex = 1;
            this.tabPageVisualization.Text = "Visualization";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.radioShowAll);
            this.flowLayoutPanel1.Controls.Add(this.radioShowSingleLayer);
            this.flowLayoutPanel1.Controls.Add(this.radioShowLayerRange);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(615, 31);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radioShowAll
            // 
            this.radioShowAll.AutoSize = true;
            this.radioShowAll.Checked = true;
            this.radioShowAll.Location = new System.Drawing.Point(3, 3);
            this.radioShowAll.Name = "radioShowAll";
            this.radioShowAll.Size = new System.Drawing.Size(125, 17);
            this.radioShowAll.TabIndex = 0;
            this.radioShowAll.TabStop = true;
            this.radioShowAll.Tag = "0";
            this.radioShowAll.Text = "Show complete code";
            this.radioShowAll.UseVisualStyleBackColor = true;
            // 
            // radioShowSingleLayer
            // 
            this.radioShowSingleLayer.AutoSize = true;
            this.radioShowSingleLayer.Location = new System.Drawing.Point(134, 3);
            this.radioShowSingleLayer.Name = "radioShowSingleLayer";
            this.radioShowSingleLayer.Size = new System.Drawing.Size(107, 17);
            this.radioShowSingleLayer.TabIndex = 1;
            this.radioShowSingleLayer.Tag = "1";
            this.radioShowSingleLayer.Text = "Show single layer";
            this.radioShowSingleLayer.UseVisualStyleBackColor = true;
            // 
            // radioShowLayerRange
            // 
            this.radioShowLayerRange.AutoSize = true;
            this.radioShowLayerRange.Location = new System.Drawing.Point(247, 3);
            this.radioShowLayerRange.Name = "radioShowLayerRange";
            this.radioShowLayerRange.Size = new System.Drawing.Size(107, 17);
            this.radioShowLayerRange.TabIndex = 2;
            this.radioShowLayerRange.Tag = "2";
            this.radioShowLayerRange.Text = "Show layer range";
            this.radioShowLayerRange.UseVisualStyleBackColor = true;
            // 
            // buttonGoLastLayer
            // 
            this.buttonGoLastLayer.Location = new System.Drawing.Point(10, 65);
            this.buttonGoLastLayer.Name = "buttonGoLastLayer";
            this.buttonGoLastLayer.Size = new System.Drawing.Size(132, 23);
            this.buttonGoLastLayer.TabIndex = 7;
            this.buttonGoLastLayer.Text = "Last Layer";
            this.buttonGoLastLayer.UseVisualStyleBackColor = true;
            // 
            // buttonGoFirstLayer
            // 
            this.buttonGoFirstLayer.Location = new System.Drawing.Point(10, 37);
            this.buttonGoFirstLayer.Name = "buttonGoFirstLayer";
            this.buttonGoFirstLayer.Size = new System.Drawing.Size(132, 23);
            this.buttonGoFirstLayer.TabIndex = 7;
            this.buttonGoFirstLayer.Text = "First Layer";
            this.buttonGoFirstLayer.UseVisualStyleBackColor = true;
            // 
            // labelMaxLayer
            // 
            this.labelMaxLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaxLayer.AutoSize = true;
            this.labelMaxLayer.Location = new System.Drawing.Point(580, 71);
            this.labelMaxLayer.Name = "labelMaxLayer";
            this.labelMaxLayer.Size = new System.Drawing.Size(10, 13);
            this.labelMaxLayer.TabIndex = 6;
            this.labelMaxLayer.Text = "-";
            this.labelMaxLayer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericShowMaxLayer
            // 
            this.numericShowMaxLayer.Location = new System.Drawing.Point(144, 66);
            this.numericShowMaxLayer.Name = "numericShowMaxLayer";
            this.numericShowMaxLayer.Size = new System.Drawing.Size(59, 20);
            this.numericShowMaxLayer.TabIndex = 4;
            // 
            // numericShowMinLayer
            // 
            this.numericShowMinLayer.Location = new System.Drawing.Point(144, 40);
            this.numericShowMinLayer.Name = "numericShowMinLayer";
            this.numericShowMinLayer.Size = new System.Drawing.Size(59, 20);
            this.numericShowMinLayer.TabIndex = 3;
            // 
            // sliderShowMaxLayer
            // 
            this.sliderShowMaxLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderShowMaxLayer.BackColor = System.Drawing.Color.Transparent;
            this.sliderShowMaxLayer.BarInnerColor = System.Drawing.Color.DimGray;
            this.sliderShowMaxLayer.BarOuterColor = System.Drawing.Color.LightGray;
            this.sliderShowMaxLayer.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderShowMaxLayer.DrawFocusRectangle = false;
            this.sliderShowMaxLayer.ElapsedInnerColor = System.Drawing.Color.DarkGray;
            this.sliderShowMaxLayer.ElapsedOuterColor = System.Drawing.Color.LightGray;
            this.sliderShowMaxLayer.LargeChange = ((uint)(5u));
            this.sliderShowMaxLayer.Location = new System.Drawing.Point(209, 64);
            this.sliderShowMaxLayer.Name = "sliderShowMaxLayer";
            this.sliderShowMaxLayer.Size = new System.Drawing.Size(365, 22);
            this.sliderShowMaxLayer.SmallChange = ((uint)(1u));
            this.sliderShowMaxLayer.TabIndex = 6;
            this.sliderShowMaxLayer.Text = "colorSlider1";
            this.sliderShowMaxLayer.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // sliderShowFirstLayer
            // 
            this.sliderShowFirstLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderShowFirstLayer.BackColor = System.Drawing.Color.Transparent;
            this.sliderShowFirstLayer.BarInnerColor = System.Drawing.Color.DimGray;
            this.sliderShowFirstLayer.BarOuterColor = System.Drawing.Color.LightGray;
            this.sliderShowFirstLayer.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderShowFirstLayer.DrawFocusRectangle = false;
            this.sliderShowFirstLayer.ElapsedInnerColor = System.Drawing.Color.DarkGray;
            this.sliderShowFirstLayer.ElapsedOuterColor = System.Drawing.Color.LightGray;
            this.sliderShowFirstLayer.LargeChange = ((uint)(5u));
            this.sliderShowFirstLayer.Location = new System.Drawing.Point(209, 40);
            this.sliderShowFirstLayer.Name = "sliderShowFirstLayer";
            this.sliderShowFirstLayer.Size = new System.Drawing.Size(365, 22);
            this.sliderShowFirstLayer.SmallChange = ((uint)(1u));
            this.sliderShowFirstLayer.TabIndex = 5;
            this.sliderShowFirstLayer.Text = "colorSlider1";
            this.sliderShowFirstLayer.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            // 
            // VisualizationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPageVisualization);
            this.MinimumSize = new System.Drawing.Size(615, 100);
            this.Name = "VisualizationControl";
            this.Size = new System.Drawing.Size(615, 100);
            this.tabPageVisualization.ResumeLayout(false);
            this.tabPageVisualization.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericShowMaxLayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericShowMinLayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tabPageVisualization;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioShowAll;
        private System.Windows.Forms.RadioButton radioShowSingleLayer;
        private System.Windows.Forms.RadioButton radioShowLayerRange;
        private System.Windows.Forms.Button buttonGoLastLayer;
        private System.Windows.Forms.Button buttonGoFirstLayer;
        private System.Windows.Forms.Label labelMaxLayer;
        private System.Windows.Forms.NumericUpDown numericShowMaxLayer;
        private System.Windows.Forms.NumericUpDown numericShowMinLayer;
        private MB.Controls.ColorSlider sliderShowMaxLayer;
        private MB.Controls.ColorSlider sliderShowFirstLayer;
    }
}
