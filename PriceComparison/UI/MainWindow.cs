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
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void updateDatabasePictureBox_Click(object sender, EventArgs e)
        {

            var updateDatabaseWindow = new UpdateDatabase();
            updateDatabaseWindow.Show();
            updateDatabasePictureBox.BorderStyle = BorderStyle.FixedSingle;

        }

        private void priceCompareationPictureBox_Click(object sender, EventArgs e)
        {
            var choosingItemsWindow = new ChoosingItems();
            choosingItemsWindow.ShowDialog();
            priceCompareationPictureBox.BorderStyle = BorderStyle.FixedSingle;

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

        private void priceCompareationPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            priceCompareationPictureBox.BorderStyle = BorderStyle.Fixed3D;

        }

        private void updateDatabasePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            updateDatabasePictureBox.BorderStyle = BorderStyle.Fixed3D;

        }

       
    }
}
