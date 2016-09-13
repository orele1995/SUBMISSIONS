using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PriceComperationController;

namespace UI
{
    public partial class ChartOfPrices : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        public ChartOfPrices(BindingList<ChainDetails> chainDetailses)
        {
            InitializeComponent();
    
            foreach (var chainDetailse in chainDetailses)
            {
                chainsChart.Series["Price"].Points.AddXY(chainDetailse.ChainName, chainDetailse.TotalSum);
                chainsChart.Series["Precents"].Points.AddXY(chainDetailse.ChainName, chainDetailse.PrecentOfCart);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog.Title = "Save Graph";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
             FileStream fs =
                   (FileStream)saveFileDialog.OpenFile();
          
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        chainsChart.SaveImage(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                         chainsChart.SaveImage(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        chainsChart.SaveImage(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
