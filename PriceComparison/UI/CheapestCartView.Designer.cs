﻿namespace UI
{
    partial class CheapestCartView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemsDataGridView
            // 
            this.ItemsDataGridView.AllowUserToAddRows = false;
            this.ItemsDataGridView.AllowUserToDeleteRows = false;
            this.ItemsDataGridView.AllowUserToOrderColumns = true;
            this.ItemsDataGridView.AllowUserToResizeColumns = false;
            this.ItemsDataGridView.AllowUserToResizeRows = false;
            this.ItemsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ItemsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ItemsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ItemsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ItemsDataGridView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ItemsDataGridView.Location = new System.Drawing.Point(12, 46);
            this.ItemsDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemsDataGridView.MultiSelect = false;
            this.ItemsDataGridView.Name = "ItemsDataGridView";
            this.ItemsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ItemsDataGridView.ShowCellErrors = false;
            this.ItemsDataGridView.ShowCellToolTips = false;
            this.ItemsDataGridView.ShowRowErrors = false;
            this.ItemsDataGridView.Size = new System.Drawing.Size(713, 221);
            this.ItemsDataGridView.TabIndex = 2;
            this.ItemsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsDataGridView_CellEndEdit);
            this.ItemsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ItemsDataGridView_CellValidating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = ":סך הכל";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Location = new System.Drawing.Point(587, 285);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(41, 19);
            this.totalPriceLabel.TabIndex = 4;
            this.totalPriceLabel.Text = "label1";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(12, 279);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(175, 36);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "יצא טבלה לאקסל";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // CheapestCartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 327);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.ItemsDataGridView);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CheapestCartView";
            this.Text = "CheapestCartView";
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Button exportButton;
    }
}