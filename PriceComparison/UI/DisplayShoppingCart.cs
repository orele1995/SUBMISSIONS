using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceComperationController;
using PriceComperationModel;

namespace UI
{
    public partial class DisplayShoppingCart : UserControl
    {
        private readonly PriceControl _control = PriceControl.ThePriceControl;

        private BindingList<DisplayItem> _displayItems;

        public DisplayShoppingCart(List<Price> prices )
        {
            InitializeComponent();
            _displayItems = new BindingList<DisplayItem>(_control.GetDisplayItems(prices).ToList());           
            ItemsDataGridView.DataSource = _displayItems;
            ChainNameLabel.Text = _control.GetChainOfPrice(prices.First()).Chain_name;
            totalPriceLabel.Text = prices.Sum(p => p.ItemPrice).ToString(CultureInfo.InvariantCulture);

            ItemsDataGridView.Columns[0].Visible = false;
            ItemsDataGridView.Columns[1].HeaderText = "קוד חנות";
            ItemsDataGridView.Columns[2].HeaderText = "כתובת";
            ItemsDataGridView.Columns[3].HeaderText = "עיר";
            ItemsDataGridView.Columns[4].HeaderText = "מיקוד";
            ItemsDataGridView.Columns[5].HeaderText = "שם המוצר";
            ItemsDataGridView.Columns[6].HeaderText = "שם יצרן";
            ItemsDataGridView.Columns[7].HeaderText = "מחיר";
            ItemsDataGridView.Columns[8].HeaderText = "כמות";

            for (int i = 0; i < 7; i++)
            {
                ItemsDataGridView.Columns[i].ReadOnly = true;
            }
            

        }

        private void ItemsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            //  if (ItemsDataGridView[e.RowIndex,e.ColumnIndex].)
            totalPriceLabel.Text = _displayItems.Sum(p => p.ItemPrice*p.Quantity).ToString(CultureInfo.InvariantCulture);

        }

        private void ItemsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ItemsDataGridView.Rows[e.RowIndex].ErrorText = "";

            var text = e.FormattedValue.ToString();
            int num;
            if (string.IsNullOrEmpty(text))
            {
                ItemsDataGridView.Rows[e.RowIndex].ErrorText =
                    "הכנס ערך";
                e.Cancel = true;

            }
            else if (!int.TryParse(text, out num))
            {
                ItemsDataGridView.Rows[e.RowIndex].ErrorText =
                       "יש להכניס מספרים בלבד";
                e.Cancel = true;

            }

        }
    }
}
