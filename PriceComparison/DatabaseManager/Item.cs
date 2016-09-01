using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Item
    {
        public int ItemID { get; set;}
        public string ItemName { get; set; }
        public string ManufacturerName { get; set; }
        public virtual ICollection<Price> Prices { get; set; }


        public override bool Equals(object obj)
        {
            Item other = obj as Item;
            if (other == null) return false;
            if (other.ItemID != ItemID) return false;
            return true;
        }
    }
}
