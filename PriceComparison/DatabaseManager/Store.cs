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
        public int Chain_id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip_code { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public override bool Equals(object obj)
        {
            Store other = obj as Store;
            if (other == null) return false;
            if (other.StoreID != StoreID) return false;
            return true;
        }
    }
}
