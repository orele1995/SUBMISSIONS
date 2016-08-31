using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Customer :IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }

        public Customer (string name, int id, string address)
        {
            Name = name;
            ID = id;
            Address = address;
        }
        public int CompareTo(Customer other)
        {
            return String.Compare(Name, other.Name, true);
        }

        public bool Equals(Customer other)
        {
            if (this.CompareTo(other)==0 && other.ID==ID)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return Name+" "+ID+" "+Address;
        }
    }
}
