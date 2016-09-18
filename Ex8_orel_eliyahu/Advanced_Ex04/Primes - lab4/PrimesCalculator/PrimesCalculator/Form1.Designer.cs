namespace PrimesCalculator
{
    partial class Form1
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
            this.numbersListBox = new System.Windows.Forms.ListBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.calculatButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.cancelButton2 = new System.Windows.Forms.Button();
            this.From2textBox = new System.Windows.Forms.TextBox();
            this.To2textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.calcAndWritebutton = new System.Windows.Forms.Button();
            this.cancel2button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numOfPrimesLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numbersListBox
            // 
            this.numbersListBox.FormattingEnabled = true;
            this.numbersListBox.Location = new System.Drawing.Point(55, 62);
            this.numbersListBox.Name = "numbersListBox";
            this.numbersListBox.Size = new System.Drawing.Size(183, 95);
            this.numbersListBox.TabIndex = 0;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(33, 26);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(100, 20);
            this.fromTextBox.TabIndex = 1;
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(160, 26);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(100, 20);
            this.toTextBox.TabIndex = 2;
            // 
            // calculatButton
            // 
            this.calculatButton.Location = new System.Drawing.Point(107, 163);
            this.calculatButton.Name = "calculatButton";
            this.calculatButton.Size = new System.Drawing.Size(75, 23);
            this.calculatButton.TabIndex = 3;
            this.calculatButton.Text = "Calculate";
            this.calculatButton.UseVisualStyleBackColor = true;
            this.calculatButton.Click += new System.EventHandler(this.calculatButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(107, 192);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel 1";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // cancelButton2
            // 
            this.cancelButton2.Location = new System.Drawing.Point(107, 221);
            this.cancelButton2.Name = "cancelButton2";
            this.cancelButton2.Size = new System.Drawing.Size(75, 23);
            this.cancelButton2.TabIndex = 5;
            this.cancelButton2.Text = "Cancel 2";
            this.cancelButton2.UseVisualStyleBackColor = true;
            this.cancelButton2.Click += new System.EventHandler(this.cancelButton2_Click);
            // 
            // From2textBox
            // 
            this.From2textBox.Location = new System.Drawing.Point(36, 259);
            this.From2textBox.Name = "From2textBox";
            this.From2textBox.Size = new System.Drawing.Size(100, 20);
            this.From2textBox.TabIndex = 1;
            // 
            // To2textBox
            // 
            this.To2textBox.Location = new System.Drawing.Point(160, 259);
            this.To2textBox.Name = "To2textBox";
            this.To2textBox.Size = new System.Drawing.Size(100, 20);
            this.To2textBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(33, 303);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(227, 20);
            this.pathTextBox.TabIndex = 1;
            // 
            // calcAndWritebutton
            // 
            this.calcAndWritebutton.Location = new System.Drawing.Point(33, 329);
            this.calcAndWritebutton.Name = "calcAndWritebutton";
            this.calcAndWritebutton.Size = new System.Drawing.Size(116, 23);
            this.calcAndWritebutton.TabIndex = 3;
            this.calcAndWritebutton.Text = "Calculate and Write";
            this.calcAndWritebutton.UseVisualStyleBackColor = true;
            this.calcAndWritebutton.Click += new System.EventHandler(this.calcAndWritebutton_Click);
            // 
            // cancel2button
            // 
            this.cancel2button.Location = new System.Drawing.Point(185, 329);
            this.cancel2button.Name = "cancel2button";
            this.cancel2button.Size = new System.Drawing.Size(75, 23);
            this.cancel2button.TabIndex = 5;
            this.cancel2button.Text = "Cancel ";
            this.cancel2button.UseVisualStyleBackColor = true;
            this.cancel2button.Click += new System.EventHandler(this.cancel2button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "File Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Num of primes: ";
            // 
            // numOfPrimesLabel
            // 
            this.numOfPrimesLabel.AutoSize = true;
            this.numOfPrimesLabel.Location = new System.Drawing.Point(120, 364);
            this.numOfPrimesLabel.Name = "numOfPrimesLabel";
            this.numOfPrimesLabel.Size = new System.Drawing.Size(13, 13);
            this.numOfPrimesLabel.TabIndex = 6;
            this.numOfPrimesLabel.Text = "0";
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(267, 303);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 7;
            this.openButton.Text = "open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 395);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numOfPrimesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel2button);
            this.Controls.Add(this.cancelButton2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.calcAndWritebutton);
            this.Controls.Add(this.calculatButton);
            this.Controls.Add(this.To2textBox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.From2textBox);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.fromTextBox);
            this.Controls.Add(this.numbersListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox numbersListBox;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.Button calculatButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button cancelButton2;
        private System.Windows.Forms.TextBox From2textBox;
        private System.Windows.Forms.TextBox To2textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button calcAndWritebutton;
        private System.Windows.Forms.Button cancel2button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label numOfPrimesLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openButton;
    }
}

