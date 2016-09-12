using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComperationController
{
   public class ChainDetails
    {
        public long ChainId { get; set; }

        public string ChainName { get; set; }

        public BindingList<DisplayItem> Items { get; set; }

        public double TotalSum 
        {
            get { return Items.Sum(i => i.ItemPrice*i.Quantity); }
        }

        public double PrecentOfCart { get; set; }


       
    }
}
