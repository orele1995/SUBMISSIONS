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

        private readonly ChainDetails _chainDetails;

        public DisplayShoppingCart(ChainDetails chainDetails)
        {
            _chainDetails = chainDetails;
            InitializeComponent();

            ItemsDataGridView.DataSource = chainDetails.Items;
            ChainNameLabel.Text = chainDetails.ChainName;
            totalPriceLabel.Text = chainDetails.TotalSum.ToString();
            ItemsDataGridView.Columns[0].HeaderText = "שם המוצר";
            ItemsDataGridView.Columns[1].HeaderText = "שם יצרן";
            ItemsDataGridView.Columns[2].HeaderText = "מחיר";
            ItemsDataGridView.Columns[3].HeaderText = "רשת";
            ItemsDataGridView.Columns[4].HeaderText = "קוד חנות";
            ItemsDataGridView.Columns[5].HeaderText = "עיר";
            ItemsDataGridView.Columns[6].HeaderText = "כתובת";
            ItemsDataGridView.Columns[7].HeaderText = "כמות";

            for (int i = 0; i < 6; i++)
            {
                ItemsDataGridView.Columns[i].ReadOnly = true;
            }
        }

        private void ItemsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //  if (ItemsDataGridView[e.RowIndex,e.ColumnIndex].)
            totalPriceLabel.Text = _chainDetails.TotalSum.ToString();
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

        private void DisplayShoppingCart_Load(object sender, EventArgs e)
        {

        }
    }
}