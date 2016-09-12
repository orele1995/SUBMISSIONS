namespace UI
{
    partial class ViewItems
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chainsTabControl = new System.Windows.Forms.TabControl();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.graphButton = new System.Windows.Forms.Button();
            this.dataLabel = new System.Windows.Forms.Label();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.chainsTabControl.SuspendLayout();
            this.dataGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(598, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chainsTabControl
            // 
            this.chainsTabControl.Controls.Add(this.tabPage1);
            this.chainsTabControl.Controls.Add(this.tabPage2);
            this.chainsTabControl.Location = new System.Drawing.Point(23, 62);
            this.chainsTabControl.Name = "chainsTabControl";
            this.chainsTabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chainsTabControl.RightToLeftLayout = true;
            this.chainsTabControl.SelectedIndex = 0;
            this.chainsTabControl.ShowToolTips = true;
            this.chainsTabControl.Size = new System.Drawing.Size(606, 390);
            this.chainsTabControl.TabIndex = 0;
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.Controls.Add(this.graphButton);
            this.dataGroupBox.Controls.Add(this.dataLabel);
            this.dataGroupBox.Location = new System.Drawing.Point(655, 269);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGroupBox.Size = new System.Drawing.Size(268, 179);
            this.dataGroupBox.TabIndex = 2;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "מידע סטטיסטי";
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(16, 114);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(75, 23);
            this.graphButton.TabIndex = 1;
            this.graphButton.Text = "הצג גרף מחירים";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // dataLabel
            // 
            this.dataLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(16, 41);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(62, 13);
            this.dataLabel.TabIndex = 0;
            this.dataLabel.Text = "מחיר לסל: ";
            this.dataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemsListBox
            // 
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(655, 84);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(268, 173);
            this.itemsListBox.TabIndex = 3;
            // 
            // ViewItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 500);
            this.Controls.Add(this.itemsListBox);
            this.Controls.Add(this.dataGroupBox);
            this.Controls.Add(this.chainsTabControl);
            this.Name = "ViewItems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "viewItems";
            this.chainsTabControl.ResumeLayout(false);
            this.dataGroupBox.ResumeLayout(false);
            this.dataGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl chainsTabControl;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.Button graphButton;
    }
}