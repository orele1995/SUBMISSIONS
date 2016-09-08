using DatabaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PriceComperationModel;

namespace PriceComperationController
{
    public class PriceControl
    {
        private readonly IPriceComperationDataManager _manager;

        #region Singelton pattern

        private static PriceControl _thePriceControl;

        private PriceControl()
        {
            _manager = PriceControllerFactory.TheFactory.GetPriceComperationDataManager();

        }

        public static PriceControl ThePriceControl
        {
            get
            {
                if (_thePriceControl == null)
                {
                    _thePriceControl = new PriceControl();
                }
                return _thePriceControl;
            }
        }

        #endregion

        #region get 

        public Item GetItem(long itemId)
        {
            return _manager.GetItems().FirstOrDefault(i => i.ItemID == itemId);
        }

        public Store GetStore(int storeId)
        {
            return _manager.GetStores().FirstOrDefault(s => s.StoreID == storeId);
        }

        public Chain GetChain(long chainId)
        {
            return _manager.GetChains().FirstOrDefault(c => c.ChainID == chainId);
        }

        public Price GetPrice(int priceId)
        {
            return _manager.GetPrices().FirstOrDefault(p => p.PriceID == priceId);
        }

        #endregion

        #region get collection

        public IEnumerable<Store> GetStores()
        {
            return _manager.GetStores().ToList();
        }

        public IEnumerable<Chain> GetChains()
        {
            return _manager.GetChains().ToList();
        }

        public IEnumerable<Item> GetItems()
        {
            return _manager.GetItems().ToList();
        }

        public IEnumerable<Price> GetPrices()
        {
            return _manager.GetPrices().ToList();
        }

        #endregion

        #region special get collection

        public IEnumerable<Store> GetStoresOfChain(long chainId)
        {
            return _manager.GetStores().Where(s => s.ChainID == chainId).Distinct().ToList();
        }

        public IEnumerable<Store> GetStoresOfChain(long chainId, string city)
        {
            return _manager.GetStores().Where(s => s.ChainID == chainId && s.City == city).Distinct().ToList();
        }

        public IEnumerable<Price> GetPricesOfChain(long chainId)
        {
            return GetStoresOfChain(chainId).Select(s => s.Prices).SelectMany(p => p).ToList();
        }

        public IEnumerable<Price> GetPricesOfItem(long itemId)
        {
            return _manager.GetItems().FirstOrDefault(i => i.ItemID == itemId)?.Prices.OrderBy(p => p.ItemPrice).ToList();

        }

        public IEnumerable<Item> GetItemsOfChain(long chainId)
        {
            return
                _manager.GetPrices()
                    .Where(p => GetStoresOfChain(chainId).FirstOrDefault(s => p.StoreID == s.StoreID) != null)
                    .Select(p => _manager.GetItem(p.ItemID)).Distinct().ToList();
        }

        public IEnumerable<Item> GetItemsOfStore(int storeId)
        {
            return _manager.GetStore(storeId).Prices.Select(p => _manager.GetItem(p.ItemID)).ToList();
        }

        public IEnumerable<string> GetAllCities()
        {
            return _manager.GetStores().Select(s => s.City).Distinct().ToList();
        }

        public IEnumerable<string> GetCitiesOfChain(long chainId)
        {
            return _manager.GetStores().Where(s => s.ChainID == chainId).Select(s => s.City).Distinct().ToList();
        }

        public IEnumerable<Price> GetPricesOfItems(IEnumerable<Item> items, Predicate<Price> filter)
        {
            return items.Select(i => i.Prices.Where(p => filter(p)).OrderBy(p => p.ItemPrice).FirstOrDefault()).ToList();
        }

        public Dictionary<long, IEnumerable<Price>> PricesForCart(IEnumerable<Item> shoppingCart)
        {
            var result = new Dictionary<long, IEnumerable<Price>>();
            foreach (var chain in _manager.GetChains())
            {
                List<Price> pricesOfChain = new List<Price>();
                foreach (var item in shoppingCart)
                {
                    var lowestPriceOfItem = GetLowestPriceOfItem(item.ItemID, chain.ChainID);
                    if (lowestPriceOfItem != null) pricesOfChain.Add(lowestPriceOfItem);
                }
                result.Add(chain.ChainID, pricesOfChain);
            }
            return result;
        }

        public IEnumerable<DisplayItem> GetDisplayItems(IEnumerable<Price> prices)
        {
            var result = from price in prices
                let store = _manager.GetStore(price.StoreID)
                let item = _manager.GetItem(price.ItemID)
                let chain = _manager.GetChain(store.ChainID)
                select new DisplayItem()
                {
                    ItemPrice = price.ItemPrice,
                    StoreCode = store.Store_code,
                    City = store.City,
                    Address = store.Address,
                    ItemName = item.ItemName,
                    ChainName = chain.Chain_name,
                    ManufacturerName = item.ManufacturerName,
                    Quantity = 1,
                    ZipCode = store.ZipCode,
                };
            return result.ToList();

        }

        #endregion

        #region predicates

        public bool IsItemInStore(Item item, int storeId)
        {
            return GetItemsOfStore(storeId).FirstOrDefault(i => i.ItemID == item.ItemID) != null;
        }

        public bool IsItemInChain(Item item, long chainId)
        {
            return GetItemsOfChain(chainId).FirstOrDefault(i => i.ItemID == item.ItemID) != null;
        }

        public bool IsPriceInChain(Price price, long chainId)
        {
            return GetStoresOfChain(chainId).FirstOrDefault(s => s.StoreID == price.StoreID) != null;
        }

        public bool IsPriceInStore(Price price, int storeId)
        {
            return price.StoreID == storeId;
        }

        public bool IsStoreInChain(long chainId, int storeId)
        {
            return GetStoresOfChain(chainId).FirstOrDefault(s => s.StoreID == storeId) != null;
        }

        public bool IsItemInAllChains(Item item)
        {
            foreach (var chain in _manager.GetChains())
            {
                if (!IsItemInChain(item, chain.ChainID)) return false;
            }
            return true;
        }


        #endregion

        #region others
        public IEnumerable<Item> AllItemsIncluded(long chainId, IEnumerable<Item> items)
        {
            var includedItems = new List<Item>();
            foreach (var item in items)
            {
                if (IsItemInChain(item, chainId))
                    includedItems.Add(item);
            }

            return includedItems.ToList();
        }

        public IEnumerable<Item> AllItemsIncluded(int storeId, IEnumerable<Item> items)
        {
            var includedItems = new List<Item>();
            foreach (var item in items)
            {
                if (IsItemInStore(item, storeId))
                    includedItems.Add(item);
            }

            return includedItems.ToList();
        }

        public Price GetLowestPriceOfItem(long itemId)
        {
            return GetPricesOfItem(itemId).Min(i => i);
        }

        public Price GetLowestPriceOfItem(long itemId, long chainId)
        {
            return GetPricesOfItem(itemId).Where(p => IsStoreInChain(chainId, p.StoreID))?.Min(i => i);
        }
        public Chain GetChainOfPrice (Price p)
        {
            return GetChain(GetStore(p.StoreID).ChainID);
        }
        #endregion

    }
}