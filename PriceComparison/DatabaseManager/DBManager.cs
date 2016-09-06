using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
   public class DBManager
    {
        PricesContext context;

        private static DBManager theDBManager;

        private DBManager() {
            context = new PricesContext();
        }

        public static DBManager TheDBManager
        {
            get
            {
                if (theDBManager == null)
                {
                    theDBManager = new DBManager();
                }
                return theDBManager;
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
            if (!context.Items.Any(i => i.ItemID.Equals(item.ItemID)))
                if (item.ItemID > 1000000000)
                    context.Items.AddOrUpdate(item);
            context.SaveChanges();
        }
        public void AddOrUpdatePrice(Price price)
        {
            if (!context.Prices.Any(p => p.ItemID.Equals(price.ItemID) && p.StoreID.Equals(price.StoreID)))
                context.Prices.AddOrUpdate(price);
            context.SaveChanges();
        }

        public void AddOrUpdateStores(IEnumerable<Store> stores)
        {
            foreach (var store in stores)
            {
                AddOrUpdateStore(store);
                context.SaveChanges();
            }

        }
        public void AddOrUpdatePrices(IEnumerable<Price> prices)
        {
            foreach (var price in prices)
            {
                AddOrUpdatePrice(price);
                context.SaveChanges();
            }
        }
        public void AddOrUpdateItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                AddOrUpdateItem(item);
                context.SaveChanges();
            }
        }

        public int FindStoreIdByCodeAndChain(int storeCode, long chainId)
        {
            return context.Stores
                .Where(s => s.Chain_id == chainId && s.Store_code == storeCode)
                .Select(s => s.StoreID).FirstOrDefault();
        }

        

    }
}
