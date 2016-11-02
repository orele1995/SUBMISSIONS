using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PriceComperationModel
{
    [DataContract]
    public class Price:IComparable<Price>
    {
        [DataMember]
        public long PriceID { get; set; }
        [DataMember]
        public long ItemID { get; set; }
        [DataMember]
        public int StoreID { get; set; }
        [DataMember]
        public double ItemPrice { get; set; }

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
