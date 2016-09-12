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
        public ChartOfPrices(BindingList<ChainDetails> chainDetailses)
        {
            InitializeComponent();
          //var s = chainDetailses.Select(c => new Series(c.ChainName,(int)( c.PrecentOfCart )));
          //  foreach (var si in s)
          //  {
          //      chainsChart.Series.Add(si);
          //  }

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
    }
}
