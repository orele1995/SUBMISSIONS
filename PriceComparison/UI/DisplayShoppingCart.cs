using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseManager;

namespace UI
{
    public partial class DisplayShoppingCart : UserControl
    {
        private readonly DbManager _manager = DbManager.TheDbManager;
        private BindingList<DisplayItem> _displayItems = new BindingList<DisplayItem>();

        public DisplayShoppingCart(List<Price> prices )
        {
            InitializeComponent();
            
            string chainName = "שם הרשת";
            foreach (var price in prices)
            {
                
                Store store = _manager.GetStore(price.StoreID);
                Item item = _manager.GetItem(price.ItemID);
                Chain chain = _manager.GetChain(store.ChainID);
                chainName = chain.Chain_name;
                var displayItem = new DisplayItem()
                {
                    ItemPrice = price.ItemPrice,
                    Store_code = store.Store_code,
                    City = store.City,
                    Address = store.Address,
                    ItemName = item.ItemName,
                    Chain_name = chain.Chain_name,
                    ManufacturerName = item.ManufacturerName,
                    Quantity = price.Quantity,
                    ZipCode = store.ZipCode,
                    Amount = 1
                };
                _displayItems.Add(displayItem);
            }
            ItemsDataGridView.DataSource = _displayItems;
            ChainNameLabel.Text = chainName;
            totalPriceLabel.Text = prices.Sum(p => p.ItemPrice).ToString();
        }
    }
}
