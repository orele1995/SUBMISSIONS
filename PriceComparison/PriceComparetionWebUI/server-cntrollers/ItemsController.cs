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
            return new DisplayItem[]{};
        }

        [Route("GetItems")]
        [HttpGet]
        public Item[] GetItems()
        {
            return new Item[]
            {
                new Item {ItemName = "במבה", ManufacturerName = "אוסם", Quantity = "100", ItemID = 1},
                new Item {ItemName = "ביסלי", ManufacturerName = "אוסם", Quantity = "100", ItemID = 2},
                new Item {ItemName = "דוריטוס", ManufacturerName = "אוסם", Quantity = "100", ItemID = 3},
                new Item {ItemName = "חלב", ManufacturerName = "תנובה", Quantity = "1 ליטר", ItemID = 3},
                new Item {ItemName = "לחם", ManufacturerName = "נאמן", Quantity = "100", ItemID = 3},
                new Item {ItemName = "מים", ManufacturerName = "נביעות", Quantity = "1 ליטר", ItemID = 3}
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
        //[Route("getPricesResult")]
        //[HttpGet]
        //public DisplayItem[] GetPricesResult( Item[] items )
        //{
        //   // return _control.pToArray();
        //}

    }
}
