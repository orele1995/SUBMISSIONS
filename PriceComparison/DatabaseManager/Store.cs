using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
    public class Store
    {

        int store_id;
        int chain_id;
        string subchain_id;
        string address;
        string city;
        string zip_code;

        public int StoreID
        {
            get
            {
                return store_id;
            }

            set
            {
                store_id = value;
            }
        }
        public int Chain_id
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
        public string Subchain_id
        {
            get
            {
                return subchain_id;
            }

            set
            {
                subchain_id = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }
        public string Zip_code
        {
            get
            {
                return zip_code;
            }

            set
            {
                zip_code = value;
            }
        }
        public virtual ICollection<Item> Items
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            Store other = obj as Store;
            if (other == null) return false;
            if (other.StoreID != StoreID) return false;
            return true;
        }
    }
}
