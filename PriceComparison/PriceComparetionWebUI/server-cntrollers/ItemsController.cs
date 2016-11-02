using System;
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
        public MultipleItem[] GetItemsOfStore(int storeId)
        {
            var result =  _control.GetMultipleItemsOfStore(storeId).ToArray();
            return result;
        }
 
        [Route("getPricesResult")]
        [HttpPost]
        public object[] GetPricesResult(GetPriceResultParams param)
        {
            return _control.CulcCartPrices(param.Cart, param.Stores).ToArray();
        }

    }
}
