using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
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
            var chain = context.Chains.FirstOrDefault(c => c.ChainID == store.ChainID);
            if (chain != null && chain.Stores.All(s => s.StoreCode != store.StoreCode)) 
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
            if (item.ItemID <= 99999999) return;
            if (context.Items.Any(i => i.ItemID.Equals(item.ItemID))) return;
            context.Items.Add(item);
            context.SaveChanges();
        }  
        public void AddOrUpdatePrice(Price price)
        {
            if( GetStore(price.StoreID).Prices.Any(p=>p.ItemID == price.ItemID)) return;
            context.Prices.Add(price);
            context.SaveChanges();
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

        public IEnumerable<Store> GetStores(Expression<Func<Store, bool>> expression)
        {
            return context.Stores.Where(expression).Distinct();
        }
        public IEnumerable<Chain> GetChains(Expression<Func<Chain, bool>> expression)
        {
            return context.Chains.Where(expression).Distinct();
        }
        public IEnumerable<Item> GetItems(Expression<Func<Item, bool>> expression)
        {
            return context.Items.Where(expression).Distinct();
        }
        public IEnumerable<Price> GetPrices(Expression<Func<Price, bool>> expression)
        {
            return context.Prices.Where(expression).Distinct();
        }

        public Store GetStore(Expression<Func<Store, bool>> expression)
        {
            return context.Stores.FirstOrDefault(expression);
        }
        public Chain GetChain(Expression<Func<Chain, bool>> expression)
        {
            return context.Chains.FirstOrDefault(expression);
        }
        public Item GetItem(Expression<Func<Item, bool>> expression)
        {
            return context.Items.FirstOrDefault(expression);
        }
        public Price GetPrice(Expression<Func<Price, bool>> expression)
        {
            return context.Prices.FirstOrDefault(expression);
        }

        public int FindStoreIdByCodeAndChain(int storeCode, long chainId)
        {
            return context.Stores
                .Where(s => s.ChainID == chainId && s.StoreCode == storeCode)
                .Select(s => s.StoreID).FirstOrDefault();
        }

       

    }
}
