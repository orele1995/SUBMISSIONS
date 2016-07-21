using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    class A
    {
        static private int x = 0; // for the example, to see the difference between the objects
        public int a { get; }
        public int b { get; set; }
        public int c { get;}
        public A ()
        {
            a = b = c = x++;
        }
    }

 }
