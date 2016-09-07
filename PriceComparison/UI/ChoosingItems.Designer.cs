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
            this.SuspendLayout();
            // 
            // ItemsCheckedListBox
            // 
            this.ItemsCheckedListBox.FormattingEnabled = true;
            this.ItemsCheckedListBox.Location = new System.Drawing.Point(417, 72);
            this.ItemsCheckedListBox.Name = "ItemsCheckedListBox";
            this.ItemsCheckedListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ItemsCheckedListBox.Size = new System.Drawing.Size(255, 349);
            this.ItemsCheckedListBox.TabIndex = 0;
            this.ItemsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ItemsCheckedListBox_ItemCheck);
            this.ItemsCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.ItemsCheckedListBox_SelectedIndexChanged);
            // 
            // selectedItemsListBox
            // 
            this.selectedItemsListBox.FormattingEnabled = true;
            this.selectedItemsListBox.Location = new System.Drawing.Point(132, 144);
            this.selectedItemsListBox.Name = "selectedItemsListBox";
            this.selectedItemsListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.selectedItemsListBox.Size = new System.Drawing.Size(255, 277);
            this.selectedItemsListBox.TabIndex = 1;
            // 
            // chainsComboBox
            // 
            this.chainsComboBox.FormattingEnabled = true;
            this.chainsComboBox.Location = new System.Drawing.Point(132, 43);
            this.chainsComboBox.Name = "chainsComboBox";
            this.chainsComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chainsComboBox.Size = new System.Drawing.Size(255, 21);
            this.chainsComboBox.TabIndex = 2;
            this.chainsComboBox.SelectedIndexChanged += new System.EventHandler(this.chainsComboBox_SelectedIndexChanged);
            // 
            // storesComboBox
            // 
            this.storesComboBox.FormattingEnabled = true;
            this.storesComboBox.Location = new System.Drawing.Point(132, 90);
            this.storesComboBox.Name = "storesComboBox";
            this.storesComboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.storesComboBox.Size = new System.Drawing.Size(255, 21);
            this.storesComboBox.TabIndex = 2;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(12, 372);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(111, 49);
            this.NextButton.TabIndex = 4;
            this.NextButton.Text = "חשב מחיר";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // selectorButton
            // 
            this.selectorButton.Location = new System.Drawing.Point(12, 43);
            this.selectorButton.Name = "selectorButton";
            this.selectorButton.Size = new System.Drawing.Size(111, 26);
            this.selectorButton.TabIndex = 5;
            this.selectorButton.Text = "סנן";
            this.selectorButton.UseVisualStyleBackColor = true;
            this.selectorButton.Click += new System.EventHandler(this.selectorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "בחר רשת:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "בחר חנות:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "העגלה שלך:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "בחר פריטים";
            // 
            // ChooseTextBox
            // 
            this.ChooseTextBox.Location = new System.Drawing.Point(417, 43);
            this.ChooseTextBox.Name = "ChooseTextBox";
            this.ChooseTextBox.Size = new System.Drawing.Size(143, 20);
            this.ChooseTextBox.TabIndex = 7;
            this.ChooseTextBox.TextChanged += new System.EventHandler(this.ChooseTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(563, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "הקלד טקסט לחיפוש:";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(12, 85);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(111, 26);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "בטל סינון";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // ChoosingItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 454);
            this.Controls.Add(this.ChooseTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.selectorButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.storesComboBox);
            this.Controls.Add(this.chainsComboBox);
            this.Controls.Add(this.selectedItemsListBox);
            this.Controls.Add(this.ItemsCheckedListBox);
            this.Name = "ChoosingItems";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "בחירת פריטים";
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
    }
}

