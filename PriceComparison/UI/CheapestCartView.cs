using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PriceComperationController;
using Excel = Microsoft.Office.Interop.Excel;



namespace UI
{
    public partial class CheapestCartView : Form
    {
        private readonly BindingList<DisplayItem> _prices;
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        public CheapestCartView(BindingList<DisplayItem> prices)
        {
            InitializeComponent();

            _prices = prices;
            ItemsDataGridView.DataSource = _prices;
            totalPriceLabel.Text = _prices.Sum(p=> p.ItemPrice* p.Quantity).ToString();

            ItemsDataGridView.Columns[0].HeaderText = "שם המוצר"; 
            ItemsDataGridView.Columns[1].HeaderText = "שם יצרן"; 
            ItemsDataGridView.Columns[2].HeaderText = "מחיר";  
            ItemsDataGridView.Columns[3].HeaderText = "רשת";  
            ItemsDataGridView.Columns[4].HeaderText = "קוד חנות";
            ItemsDataGridView.Columns[5].HeaderText = "עיר";
            ItemsDataGridView.Columns[6].HeaderText = "כתובת";
            ItemsDataGridView.Columns[7].HeaderText = "כמות";

            for (int i = 0; i <6; i++)
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
             //   e.Cancel = true;

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
            ExportToExcel();
        }

        
        private void ExportToExcel()
        {
            // Creating a Excel object. 
            Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < ItemsDataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < ItemsDataGridView.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = ItemsDataGridView.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = ItemsDataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("הטבלה יוצאה בהצלחה");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }



        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
