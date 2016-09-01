using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Chain
    {
        int chain_id;
        string chain_name;

        public int ChainID
        {
            get
            {
                return chain_id;
            }

            set
            {
                chain_id = value;
            }
        }

        public string Chain_name
        {
            get
            {
                return chain_name;
            }

            set
            {
                chain_name = value;
            }
        }
        public virtual ICollection<Store> Stores {get;set;}

        public override bool Equals(object obj)
        {
            Chain other = obj as Chain;
            if (other == null) return false;
            if (other.ChainID != ChainID) return false;
            return true;
        }
    }
}
