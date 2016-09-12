using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComperationModel
{
    public class Store
    {       
        public int StoreID { get; set; }
        public int StoreCode { get; set; } 
        public long ChainID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public virtual ICollection<Price> Prices { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Store;
            return other?.StoreID == StoreID;
        }
        public override int GetHashCode()
        {
            return StoreID.GetHashCode();
        }

        public override string ToString()
        {
            
            return $"{StoreCode}: {Address}, {City}";
        }
    }
}
