using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public delegate bool CustomerFilter(Customer customer);

    public class Customer :IComparable<Customer>, IEquatable<Customer>
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public string Address { get; private set; }

        public Customer (string name, int id, string address)
        {
            Name = name;
            ID = id;
            Address = address;
        }
        public int CompareTo(Customer other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }
            return String.Compare(Name, other.Name, true);
        }

        public bool Equals(Customer other)
        {
            if (other == null) { return false; }
            if (this.CompareTo(other)==0 && other.ID==ID) { return true; }
            return false;
        }
        public override string ToString()
        {
            return string.Format(" Name: {0} ID: {1} Address: {2}",Name,ID,Address);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            string toCompare = obj as string;
            if (toCompare == null) { return false; }
            return this.Equals(toCompare); 
        }
        public override int GetHashCode()
        {
            return Name.ToUpper().GetHashCode();
        }
    }
}
