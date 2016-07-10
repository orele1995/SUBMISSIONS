using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class AssemblyAnalayzer
    {
        public static bool AnalayzeAssembly (Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException();
            }
            bool result = true;
            Type [] types = assembly.GetTypes();
           
            foreach (var item in types)
            {
                var attributes = item.GetCustomAttributes(typeof(CodeReviewAttribute));
                foreach (CodeReviewAttribute att in attributes)
                {
                    if (att.Approved == false)
                        result = false;
                    Console.WriteLine($"class : {item.Name} reviewer : {att.Reviewer} date: {att.ReviewDate} approved: {att.Approved}");
                }
            }
            return result;
        }
    }
}
