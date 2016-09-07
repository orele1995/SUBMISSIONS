using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Store
    {       
        public int StoreID { get; set; }
        public int Store_code { get; set; } 
        public long ChainID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public virtual ICollection<Price> Prices { get; set; }

        public override bool Equals(object obj)
        {
            Store other = obj as Store;
            if (other == null) return false;
            if (other.StoreID != StoreID) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return StoreID.GetHashCode();
        }

        public override string ToString()
        {
            
            return $"{Store_code}: {Address}, {City}";
        }
    }
}
