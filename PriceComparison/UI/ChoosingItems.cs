using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseManager;

namespace UI
{
    public partial class ChoosingItems : Form
    {
        private readonly DbManager _manager = DbManager.TheDbManager;
        private BindingList<Item> _shoppingCart = new BindingList<Item>();
        private int _selectedChain = -1;
        private int _selectedStore = -1;

        public ChoosingItems()
        {
            InitializeComponent();

            ItemsCheckedListBox.DataSource = _manager.GetItems().OrderBy(i => i.ItemName).ToList();
            ItemsCheckedListBox.DisplayMember = "ItemName";
            chainsComboBox.DataSource = _manager.GetChains();
            chainsComboBox.DisplayMember = "Chain_name";
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
            IEnumerable<Price> prices = new List<Price>();
            if (_selectedStore != -1)
            {
                prices = _manager.GetPricesOfItems(_shoppingCart, FilterCartByStore);
            }
            else if (_selectedChain != -1)
            {
                prices = _manager.GetPricesOfItems(_shoppingCart, FilterCartByChain);
            }
            else
            {
                prices = _manager.GetPricesOfItems(_shoppingCart, p => true);
            }
            ViewItems viewItemsWindow = new ViewItems(prices);
            viewItemsWindow.ShowDialog();
        }

        private void chainsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chainsComboBox.SelectedIndex == -1) return;
            var chainId = ((Chain) chainsComboBox.SelectedItem).ChainID;
            storesComboBox.DataSource = _manager.GetStoresOfChain(chainId);

            chainsComboBox.ResetText();
            chainsComboBox.SelectedIndex = -1;

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
            var includedItems = _manager.AllItemsIncluded(store.StoreID, _shoppingCart);
            if (includedItems.Count() == _shoppingCart.Count)
            {
                ItemsCheckedListBox.DataSource = _manager.GetItemsOfStore(store.StoreID);
                ItemsCheckedListBox.DisplayMember = "ItemName";

                return;
            }

            DialogResult dialogResult =
                MessageBox.Show(
                    "כמה מהפריטים שבחרת אינם מתאימים לסינון. האם אתה בטוח שברצונך לסנן?\n שים לב שפריטים שאינם מתאימים לסינון ימחקו",
                    "שגיאה",
                    MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            ItemsCheckedListBox.DataSource = _manager.GetItemsOfStore(store.StoreID);
            ItemsCheckedListBox.DisplayMember = "ItemName";

            _shoppingCart = new BindingList<Item>(includedItems.ToList());
            selectedItemsListBox.DataSource = _shoppingCart;
        }

        private void ChainFilter()
        {
            var chain = (Chain)chainsComboBox.SelectedItem;
            var includedItems = _manager.AllItemsIncluded(chain.ChainID, _shoppingCart);
            if (includedItems.Count() == _shoppingCart.Count)
            {
                ItemsCheckedListBox.DataSource = _manager.GetItemsOfChain(chain.ChainID);
                ItemsCheckedListBox.DisplayMember = "ItemName";

                return;
            }
            DialogResult dialogResult =
                MessageBox.Show(
                    "כמה מהפריטים שבחרת אינם מתאימים לסינון. האם אתה בטוח שברצונך לסנן?\n שים לב שפריטים שאינם מתאימים לסינון ימחקו",
                    "שגיאה",
                    MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            ItemsCheckedListBox.DataSource = _manager.GetItemsOfChain(chain.ChainID);
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
            ItemsCheckedListBox.DataSource = _manager.GetItems();
        }

        private bool FilterCartByChain(Price price)
        {
            return _manager.IsPriceInChain(price, _selectedChain);
        }

        private bool FilterCartByStore(Price price)
        {
            return _manager.IsPriceInStore(price, _selectedStore);
        }
    }
}
