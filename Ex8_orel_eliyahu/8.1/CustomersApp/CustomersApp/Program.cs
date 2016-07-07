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
            Customer[] customers = new Customer[4];
            string[] names = { "K", "Z", "B", "L" };
            string[] addresses = { "bb", "cc", "bb", "aa" };
            
            customers[0] = new Customer(names[0], 1000, addresses[0]);
            customers[1] = new Customer(names[1], 40, addresses[1]);
            customers[2] = new Customer(names[2], 89, addresses[2]);
            customers[3] = new Customer(names[3], 777, addresses[3]);
            
            // ----------------------- ex 8 -----------------------

            CustomerFilter filter = StartWithAK;

            Console.WriteLine("Names from A - K:");
            ICollection<Customer> result = GetCustomers(customers, filter);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            filter = delegate (Customer customer)
            {
                if (customer.Name != null && customer.Name[0] >= 'L' && customer.Name[0] <= 'Z')
                {
                    return true;
                }
                return false;
            };

            Console.WriteLine("Names from L - Z:");
            result = GetCustomers(customers, filter);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            filter = customer => customer.ID < 100;

            Console.WriteLine("Id less than 100:");
            result = GetCustomers(customers, filter);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        static bool StartWithAK (Customer customer)
        {
            if (customer.Name != null && customer.Name[0] >= 'A' && customer.Name[0] <='K')
            {
                return true;
            }
            return false;
        }

        static ICollection<Customer> GetCustomers (ICollection<Customer> customerCollection, CustomerFilter filter)
        {
            List<Customer> result = new List<Customer>();
            foreach (Customer item in customerCollection)
            {
                if (filter(item)==true)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
