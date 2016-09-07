using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Price:IComparable<Price>
    {
        public long PriceID { get; set; }
        public long ItemID { get; set; }
        public int StoreID { get; set; }
        public string UnitQty { get; set; }
        public string Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double ItemPrice { get; set; }
        public double UnitOfMeasurePrice { get; set; }

        public int CompareTo(Price other)
        {
            return ItemPrice.CompareTo(other.ItemPrice) ;
        }

        public override bool Equals(object obj)
        {
            Price other = obj as Price;
            if (other == null) return false;
            if (other.ItemID != ItemID) return false;
            if (other.StoreID != StoreID) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return ItemID.GetHashCode()+ StoreID.GetHashCode();
        }
    }
}
