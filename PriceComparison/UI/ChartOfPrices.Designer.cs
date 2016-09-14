namespace UI
{
    partial class ChartOfPrices
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartOfPrices));
            this.chainsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chainsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chainsChart
            // 
            this.chainsChart.BackColor = System.Drawing.Color.Gainsboro;
            this.chainsChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chainsChart.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chainsChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chainsChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chainsChart.ChartAreas.Add(chartArea1);
            this.chainsChart.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.chainsChart.Legends.Add(legend1);
            this.chainsChart.Location = new System.Drawing.Point(0, 0);
            this.chainsChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chainsChart.Name = "chainsChart";
            this.chainsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chainsChart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.LabelToolTip = "אחוז מהסל המבוקש";
            series1.Legend = "Legend1";
            series1.LegendText = "אחוז מהסל המבוקש";
            series1.Name = "Precents";
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.LabelToolTip = "מחיר לסל";
            series2.Legend = "Legend1";
            series2.LegendText = "מחיר לסל";
            series2.Name = "Price";
            this.chainsChart.Series.Add(series1);
            this.chainsChart.Series.Add(series2);
            this.chainsChart.Size = new System.Drawing.Size(719, 590);
            this.chainsChart.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(622, 497);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 66);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "שמור גרף כתמונה";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closePictureBox
            // 
            this.closePictureBox.Image = global::UI.Properties.Resources.Close_Window_96;
            this.closePictureBox.Location = new System.Drawing.Point(732, 0);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(40, 38);
            this.closePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closePictureBox.TabIndex = 4;
            this.closePictureBox.TabStop = false;
            this.closePictureBox.Click += new System.EventHandler(this.closePictureBox_Click);
            // 
            // ChartOfPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(772, 590);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.chainsChart);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChartOfPrices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChartOfPrices";
            ((System.ComponentModel.ISupportInitialize)(this.chainsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chainsChart;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox closePictureBox;
    }
}