namespace UI
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.priceCompareationPictureBox = new System.Windows.Forms.PictureBox();
            this.updateDatabasePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceCompareationPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateDatabasePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F);
            this.label1.Location = new System.Drawing.Point(435, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = " השווה מחירים";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F);
            this.label2.Location = new System.Drawing.Point(109, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "עדכן בסיס נתונים";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(202, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "בחר פעולה לביצוע";
            // 
            // closePictureBox
            // 
            this.closePictureBox.Image = global::UI.Properties.Resources.Close_Window_96;
            this.closePictureBox.Location = new System.Drawing.Point(631, 12);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(40, 38);
            this.closePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closePictureBox.TabIndex = 3;
            this.closePictureBox.TabStop = false;
            this.closePictureBox.Click += new System.EventHandler(this.closePictureBox_Click);
            // 
            // priceCompareationPictureBox
            // 
            this.priceCompareationPictureBox.Image = global::UI.Properties.Resources.Cash_Register_96;
            this.priceCompareationPictureBox.Location = new System.Drawing.Point(407, 109);
            this.priceCompareationPictureBox.Name = "priceCompareationPictureBox";
            this.priceCompareationPictureBox.Size = new System.Drawing.Size(186, 149);
            this.priceCompareationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.priceCompareationPictureBox.TabIndex = 1;
            this.priceCompareationPictureBox.TabStop = false;
            this.priceCompareationPictureBox.Click += new System.EventHandler(this.priceCompareationPictureBox_Click);
            // 
            // updateDatabasePictureBox
            // 
            this.updateDatabasePictureBox.Image = global::UI.Properties.Resources.Upload_96;
            this.updateDatabasePictureBox.Location = new System.Drawing.Point(92, 109);
            this.updateDatabasePictureBox.Name = "updateDatabasePictureBox";
            this.updateDatabasePictureBox.Size = new System.Drawing.Size(186, 149);
            this.updateDatabasePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.updateDatabasePictureBox.TabIndex = 0;
            this.updateDatabasePictureBox.TabStop = false;
            this.updateDatabasePictureBox.Click += new System.EventHandler(this.updateDatabasePictureBox_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(693, 312);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priceCompareationPictureBox);
            this.Controls.Add(this.updateDatabasePictureBox);
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ראשי";
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceCompareationPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateDatabasePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox updateDatabasePictureBox;
        private System.Windows.Forms.PictureBox priceCompareationPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox closePictureBox;
    }
}