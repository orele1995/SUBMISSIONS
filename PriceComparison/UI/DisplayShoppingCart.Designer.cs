namespace UI
{
    partial class DisplayShoppingCart
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
            this.ChainNameLabel = new System.Windows.Forms.Label();
            this.ItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ChainNameLabel
            // 
            this.ChainNameLabel.AutoSize = true;
            this.ChainNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChainNameLabel.Font = new System.Drawing.Font("Segoe Print", 15F, System.Drawing.FontStyle.Bold);
            this.ChainNameLabel.Location = new System.Drawing.Point(203, 37);
            this.ChainNameLabel.Name = "ChainNameLabel";
            this.ChainNameLabel.Size = new System.Drawing.Size(117, 35);
            this.ChainNameLabel.TabIndex = 0;
            this.ChainNameLabel.Text = "שם הרשת";
            // 
            // ItemsDataGridView
            // 
            this.ItemsDataGridView.AllowUserToAddRows = false;
            this.ItemsDataGridView.AllowUserToDeleteRows = false;
            this.ItemsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ItemsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.ItemsDataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.ItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsDataGridView.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ItemsDataGridView.Location = new System.Drawing.Point(3, 101);
            this.ItemsDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemsDataGridView.Name = "ItemsDataGridView";
            this.ItemsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ItemsDataGridView.Size = new System.Drawing.Size(570, 360);
            this.ItemsDataGridView.TabIndex = 1;
            this.ItemsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsDataGridView_CellEndEdit);
            this.ItemsDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsDataGridView_CellEndEdit);
            this.ItemsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ItemsDataGridView_CellValidating);
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalPriceLabel.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold);
            this.totalPriceLabel.Location = new System.Drawing.Point(205, 487);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(51, 24);
            this.totalPriceLabel.TabIndex = 2;
            this.totalPriceLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.label1.Location = new System.Drawing.Point(262, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = ":סך הכל";
            // 
            // DisplayShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.ItemsDataGridView);
            this.Controls.Add(this.ChainNameLabel);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DisplayShoppingCart";
            this.Size = new System.Drawing.Size(577, 550);
            this.Load += new System.EventHandler(this.DisplayShoppingCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChainNameLabel;
        private System.Windows.Forms.DataGridView ItemsDataGridView;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label label1;
    }
}
