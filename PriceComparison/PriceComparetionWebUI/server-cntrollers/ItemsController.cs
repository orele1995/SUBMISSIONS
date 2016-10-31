using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PriceComperationController;
using PriceComperationModel;


namespace PriceComparetionWebUI
{
    [RoutePrefix("api/priceComparetion")]
    public class ItemsController : ApiController
    {
        private readonly PriceControl _control = PriceControl.ThePriceControl;

        [Route("GetDisplayItems")]
        [HttpGet]
        public DisplayItem[] GetDisplayItems()
        {
            return new DisplayItem[] {};
        }

        [Route("GetItems")]
        [HttpGet]
        public object[] GetItems()
        {
            return new object[]
            {
                new {ItemName = "במבה", ManufacturerName = "אוסם", Quantity = "100", ItemID = 1, NumOfItems = 1},
                new {ItemName = "ביסלי", ManufacturerName = "אוסם", Quantity = "100", ItemID = 2, NumOfItems = 1},
                new {ItemName = "דוריטוס", ManufacturerName = "אוסם", Quantity = "100", ItemID = 3, NumOfItems = 1},
                new {ItemName = "חלב", ManufacturerName = "תנובה", Quantity = "1 ליטר", ItemID = 3, NumOfItems = 1},
                new {ItemName = "לחם", ManufacturerName = "נאמן", Quantity = "100", ItemID = 3, NumOfItems = 1},
                new {ItemName = "מים", ManufacturerName = "נביעות", Quantity = "1 ליטר", ItemID = 3, NumOfItems = 1}
            };
        }

        [Route("GetChains")]
        [HttpGet]
        public Chain[] GetChains()
        {
            return _control.GetChains().ToArray();
        }

        [Route("GetItemsOfChain")]
        [HttpGet]
        public Item[] GetItemsOfChain(string chainId)
        {
            return _control.GetItemsOfChain(long.Parse(chainId)).ToArray();
        }

        [Route("GetItemsOfStore")]
        [HttpGet]
        public Item[] GetItemsOfStore(int storeId)
        {
            return _control.GetItemsOfStore(storeId).ToArray();
        }

        [Route("getPricesResult")]
        [HttpPost]
        public object[] GetPricesResult(object data)
        {
            return new[]
            {
                new
                {
                    sum=104,
                    store =
                        new Store
                        {
                            ChainID = 1,
                            StoreID = 2,
                            Prices = null,
                            City = "בת ים",
                            Address = "הורד 10",
                            StoreCode = 2
                        },
                    cart = new DisplayItem[]
                    {
                        new DisplayItem
                        {
                            ItemName = "במבה",
                            ManufacturerName = "אוסם",
                            ItemPrice = 11,
                            ChainName = "חצי חינם",
                            City = "בת ים",
                            Address = "הורד 10",
                            Quantity = 3,
                            StoreCode = 2
                        },
                        new DisplayItem
                        {
                            ItemName = "ביסלי",
                            ManufacturerName = "אוסם",
                            ItemPrice = 11,
                            ChainName = "חצי חינם",
                            City = "בת ים",
                            Address = "הורד 10",
                            Quantity = 4,
                            StoreCode = 2
                        },
                        new DisplayItem
                        {
                            ItemName = "דוריטוס",
                            ManufacturerName = "אוסם",
                            ItemPrice = 9,
                            ChainName = "חצי חינם",
                            City = "בת ים",
                            Address = "הורד 10",
                            Quantity = 3,
                            StoreCode = 2
                        }
                    }
                   
                },
                new
                {
                    sum=111,
                    store =
                        new Store
                        {
                            ChainID = 2,
                            StoreID = 3,
                            Prices = null,
                            City = "ירושלים",
                            Address = "גורג 9",
                            StoreCode = 3
                        },
                    cart = new DisplayItem[]
                    {
                        new DisplayItem
                        {
                            ItemName = "במבה",
                            ManufacturerName = "אוסם",
                            ItemPrice = 7,
                            ChainName = "אושר עד",
                            City = "ירושלים",
                            Address = "גורג 9",
                            Quantity = 3,
                            StoreCode = 3
                        },
                        new DisplayItem
                        {
                            ItemName = "ביסלי",
                            ManufacturerName = "אוסם",
                            ItemPrice = 15,
                            ChainName = "אושר עד",
                            City = "ירושלים",
                            Address = "גורג 9",
                            Quantity = 4,
                            StoreCode = 3
                        },
                        new DisplayItem
                        {
                            ItemName = "דוריטוס",
                            ManufacturerName = "אוסם",
                            ItemPrice = 10,
                            ChainName = "אושר עד",
                            City = "ירושלים",
                            Address = "גורג 9",
                            Quantity = 3,
                            StoreCode = 3
                        }
                    }

                },
                new
                {
                    sum=100,
                    store =
                        new Store
                        {
                            ChainID = 1,
                            StoreID = 1,
                            Prices = null,
                            City = "חולון",
                            Address = "מפרץ שלמה",
                            StoreCode = 1
                        },
                    cart = new DisplayItem[]
                    {
                        new DisplayItem
                        {
                            ItemName = "במבה",
                            ManufacturerName = "אוסם",
                            ItemPrice = 10,
                            ChainName = "חצי חינם",
                            City = "חולון",
                            Address = "מפרץ שלמה",
                            Quantity = 3,
                            StoreCode = 1
                        },
                        new DisplayItem
                        {
                            ItemName = "ביסלי",
                            ManufacturerName = "אוסם",
                            ItemPrice = 10,
                            ChainName = "חצי חינם",
                            City = "חולון",
                            Address = "מפרץ שלמה",
                            Quantity = 4,
                            StoreCode = 1
                        },
                        new DisplayItem
                        {
                            ItemName = "דוריטוס",
                            ManufacturerName = "אוסם",
                            ItemPrice = 10,
                            ChainName = "חצי חינם",
                            City = "חולון",
                            Address = "מפרץ שלמה",
                            Quantity = 3,
                            StoreCode = 1
                        }
                    }

                }
            };
        }

    }
}
