using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using PriceComperationModel;

namespace DatabaseManager
{
    public class DbManager: IPriceComperationDataManager

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

        public Store GetStore(int storeId)
        {
            return context.Stores.FirstOrDefault(s => s.StoreID == storeId);
        }
        public Chain GetChain(long chainId)
        {
            return context.Chains.FirstOrDefault(c => c.ChainID == chainId);
        }
        public Price GetPrice(int priceId)
        {
            return context.Prices.FirstOrDefault(p => p.PriceID == priceId);
        }
        public Item GetItem(long itemId)
        {
            return context.Items.FirstOrDefault(i => i.ItemID == itemId);
        }

        public IEnumerable<Store> GetStores()
        {
            return context.Stores;
        }
        public IEnumerable<Chain> GetChains()
        {
            return context.Chains;
        }
        public IEnumerable<Item> GetItems()
        {
            return context.Items;
        }
        public IEnumerable<Price> GetPrices()
        {
            return context.Prices;
        }

        public int FindStoreIdByCodeAndChain(int storeCode, long chainId)
        {
            return context.Stores
                .Where(s => s.ChainID == chainId && s.Store_code == storeCode)
                .Select(s => s.StoreID).FirstOrDefault();
        }

    }
}
