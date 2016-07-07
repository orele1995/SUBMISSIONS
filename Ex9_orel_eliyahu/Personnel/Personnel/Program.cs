using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            var fm = new FileManager();
            var path = @"C:\Users\test\Desktop\code value\שיעורי בית\SUBMISSIONS\Ex9_orel_eliyahu\Personnel\people.txt";
            var list = fm.ReadFile(path);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
