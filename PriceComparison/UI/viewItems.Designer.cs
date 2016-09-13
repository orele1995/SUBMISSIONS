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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewItems));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chainsTabControl = new System.Windows.Forms.TabControl();
            this.dataGroupBox = new System.Windows.Forms.GroupBox();
            this.graphButton = new System.Windows.Forms.Button();
            this.dataLabel = new System.Windows.Forms.Label();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.chainsTabControl.SuspendLayout();
            this.dataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(853, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(853, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chainsTabControl
            // 
            this.chainsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chainsTabControl.Controls.Add(this.tabPage1);
            this.chainsTabControl.Controls.Add(this.tabPage2);
            this.chainsTabControl.Location = new System.Drawing.Point(27, 91);
            this.chainsTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chainsTabControl.Name = "chainsTabControl";
            this.chainsTabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chainsTabControl.RightToLeftLayout = true;
            this.chainsTabControl.SelectedIndex = 0;
            this.chainsTabControl.ShowToolTips = true;
            this.chainsTabControl.Size = new System.Drawing.Size(861, 570);
            this.chainsTabControl.TabIndex = 0;
            // 
            // dataGroupBox
            // 
            this.dataGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.dataGroupBox.Controls.Add(this.graphPictureBox);
            this.dataGroupBox.Controls.Add(this.graphButton);
            this.dataGroupBox.Controls.Add(this.dataLabel);
            this.dataGroupBox.Location = new System.Drawing.Point(920, 399);
            this.dataGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGroupBox.Name = "dataGroupBox";
            this.dataGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGroupBox.Size = new System.Drawing.Size(313, 262);
            this.dataGroupBox.TabIndex = 2;
            this.dataGroupBox.TabStop = false;
            this.dataGroupBox.Text = "מידע סטטיסטי";
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(19, 170);
            this.graphButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(116, 72);
            this.graphButton.TabIndex = 1;
            this.graphButton.Text = "הצג גרף מחירים";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // dataLabel
            // 
            this.dataLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLabel.AutoSize = true;
            this.dataLabel.BackColor = System.Drawing.Color.Transparent;
            this.dataLabel.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.dataLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataLabel.Location = new System.Drawing.Point(19, 33);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataLabel.Size = new System.Drawing.Size(75, 29);
            this.dataLabel.TabIndex = 0;
            this.dataLabel.Text = "מחיר לסל: ";
            this.dataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dataLabel.UseCompatibleTextRendering = true;
            // 
            // itemsListBox
            // 
            this.itemsListBox.BackColor = System.Drawing.Color.Gainsboro;
            this.itemsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.ItemHeight = 19;
            this.itemsListBox.Location = new System.Drawing.Point(921, 119);
            this.itemsListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(312, 249);
            this.itemsListBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(424, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = "השוואת מחירים";
            // 
            // closePictureBox
            // 
            this.closePictureBox.Image = global::UI.Properties.Resources.Close_Window_96;
            this.closePictureBox.Location = new System.Drawing.Point(12, 12);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(40, 38);
            this.closePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closePictureBox.TabIndex = 5;
            this.closePictureBox.TabStop = false;
            this.closePictureBox.Click += new System.EventHandler(this.closePictureBox_Click);
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.Image = global::UI.Properties.Resources.Bar_Chart_96;
            this.graphPictureBox.Location = new System.Drawing.Point(139, 169);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(73, 72);
            this.graphPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.graphPictureBox.TabIndex = 5;
            this.graphPictureBox.TabStop = false;
            this.graphPictureBox.Click += new System.EventHandler(this.graphPictureBox_Click);
            // 
            // ViewItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1245, 731);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemsListBox);
            this.Controls.Add(this.dataGroupBox);
            this.Controls.Add(this.chainsTabControl);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ViewItems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "viewItems";
            this.chainsTabControl.ResumeLayout(false);
            this.dataGroupBox.ResumeLayout(false);
            this.dataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl chainsTabControl;
        private System.Windows.Forms.GroupBox dataGroupBox;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.Label dataLabel;
        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox closePictureBox;
        private System.Windows.Forms.PictureBox graphPictureBox;
    }
}