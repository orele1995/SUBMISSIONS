using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManager
{
   public class Item
    {
        int item_id;
        int item_type;
        string item_code;
        int chain_id;

        public int ItemID
        {
            get
            {
                return item_id;
            }

            set
            {
                item_id = value;
            }
        }

        public int Item_type
        {
            get
            {
                return item_type;
            }

            set
            {
                item_type = value;
            }
        }

        public string Item_code
        {
            get
            {
                return item_code;
            }

            set
            {
                item_code = value;
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
    }
}
