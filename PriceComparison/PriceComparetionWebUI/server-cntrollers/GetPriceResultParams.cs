using System.Collections.Generic;
using PriceComperationController;
using PriceComperationModel;

namespace PriceComparetionWebUI
{
    public class GetPriceResultParams
    {
        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<MultipleItem> Cart { get; set; }
    }
}