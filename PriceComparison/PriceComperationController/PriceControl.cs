﻿using DatabaseManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PriceComperationModel;
using DatabaseManagerFactory;

namespace PriceComperationController
{
    public class PriceControl
    {
        private readonly IPriceComperationDataManager _manager;

        #region Singelton pattern

        private static PriceControl _thePriceControl;

        private PriceControl()
        {
            _manager = PriceComperationDataManagerFactory.TheFactory.GetPriceComperationDataManager();

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
            return _manager.GetItem(itemId);
        }

        public Store GetStore(int storeId)
        {
            return _manager.GetStore(storeId);
        }

        public Chain GetChain(long chainId)
        {
            return _manager.GetChain(chainId);
        }

        public Price GetPrice(int priceId)
        {
            return _manager.GetPrice(priceId);
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
            return _manager.GetStores(s => s.ChainID == chainId).ToList();
        }

        public IEnumerable<Price> GetPricesOfItem(long itemId)
        {
            return _manager.GetItem(i => i.ItemID == itemId)?.Prices.OrderBy(p => p.ItemPrice).ToList();

        }

        public IEnumerable<Item> GetItemsOfChain(long chainId)
        {

            return _manager.GetChain(chainId).Stores.SelectMany(s => GetItemsOfStore(s.StoreID)).Distinct().ToList();
       }

        public IEnumerable<Item> GetItemsOfStore(int storeId)
        {
            var itemIds= _manager.GetStore(storeId).Prices.Select(i=> i.ItemID);
            return _manager.GetItems().Where(i => itemIds.Contains(i.ItemID)).ToArray();            
        }
        public IEnumerable<MultipleItem> GetMultipleItemsOfStore(int storeId)
        {
            var itemIds = _manager.GetStore(storeId).Prices.Select(i => i.ItemID);
            return _manager.GetItems()
                .Where(i => itemIds.Contains(i.ItemID))
                .Select(i=>new MultipleItem()
                {
                    ItemID = i.ItemID,
                    Quantity = i.Quantity,
                    ItemName = i.ItemName,
                    ManufacturerName = i.ManufacturerName,
                    NumOfItems = 1
                }).ToArray();
        }
        public IEnumerable<DisplayItem> GetPricesOfItems(IEnumerable<Item> items, Predicate<Price> filter)
        {
            var prices =
                items.Select(i => i.Prices.Where(p => filter(p)).OrderBy(p => p.ItemPrice).FirstOrDefault()).ToList();
            return GetDisplayItems(prices);
        }

        public Dictionary<long, IEnumerable<Price>> PricesForCart(IEnumerable<Item> shoppingCart)
        {
            var result = new Dictionary<long, IEnumerable<Price>>();
            foreach (var chain in _manager.GetChains())
            {
                var pricesOfChain =
                    shoppingCart.Select(item => GetLowestPriceOfItem(item.ItemID, chain.ChainID))
                        .Where(lowestPriceOfItem => lowestPriceOfItem != null)
                        .ToList();
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
                    StoreCode = store.StoreCode,
                    City = store.City,
                    Address = store.Address,
                    ItemName = item.ItemName,
                    ChainName = chain.ChainName,
                    ManufacturerName = item.ManufacturerName,
                    Quantity = 1,
                };
            return result.ToList();

        }

        public IEnumerable<ChainDetails> GetChainDetailses(IEnumerable<Item> shoppingCart)
        {
            var chainDetailsList = PricesForCart(shoppingCart).Select(price => new ChainDetails()
            {
                ChainId = price.Key,
                ChainName = _manager.GetChain(price.Key).ChainName,
                Items = new BindingList<DisplayItem>(GetDisplayItems(price.Value).ToList()),
                PrecentOfCart = calcPrecentsOfCart(GetDisplayItems(price.Value).ToList(), shoppingCart)
            }).ToList();
            return chainDetailsList.OrderByDescending(c => c.PrecentOfCart).ThenBy(c => c.TotalSum);
        }

        public IEnumerable<object> CulcCartPrices(IEnumerable<MultipleItem> cart, IEnumerable<Store> stores)
        {
            var result = new List<object>();
            foreach (var store in stores)
            {
                var prices = cart.Select(item =>
                {
                    var price = store.Prices.FirstOrDefault(p => item.ItemID == p.ItemID);
                    return new DisplayItem()
                    {
                        ItemPrice = price?.ItemPrice,
                        City = store.City,
                        ChainName = _manager.GetChain(store.ChainID).ChainName,
                        Address = store.Address,
                        Quantity = item.NumOfItems,
                        StoreCode = store.StoreCode,
                        ItemName = item.ItemName,
                        ManufacturerName = item.ManufacturerName
                    };
                }).ToArray();
                result.Add(new {
                    storeId=store.StoreID ,               
                    cart=prices,
                    sum= prices.Sum(i=>i.ItemPrice*i.Quantity)
                });
            }
            return result;
        }

        #endregion

        #region predicates

        public bool IsItemInChain(Item item, long chainId)
        {
            return GetItemsOfChain(chainId).FirstOrDefault(i => i.ItemID == item.ItemID) != null;
        }

        public bool IsPriceInStore(Price price, int storeId)
        {
            return price.StoreID == storeId;
        }

        public bool IsStoreInChain(long chainId, int storeId)
        {
            return GetStoresOfChain(chainId).FirstOrDefault(s => s.StoreID == storeId) != null;
        }

        public bool IsPriceInChain(Price price, long chainId)
        {
            return GetStoresOfChain(chainId).FirstOrDefault(s => s.StoreID == price.StoreID) != null;
        }

        #endregion

        #region others

        public IEnumerable<Item> AllItemsIncluded(long chainId, IEnumerable<Item> items)
        {
            var itemsInChain = GetItemsOfChain(chainId);
            var result = new List<Item>();

            foreach (var item in itemsInChain)
            {
                if (!items.Any(i => i.ItemID == item.ItemID)) continue;
                result.Add(item);
                if (result.Count == items.Count()) return result;
            }
            return result;
        }

        public IEnumerable<Item> AllItemsIncluded(int storeId, IEnumerable<Item> items)
        {
            var itemsInStore = GetItemsOfStore(storeId);
            var result = new List<Item>();

            foreach (var item in itemsInStore)
            {
                if (!items.Any(i => i.ItemID == item.ItemID)) continue;
                result.Add(item);
                if (result.Count == items.Count()) return result;
            }
            return result;
        }

        public Price GetLowestPriceOfItem(long itemId, long chainId)
        {
            return GetPricesOfItem(itemId).Where(p => IsStoreInChain(chainId, p.StoreID))?.Min(i => i);
        }

        private double calcPrecentsOfCart(List<DisplayItem> items, IEnumerable<Item> shoppingCart)
        {
            return items.Count*100/(double) shoppingCart.Count();
        }

        #endregion

        #region Unused

        //public IEnumerable<Store> GetStoresOfChain(long chainId, string city)
        //{
        //    return _manager.GetStores(s => s.ChainID == chainId && s.City == city).ToList();
        //}

        //public IEnumerable<string> GetAllCities()
        //{
        //    return _manager.GetStores().Select(s => s.City).Distinct().ToList();
        //}

        //public IEnumerable<string> GetCitiesOfChain(long chainId)
        //{
        //    return _manager.GetStores().Where(s => s.ChainID == chainId).Select(s => s.City).Distinct().ToList();
        //}

        //public IEnumerable<Price> GetPricesOfChain(long chainId)
        //{
        //    return _manager.GetStores(s => s.ChainID == chainId)
        //        .Select(s => s.Prices).SelectMany(p => p).ToList();
        //}

        //public bool IsItemInStore(Item item, int storeId)
        //{
        //    return GetItemsOfStore(storeId).FirstOrDefault(i => i.ItemID == item.ItemID) != null;
        //}

        //public bool IsItemInAllChains(Item item)
        //{
        //    foreach (var chain in _manager.GetChains())
        //    {
        //        var itemsInChain = GetItemsOfChain(chain.ChainID);

        //        if (itemsInChain.All(i => i.ItemID != item.ItemID)) return false;
        //    }
        //    return true;
        //}

        //public Price GetLowestPriceOfItem(long itemId)
        //{
        //    return GetPricesOfItem(itemId).Min(i => i);
        //}

        //public Chain GetChainOfPrice(Price p)
        //{
        //    return GetChain(GetStore(p.StoreID).ChainID);
        //}

        #endregion

    }
}