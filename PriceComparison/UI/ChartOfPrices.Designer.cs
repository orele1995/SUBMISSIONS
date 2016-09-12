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
            this.chainsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chainsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // chainsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.chainsChart.ChartAreas.Add(chartArea1);
            this.chainsChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chainsChart.Legends.Add(legend1);
            this.chainsChart.Location = new System.Drawing.Point(0, 0);
            this.chainsChart.Name = "chainsChart";
            this.chainsChart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series1.ChartArea = "ChartArea1";
            series1.LabelToolTip = "אחוז מהסל המבוקש";
            series1.Legend = "Legend1";
            series1.LegendText = "אחוז מהסל המבוקש";
            series1.Name = "Precents";
            series2.ChartArea = "ChartArea1";
            series2.LabelToolTip = "מחיר לסל";
            series2.Legend = "Legend1";
            series2.LegendText = "מחיר לסל";
            series2.Name = "Price";
            this.chainsChart.Series.Add(series1);
            this.chainsChart.Series.Add(series2);
            this.chainsChart.Size = new System.Drawing.Size(662, 404);
            this.chainsChart.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(521, 314);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 45);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "שמור גרף כתמונה";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ChartOfPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 404);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.chainsChart);
            this.Name = "ChartOfPrices";
            this.Text = "ChartOfPrices";
            ((System.ComponentModel.ISupportInitialize)(this.chainsChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chainsChart;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}