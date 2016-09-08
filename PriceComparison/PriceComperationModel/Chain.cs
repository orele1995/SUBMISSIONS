using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComperationModel
{
    public class Chain
    {
        public long ChainID { get; set; }

        public string Chain_name { get; set; }
        public virtual ICollection<Store> Stores {get;set;}

        public override bool Equals(object obj)
        {
            Chain other = obj as Chain;
            if (other == null) return false;
            if (other.ChainID != ChainID) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return ChainID.GetHashCode();
        }
    }
}
