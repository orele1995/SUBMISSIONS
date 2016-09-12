using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PriceComperationModel;

namespace DatabaseManager
{
    public interface IPriceComperationDataManager
    {

        void AddOrUpdateStore(Store store);
        void AddOrUpdateChain(Chain chain);
        void AddOrUpdateItem(Item item);
        void AddOrUpdatePrice(Price price);

        void AddOrUpdateStores(IEnumerable<Store> stores);
        void AddOrUpdatePrices(IEnumerable<Price> prices);
        void AddOrUpdateItems(IEnumerable<Item> items);
        void AddOrUpdateChains(IEnumerable<Chain> chains);

        Item GetItem(long itemId);
        Store GetStore(int storeId);
        Chain GetChain(long chainId);
        Price GetPrice(int priceId);

        IEnumerable<Store> GetStores();
        IEnumerable<Chain> GetChains();
        IEnumerable<Item> GetItems();
        IEnumerable<Price> GetPrices();

        IEnumerable<Store> GetStores(Expression<Func<Store, bool>> expression);
        IEnumerable<Chain> GetChains(Expression<Func<Chain, bool>> expression);
        IEnumerable<Item> GetItems(Expression<Func<Item, bool>> expression);
        IEnumerable<Price> GetPrices(Expression<Func<Price, bool>> expression);

        Store GetStore(Expression<Func<Store, bool>> expression);
        Chain GetChain(Expression<Func<Chain, bool>> expression);
        Item GetItem(Expression<Func<Item, bool>> expression);
        Price GetPrice(Expression<Func<Price, bool>> expression);

        int FindStoreIdByCodeAndChain(int storeCode, long chainId);

        //IEnumerable<Store> GetStoresOfChain(long chainId);
        //IEnumerable<Store> GetStoresOfChain(long chainId, string city);
        //IEnumerable<Price> GetPricesOfChain(long chainId);
        //IEnumerable<Price> GetPricesOfItem(long itemId);

        //IEnumerable<Item> GetItemsOfChain(long chainId);
        //IEnumerable<Item> GetItemsOfStore(int storeId);

        //IEnumerable<string> GetAllCities();
        //IEnumerable<string> GetCitiesOfChain(long chainId);

        //IEnumerable<Item> AllItemsIncluded(long chainId, IEnumerable<Item> items);
        //IEnumerable<Item> AllItemsIncluded(int storeId, IEnumerable<Item> items);

        //bool IsItemInStore(Item item, int storeId);
        //bool IsItemInChain(Item item, long chainId);
        //bool IsPriceInChain(Price price, long chainId);
        //bool IsPriceInStore(Price price, int storeId);

        //int FindStoreIdByCodeAndChain(int storeCode, long chainId);
        //bool IsItemInAllChains(Item item);
        //Price GetLowestPriceOfItem(long itemId);
        //Price GetLowestPriceOfItem(long itemId, long chainId);
        //bool IsStoreInChain(long chainId, int storeId);

        //IEnumerable<Price> GetPricesOfItems(IEnumerable<Item> items, Predicate<Price> filter);

        //Dictionary<long, IEnumerable<Price>> PricesForCart(IEnumerable<Item> shoppingCart);

    }
}
