using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers= new Customer[4];
            string[] names = { "b", "c", "B", "a" };
            string[] addresses = { "bb", "cc", "bb", "aa" };
            for (int i = 0; i < 4; i++)
            {
                customers[i] = new Customer(names[i], i, addresses[i]);
            }
            
            Console.WriteLine(customers[0]);
            Console.WriteLine(customers[2]);
            Console.WriteLine(customers[0].CompareTo(customers[2]));

            foreach (Customer item in customers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("by name:");
            Array.Sort(customers);

            foreach (Customer item in customers)
            {
                Console.WriteLine(item);
            }

            AnotherCustomerComparer comp = new AnotherCustomerComparer();
            Array.Sort(customers,comp);

            Console.WriteLine("other compare: by id");
            foreach (Customer item in customers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
