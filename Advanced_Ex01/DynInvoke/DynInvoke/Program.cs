using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            var b = new B();
            var c = new C();
            try
            {
                Console.WriteLine(InvokeHello(a, "orel"));
                Console.WriteLine(InvokeHello(b, "orel"));
                Console.WriteLine(InvokeHello(c, "orel"));
            }
            catch( ArgumentNullException ex)
            {
                Console.WriteLine("you cant send null to the method");
            }
            catch (MissingMethodException ex)
            {
                Console.WriteLine("couln't find hello method");
            }

        }

        public static string InvokeHello(object ob, string s)
        {
            if (ob == null | s == null)
                throw new ArgumentNullException();
            string result = (string)ob.GetType().InvokeMember("Hello", BindingFlags.InvokeMethod, null, ob, new[] { s });
            return result;
        }
    }
}
