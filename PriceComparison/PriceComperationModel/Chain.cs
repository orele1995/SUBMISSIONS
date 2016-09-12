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

        public string ChainName { get; set; }
        public virtual ICollection<Store> Stores {get;set;}

        public override bool Equals(object obj)
        {
            Chain other = obj as Chain;
            return other?.ChainID == ChainID;
        }
        public override int GetHashCode()
        {
            return ChainID.GetHashCode();
        }
    }
}
