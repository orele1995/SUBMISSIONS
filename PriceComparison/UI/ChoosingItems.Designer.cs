namespace UI
{
    partial class ChoosingItems
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
            this.ItemsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.selectedItemsListBox = new System.Windows.Forms.ListBox();
            this.chainsComboBox = new System.Windows.Forms.ComboBox();
            this.storesComboBox = new System.Windows.Forms.ComboBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.selectorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChooseTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.compareButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemsCheckedListBox
            // 
            this.ItemsCheckedListBox.FormattingEnabled = true;
            this.ItemsCheckedListBox.Location = new System.Drawing.Point(14, 136);
            this.ItemsCheckedListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ItemsCheckedListBox.Name = "ItemsCheckedListBox";
            this.ItemsCheckedListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ItemsCheckedListBox.Size = new System.Drawing.Size(297, 488);
            this.ItemsCheckedListBox.TabIndex = 0;
            this.ItemsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ItemsCheckedListBox_ItemCheck);
            this.ItemsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.ItemsCheckedListBox_SelectedIndexChanged);
            // 
            // selectedItemsListBox
            // 
            this.selectedItemsListBox.FormattingEnabled = true;
            this.selectedItemsListBox.ItemHeight = 19;
            this.selectedItemsListBox.Location = new System.Drawing.Point(343, 221);
            this.selectedItemsListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectedItemsListBox.Name = "selectedItemsListBox";
            this.selectedItemsListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectedItemsListBox.Size = new System.Drawing.Size(297, 403);
            this.selectedItemsListBox.TabIndex = 1;
            this.selectedItemsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.selectedItemsListBox_MouseDoubleClick);
            // 
            // chainsComboBox
            // 
            this.chainsComboBox.FormattingEnabled = true;
            this.chainsComboBox.Location = new System.Drawing.Point(349, 92);
            this.chainsComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chainsComboBox.Name = "chainsComboBox";
            this.chainsComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chainsComboBox.Size = new System.Drawing.Size(297, 27);
            this.chainsComboBox.TabIndex = 2;
            this.chainsComboBox.SelectedIndexChanged += new System.EventHandler(this.chainsComboBox_SelectedIndexChanged);
            // 
            // storesComboBox
            // 
            this.storesComboBox.FormattingEnabled = true;
            this.storesComboBox.Location = new System.Drawing.Point(349, 161);
            this.storesComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.storesComboBox.Name = "storesComboBox";
            this.storesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.storesComboBox.Size = new System.Drawing.Size(297, 27);
            this.storesComboBox.TabIndex = 2;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(664, 552);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(129, 72);
            this.NextButton.TabIndex = 4;
            this.NextButton.Text = "חשב מחיר";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // selectorButton
            // 
            this.selectorButton.Location = new System.Drawing.Point(652, 80);
            this.selectorButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectorButton.Name = "selectorButton";
            this.selectorButton.Size = new System.Drawing.Size(129, 49);
            this.selectorButton.TabIndex = 5;
            this.selectorButton.Text = "סנן";
            this.selectorButton.UseVisualStyleBackColor = true;
            this.selectorButton.Click += new System.EventHandler(this.selectorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(205, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 47);
            this.label1.TabIndex = 6;
            this.label1.Text = "הוספת פריטים לעגלת הקניות";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(345, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "בחר חנות:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(345, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "העגלה שלך:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "בחר פריטים";
            // 
            // ChooseTextBox
            // 
            this.ChooseTextBox.Location = new System.Drawing.Point(154, 97);
            this.ChooseTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChooseTextBox.Name = "ChooseTextBox";
            this.ChooseTextBox.Size = new System.Drawing.Size(155, 27);
            this.ChooseTextBox.TabIndex = 7;
            this.ChooseTextBox.TextChanged += new System.EventHandler(this.ChooseTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "הקלד טקסט לחיפוש:";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(652, 149);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(129, 49);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "בטל סינון";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // compareButton
            // 
            this.compareButton.Location = new System.Drawing.Point(664, 469);
            this.compareButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(129, 75);
            this.compareButton.TabIndex = 8;
            this.compareButton.Text = "השווה";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(345, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "בחר רשת:";
            // 
            // closePictureBox
            // 
            this.closePictureBox.Image = global::UI.Properties.Resources.Close_Window_96;
            this.closePictureBox.Location = new System.Drawing.Point(16, 12);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(40, 38);
            this.closePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closePictureBox.TabIndex = 9;
            this.closePictureBox.TabStop = false;
            this.closePictureBox.Click += new System.EventHandler(this.closePictureBox_Click);
            // 
            // ChoosingItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(817, 637);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.ChooseTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.selectorButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.storesComboBox);
            this.Controls.Add(this.chainsComboBox);
            this.Controls.Add(this.selectedItemsListBox);
            this.Controls.Add(this.ItemsCheckedListBox);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChoosingItems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "בחירת פריטים";
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ItemsCheckedListBox;
        private System.Windows.Forms.ListBox selectedItemsListBox;
        private System.Windows.Forms.ComboBox chainsComboBox;
        private System.Windows.Forms.ComboBox storesComboBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button selectorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ChooseTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox closePictureBox;
    }
}

