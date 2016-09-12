using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesManagement;

namespace UI
{
    public partial class UpdateDatabase : Form
    {
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
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("יש לבחור תיקיה");
                return;
            } 
           FilesParser.TheParser.ParseAllFiles(path);
            MessageBox.Show("בסיס הנתונים עודכן בהצלחה");

        }
    }
}
