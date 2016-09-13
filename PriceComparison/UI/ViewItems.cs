using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceComperationController;
using PriceComperationModel;

namespace UI
{
    public partial class ViewItems : Form
    {
        private BindingList<DisplayItem> _displayItems = new BindingList<DisplayItem>();
        private readonly PriceControl _control = PriceControl.ThePriceControl;
        private BindingList<ChainDetails> pricesOfChains = new BindingList<ChainDetails>();
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        public ViewItems(IEnumerable<ChainDetails> chainDetailses, BindingList<Item> shoppingCart)
        {
            InitializeComponent();
            chainsTabControl.TabPages.Clear();
            BackgroundImage = UI.Properties.Resources.background_15;
            foreach (var chain in chainDetailses)
            {
                if (!chain.Items.Any()) continue;
                TabPage page = new TabPage(chain.ChainName);
                pricesOfChains.Add(chain);
                page.Controls.Add(new DisplayShoppingCart(chain) {Dock = DockStyle.Fill});

                chainsTabControl.TabPages.Add(page);
            }

            itemsListBox.DataSource = shoppingCart;
            itemsListBox.DisplayMember = "ItemName";


            var cheapestChain = pricesOfChains.First();
            StringBuilder statisticText = new StringBuilder("הרשת הזולה ביותר: ");
            statisticText.AppendLine(cheapestChain.ChainName);
            var priceText = cheapestChain.TotalSum.ToString();
            statisticText.Append("מחיר לסל: ").AppendLine(priceText);
            var precentText = string.Format("{0:0.00}", cheapestChain.PrecentOfCart) + "%";
            statisticText.Append("אחוז פריטים מהסל המקורי: ").AppendLine(precentText);
            dataLabel.Text = statisticText.ToString();

        }

        private void graphButton_Click(object sender, EventArgs e)
        {
            ChartOfPrices windowChartOfPrices = new ChartOfPrices(pricesOfChains);
            windowChartOfPrices.ShowDialog();
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void graphPictureBox_Click(object sender, EventArgs e)
        {
            graphButton_Click(this, new EventArgs());
        }
    }
}