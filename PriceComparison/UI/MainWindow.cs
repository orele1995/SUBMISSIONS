using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void updateDatabasePictureBox_Click(object sender, EventArgs e)
        {
            var updateDatabaseWindow= new UpdateDatabase();
            updateDatabaseWindow.ShowDialog();
        }

        private void priceCompareationPictureBox_Click(object sender, EventArgs e)
        {
            var choosingItemsWindow = new ChoosingItems();
            choosingItemsWindow.ShowDialog();
        }

 
        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
