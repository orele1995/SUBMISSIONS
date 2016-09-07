using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DatabaseManager
{
    public class DbManager
    {
        private readonly PricesContext context;

        private static DbManager theDbManager;

        private DbManager()
        {
            context = new PricesContext();
        }

        public static DbManager TheDbManager
        {
            get
            {
                if (theDbManager == null)
                {
                    theDbManager = new DbManager();
                }
                return theDbManager;
            }
        }

        public void AddOrUpdateStore(Store store)
        {
            if (!context.Stores.Any(s => s.StoreID.Equals(store.StoreID)))
                context.Stores.AddOrUpdate(store);
            context.SaveChanges();
        }

        public void AddOrUpdateChain(Chain chain)
        {
            if (!context.Chains.Any(c => c.ChainID.Equals(chain.ChainID)))
                context.Chains.AddOrUpdate(chain);
            context.SaveChanges();
        }

        public void AddOrUpdateItem(Item item)
        {
            //if (!context.Items.Any(i => i.ItemID.Equals(item.ItemID)))
            try
            {
                if (item.ItemID > 1000000000)
                {
                    context.Items.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                context.Items.Remove(item);
            }

        }

        public void AddOrUpdatePrice(Price price)
        {
            // if (!context.Prices.Any(p => p.ItemID.Equals(price.ItemID) && p.StoreID.Equals(price.StoreID)))
            try
            {
                context.Prices.Add(price);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                context.Prices.Remove(price);

            }

        }

        public void AddOrUpdateStores(IEnumerable<Store> stores)
        {
            foreach (var store in stores)
            {
                AddOrUpdateStore(store);
            }
            context.SaveChanges();
        }

        public void AddOrUpdatePrices(IEnumerable<Price> prices)
        {
            foreach (var price in prices)
            {
                AddOrUpdatePrice(price);
            }
            context.SaveChanges();
        }

        public void AddOrUpdateItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                AddOrUpdateItem(item);
            }
            context.SaveChanges();

        }

        public void AddOrUpdateChains(IEnumerable<Chain> chains)
        {
            foreach (var chain in chains)
            {
                AddOrUpdateChain(chain);
            }
            context.SaveChanges();

        }

        public int FindStoreIdByCodeAndChain(int storeCode, long chainId)
        {
            return context.Stores
                .Where(s => s.ChainID == chainId && s.Store_code == storeCode)
                .Select(s => s.StoreID).FirstOrDefault();
        }

        public Item GetItem(long itemId)
        {
            return context.Items.FirstOrDefault(i => i.ItemID == itemId);
        }

        public Store GetStore(int storeId)
        {
            return context.Stores.FirstOrDefault(s => s.StoreID == storeId);
        }

        public Chain GetChain(long chainId)
        {
            return context.Chains.FirstOrDefault(c=> c.ChainID == chainId);
       }

        public Price GetPrice(int priceId)
        {
            return context.Prices.FirstOrDefault(p => p.PriceID == priceId);
       }

        public IEnumerable<Store> GetStores()
        {
            return context.Stores.ToList();
        }

        public IEnumerable<Chain> GetChains()
        {
            return context.Chains.ToList();
        }

        public IEnumerable<Item> GetItems()
        {
            return context.Items.ToList();
        }

        public Price GetLowestPriceOfItem(long itemId)
        {
            return GetPricesOfItem(itemId).FirstOrDefault();
        }

        public IEnumerable<Store> GetStoresOfChain(long chainId)
        {
            return context.Stores.Where(s => s.ChainID == chainId).Distinct().ToList();
        }

        public IEnumerable<Store> GetStoresOfChain(long chainId, string city)
        {
            return context.Stores.Where(s => s.ChainID == chainId && s.City == city).Distinct().ToList();
        }

        public IEnumerable<Price> GetPricesOfChain(long chainId)
        {
            return GetStoresOfChain(chainId).Select(s => s.Prices).SelectMany(p => p).ToList();
        }

        public IEnumerable<Price> GetPricesOfItem(long itemId)
        {
            return context.Items.FirstOrDefault(i => i.ItemID == itemId)?.Prices.OrderBy(p => p.ItemPrice).ToList();
        }

        public IEnumerable<string> GetAllCities()
        {
            return context.Stores.Select(s => s.City).Distinct().ToList();
        }

        public IEnumerable<string> GetCitiesOfChain(long chainId)
        {
            return context.Stores.Where(s => s.ChainID == chainId).Select(s => s.City).Distinct().ToList();
        }

        public IEnumerable<Item> GetItemsOfChain(long chainId)
        {
            return
                context.Prices.Where(p => GetStoresOfChain(chainId).FirstOrDefault(s => p.StoreID == s.StoreID) != null)
                    .Select(p => GetItem(p.ItemID)).Distinct().ToList();
        }

        public IEnumerable<Item> GetItemsOfStore(int storeId)
        {
            return GetStore(storeId).Prices.Select(p => GetItem(p.ItemID)).ToList();
        }

        public IEnumerable<Item> AllItemsIncluded(long chainId, IEnumerable<Item> items)
        {
            var includedItems = new List<Item>();
            foreach (var item in items)
            {
                if (IsItemInChain(item, chainId))
                    includedItems.Add(item);
            }

            return includedItems;
        }

        public IEnumerable<Item> AllItemsIncluded(int storeId, IEnumerable<Item> items)
        {
            var includedItems = new List<Item>();
            foreach (var item in items)
            {
                if (IsItemInStore(item, storeId))
                    includedItems.Add(item);
            }

            return includedItems;
        }

        public bool IsItemInStore(Item item, int storeId)
        {
            return GetItemsOfStore(storeId).FirstOrDefault(i => i.ItemID == item.ItemID) != null;

        }

        public bool IsItemInChain(Item item, long chainId)
        {
            return GetItemsOfChain(chainId).FirstOrDefault(i => i.ItemID == item.ItemID) != null;
        }
        public bool IsPriceInChain(Price price ,long chainId)
        {
            return GetStoresOfChain(chainId).FirstOrDefault(s => s.StoreID == price.StoreID) != null;
        }
        public bool IsPriceInStore(Price price, int storeId)
        {
            return price.StoreID == storeId;
        }

        public IEnumerable<Price> GetPricesOfItems(IEnumerable<Item> items, Predicate<Price> filter)
        {
            return items.Select(i => i.Prices.Where(p => filter(p)).OrderBy(p => p.ItemPrice).FirstOrDefault()).ToList();
        }

        ~DbManager()
        {
            context.Dispose();
        }
    }
}
