using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesManagement;

namespace UI
{
    public partial class UpdateDatabase : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        public UpdateDatabase()
        {
            InitializeComponent();
         
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var path = pathTextBox.Text;
            
            var synchronizationContext = SynchronizationContext.Current;

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("יש לבחור תיקיה");
                return;
            }
            okButton.Enabled = false;
            ProgressBar progressBar = new ProgressBar();
            progressBar.Left = 500;
            progressBar.Width = 600;
            progressBar.Height = 50;
            progressBar.Value = 0;
            progressBar.Location = new Point {X = 60, Y = 310};
            Controls.Add(progressBar);
            Height = Height + 70;
            Label progressLabel = new Label();
            progressLabel.Location = new Point {X = 320, Y = 370};
            progressLabel.Text = "סיים " + 0 + " / " + 0 + " קבצים";
            Controls.Add(progressLabel);
            Task.Run(() =>
            {
                FilesParser.TheParser.FileDone += (o, args) =>
                {
                    synchronizationContext.Send(_ =>
                    {
                    progressBar.Value =(int) (100 * (double)args.NumOfFilesDone/ args.NumOfFiles);
                        progressLabel.Text = "סיים " + args.NumOfFilesDone + " / "+ args.NumOfFiles+ " קבצים";
                    }, null);
                };
                FilesParser.TheParser.ParseAllFiles(path);

                synchronizationContext.Send(_ =>
                {
                    okButton.Enabled = true;

                    MessageBox.Show("בסיס הנתונים עודכן בהצלחה");
                    Controls.Remove(progressBar);
                    Controls.Remove(progressLabel);
                    Height -= 50;
                }, null);

            });

        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

    
    }
}
