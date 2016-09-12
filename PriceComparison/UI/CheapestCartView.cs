using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PriceComperationController;


namespace UI
{
    public partial class CheapestCartView : Form
    {
        private readonly BindingList<DisplayItem> _prices;

        public CheapestCartView(BindingList<DisplayItem> prices)
        {
            InitializeComponent();

            _prices = prices;
            ItemsDataGridView.DataSource = _prices;
            totalPriceLabel.Text = _prices.Sum(p=> p.ItemPrice* p.Quantity).ToString();

            ItemsDataGridView.Columns[0].HeaderText = "רשת";
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
            totalPriceLabel.Text = _prices.Sum(p => p.ItemPrice * p.Quantity).ToString();

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
            //    e.Cancel = true;

            }
            else if (!int.TryParse(text, out num))
            {
                ItemsDataGridView.Rows[e.RowIndex].ErrorText =
                       "יש להכניס מספרים בלבד";
             //   e.Cancel = true;

            }

        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }

        //private void ExportToExcel()
        //{
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    object misValue = System.Reflection.Missing.Value;

        //    xlApp = new Excel.Application();
        //    xlWorkBook = xlApp.Workbooks.Add(misValue);
        //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //    int i = 0;
        //    int j = 0;

        //    for (i = 0; i <= dataGridView1.RowCount - 1; i++)
        //    {
        //        for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
        //        {
        //            DataGridViewCell cell = dataGridView1[j, i];
        //            xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
        //        }
        //    }

        //    xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //    xlWorkBook.Close(true, misValue, misValue);
        //    xlApp.Quit();

        //    releaseObject(xlWorkSheet);
        //    releaseObject(xlWorkBook);
        //    releaseObject(xlApp);

        //    MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
        //}

    
    }
}
