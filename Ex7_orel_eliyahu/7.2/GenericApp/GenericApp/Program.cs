using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<int, string> multyDictionary = new MultiDictionary<int, string>();

            //add values
            multyDictionary.Add(1, "one");
            multyDictionary.Add(1, "ich");
            multyDictionary.Add(2, "two");
            multyDictionary.Add(2, "nee");
            multyDictionary.Add(3, "three");
            multyDictionary.Add(3, "sun");

            // ienumrable
            foreach (var item in multyDictionary)
            {
                Console.WriteLine(item.Value);
            }

            IEnumerable d = multyDictionary;
            foreach (var item in d)
            {
                Console.WriteLine(item.ToString());
            }

            // contains
            string ans;
            if (multyDictionary.ContainsKey(3))
            {
                ans = "contains 3";
            }
            else
            {
                ans = "not contains 3";
            }
            if (multyDictionary.ContainsKey(4))
            {
                ans += " and contains 4";
            }
            else
            {
                ans += " and not contains 4";
            }
            if (multyDictionary.Contains(3, "three"))
            {
                ans += " and contains 3,three";
            }
            else
            {
                ans += " and not contains 3,three";
            }
            if (multyDictionary.Contains(3, "aa"))
            {
                ans += " and contains 3,aa";
            }
            else
            {
                ans += " and not contains 3,aa";
            }

            Console.WriteLine(ans);

            // count and remove
            Console.WriteLine("there are " + multyDictionary.Count +" items in the collection");
            multyDictionary.Remove(1, "one");
            Console.WriteLine("there are " + multyDictionary.Count + " items in the collection");

            multyDictionary.Remove(2);
            Console.WriteLine("there are " + multyDictionary.Count + " items in the collection");
           
            //clear
            multyDictionary.Clear();
            Console.WriteLine("there are " + multyDictionary.Count + " items in the collection");

        }


    }
}

