using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComperationController
{
    public class DisplayItem
    {
        public string ChainName { get; set; }
        public int StoreCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string ItemName { get; set; }
        public string ManufacturerName { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}