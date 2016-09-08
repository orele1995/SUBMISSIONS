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

        public ViewItems(Dictionary<long, IEnumerable<Price>> pricesOfChains)
        {
            InitializeComponent();
            chainsTabControl.TabPages.Clear();
            chainsTabControl.RightToLeftLayout = true;
            foreach (var chain in pricesOfChains)
            {
                if (!chain.Value.Any()) continue;
                string chainName = _control.GetChain(chain.Key).Chain_name;
                TabPage page = new TabPage(chainName);
                page.Controls.Add(new DisplayShoppingCart(chain.Value.ToList()));
                chainsTabControl.TabPages.Add(page);
            }
        }
    }
}