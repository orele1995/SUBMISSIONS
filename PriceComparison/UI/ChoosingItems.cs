using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using PriceComperationController;
using PriceComperationModel;


namespace UI
{
    public partial class ChoosingItems : Form
    {
        private BindingList<Item> _shoppingCart = new BindingList<Item>();
        private int _selectedChain = -1;
        private int _selectedStore = -1;
        private readonly PriceControl _control = PriceControl.ThePriceControl;
       
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        public ChoosingItems()
        {
            InitializeComponent();

            ItemsCheckedListBox.DataSource = _control.GetItems().OrderBy(i => i.ItemName).ToList();
            ItemsCheckedListBox.DisplayMember = "ItemName";
            chainsComboBox.DataSource = _control.GetChains();
            chainsComboBox.DisplayMember = "ChainName";
            // cityComboBox.DataSource = Manager.GetAllCities();
            selectedItemsListBox.DataSource = _shoppingCart;
            selectedItemsListBox.DisplayMember = "ItemName";

            chainsComboBox.ResetText();
            storesComboBox.ResetText();
            chainsComboBox.SelectedIndex = -1;
            storesComboBox.SelectedIndex = -1;


        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            BindingList<DisplayItem> prices;
            if (_selectedStore != -1)
            {
                prices = new BindingList<DisplayItem>(_control.GetPricesOfItems(_shoppingCart, FilterCartByStore).ToList());
            }
            else if (_selectedChain != -1)
            {
                prices = new BindingList<DisplayItem>(_control.GetPricesOfItems(_shoppingCart, FilterCartByChain).ToList());
            }
            else
            {
                prices = new BindingList<DisplayItem>(_control.GetPricesOfItems(_shoppingCart, p => true).ToList());

            }
            CheapestCartView cheapestCartViewWindow = new CheapestCartView(prices);
            cheapestCartViewWindow.ShowDialog();
        }

        private void chainsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chainsComboBox.SelectedIndex == -1) return;
            var chainId = ((Chain) chainsComboBox.SelectedItem).ChainID;
            storesComboBox.DataSource = _control.GetStoresOfChain(chainId);

            storesComboBox.ResetText();
            storesComboBox.SelectedIndex = -1;

            /* var selectedCity = cityComboBox.SelectedItem;
            //if (selectedCity == null)
            //{
            //    storesComboBox.DataSource = Manager.GetStoresOfChain(chainId);
            //    cityComboBox.DataSource = Manager.GetCitiesOfChain(chainId);
            //}
            //else
            //{               
            //    storesComboBox.DataSource = Manager.GetStoresOfChain(chainId,selectedCity.ToString());

            }*/

        }

        //private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var selectedChain = chainsComboBox.SelectedItem;
        //    if (selectedChain != null)
        //    {
        //        storesComboBox.DataSource = Manager.GetStoresOfChain(((Chain)selectedChain).ChainID,
        //            cityComboBox.SelectedItem.ToString());
        //    }
        //}

        private void ItemsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            Item currentItem = (Item) this.ItemsCheckedListBox.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                _shoppingCart.Add(currentItem);
            }
            else
            {
                _shoppingCart.Remove(currentItem);
            }

        }

        private void selectorButton_Click(object sender, EventArgs e)
        {
            _selectedChain = chainsComboBox.SelectedIndex;
            _selectedStore = storesComboBox.SelectedIndex;
            if (_selectedChain == -1)
            {
                MessageBox.Show("בחר רשת");
                return;
            }
            if (_selectedStore == -1)
            {
                ChainFilter();
            }
            else
            {
                StoreFilter();
            }
        }

        private void StoreFilter()
        {
            var store = (Store) storesComboBox.SelectedItem;
            var includedItems = _control.AllItemsIncluded(store.StoreID, _shoppingCart);
            if (includedItems.Count() == _shoppingCart.Count)
            {
                ItemsCheckedListBox.DataSource = _control.GetItemsOfStore(store.StoreID);
                ItemsCheckedListBox.DisplayMember = "ItemName";

                return;
            }

            DialogResult dialogResult =
                MessageBox.Show(
                    "כמה מהפריטים שבחרת אינם מתאימים לסינון. האם אתה בטוח שברצונך לסנן?\n שים לב שפריטים שאינם מתאימים לסינון ימחקו",
                    "שגיאה",
                    MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            ItemsCheckedListBox.DataSource = _control.GetItemsOfStore(store.StoreID);
            ItemsCheckedListBox.DisplayMember = "ItemName";

            _shoppingCart = new BindingList<Item>(includedItems.ToList());
            selectedItemsListBox.DataSource = _shoppingCart;
        }

        private void ChainFilter()
        {
            var chain = (Chain)chainsComboBox.SelectedItem;
            var includedItems = _control.AllItemsIncluded(chain.ChainID, _shoppingCart);
            if (includedItems.Count() == _shoppingCart.Count)
            {
                ItemsCheckedListBox.DataSource = _control.GetItemsOfChain(chain.ChainID);
                ItemsCheckedListBox.DisplayMember = "ItemName";

                return;
            }
            DialogResult dialogResult =
                MessageBox.Show(
                    "כמה מהפריטים שבחרת אינם מתאימים לסינון. האם אתה בטוח שברצונך לסנן?\n שים לב שפריטים שאינם מתאימים לסינון ימחקו",
                    "שגיאה",
                    MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            ItemsCheckedListBox.DataSource = _control.GetItemsOfChain(chain.ChainID);
            ItemsCheckedListBox.DisplayMember = "ItemName";

            _shoppingCart = new BindingList<Item>(includedItems.ToList());
           
        }

        private void ChooseTextBox_TextChanged(object sender, EventArgs e)
        {
            ItemsCheckedListBox.SelectedIndex = ItemsCheckedListBox.FindString(ChooseTextBox.Text);
        }

        private void ItemsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            chainsComboBox.ResetText();
            storesComboBox.ResetText();
            chainsComboBox.SelectedIndex = -1;
            storesComboBox.SelectedIndex = -1;
            ItemsCheckedListBox.DataSource = _control.GetItems();
            ItemsCheckedListBox.DisplayMember = "ItemName";

        }

        private bool FilterCartByChain(Price price)
        {
            return _control.IsPriceInChain(price, _selectedChain);
        }

        private bool FilterCartByStore(Price price)
        {
            return _control.IsPriceInStore(price, _selectedStore);
        }

        private void compareButton_Click(object sender, EventArgs e)
        {
            if (_shoppingCart.Count() == 0)
            {
                MessageBox.Show("לא נבחרו פריטים להשוואה");
                return;
            }
            var result = _control.GetChainDetailses(_shoppingCart);
            ViewItems windowViewItems = new ViewItems(result, _shoppingCart);
            windowViewItems.ShowDialog();
        }

        private void selectedItemsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedItem = selectedItemsListBox.SelectedItem;
            if (selectedItem == null) return;
            _shoppingCart.Remove((Item)selectedItem);
            int index = ItemsCheckedListBox.Items.IndexOf(selectedItem);
            ItemsCheckedListBox.SetItemCheckState(index, CheckState.Unchecked);
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
