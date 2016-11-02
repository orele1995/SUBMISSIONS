using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PriceComperationModel
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public long ItemID { get; set;}
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public string ManufacturerName { get; set; }
        [DataMember]
        public string Quantity { get; set; }

        [DataMember]
        public virtual ICollection<Price> Prices { get; set; }


        public override bool Equals(object obj)
        {
            Item other = obj as Item;
            if (other == null) return false;
            if (other.ItemID != ItemID) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return ItemID.GetHashCode();
        }
    }
}
