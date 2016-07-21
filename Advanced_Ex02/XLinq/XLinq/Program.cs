using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var types = Assembly.LoadFile(@"C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll").GetTypes();
            var tXml = new XElement("MscorlibClasses", from t in types 
                                                       where t.IsClass && t.IsPublic
                                                       select new XElement("Type", new XAttribute("Name", t.FullName)
                                                                                 , new XElement("Properties", from p in t.GetProperties()
                                                                                                              select new XElement("Property", new XAttribute("Name", p.Name)
                                                                                                                                           , new XAttribute("Type", p.PropertyType)
                                                                                                                                )
                                                                                                 )
                                                                                  , new XElement("Methods", from m in t.GetMethods()
                                                                                                            where m.IsPublic && !m.IsStatic
                                                                                                            select new XElement("Method", new XAttribute("Name", m.Name)
                                                                                                                                         , new XAttribute("ReturnType", m.ReturnType)
                                                                                                                                         , new XElement("Parameters", from param in m.GetParameters()
                                                                                                                                                                      select new XElement("Parameter", new XAttribute("Name", param.Name)
                                                                                                                                                                                                     , new XAttribute("Type", param.ParameterType)
                                                                                                                                                                                         )
                                                                                                                                                         )
                                                                                                                                )
                                                                                                  )
                                                                          )
                                   );

            XmlTextWriter writer = new XmlTextWriter("Types.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            tXml.WriteTo(writer);

            var noProperty = from t in tXml.Descendants("Type")
                             where t.Element("Properties").IsEmpty
                             orderby (string)t.Attribute("Name")
                             select (string)t.Attribute("Name");
            foreach (var item in noProperty)
            {
                Console.WriteLine($"The type {item} has no properties");
            }
            Console.WriteLine($"There are {noProperty.Count()} type without properties");

            var allMethods = from t in tXml.Descendants("Method")
                             select (string)t.Attribute("Name");
            Console.WriteLine($"There are {allMethods.Count()} methods");

            var allProperties = from p in tXml.Descendants("Property")
                                select (string)p.Attribute("Name");
            Console.WriteLine($"There are {allProperties.Count()} properties");

            var allParameters = from p in tXml.Descendants("Parameter")
                                group p by (string)p.Attribute("Type") into g
                                select new
                                {
                                    TypeName = g.Key,
                                    Count = g.Count()
                                };
            var max = allParameters.Max(g => g.Count);
            Console.WriteLine($"The most popular parameter type has {max} parameters, and it is: ");
            foreach (var item in allParameters)
            {
                if (item.Count == max)
                {
                    Console.WriteLine(item.TypeName);
                }
            }

            var MethodsInfo = from m in tXml.Descendants("Method")
                              group m by m.Parent.Parent.Attribute("Name") into g
                              select new
                              {
                                  TypeName = g.Key,
                                  Count = g.Count()
                              };
            var PropertyInfo = from p in tXml.Descendants("Property")
                               group p by p.Parent.Parent.Attribute("Name") into g
                               select new
                               {
                                   TypeName = g.Key,
                                   Count = g.Count()
                               };
            var typeInfoXml = new XElement("Types", from metodsGroup in MethodsInfo
                                                    from propertyGroup in PropertyInfo
                                                    where metodsGroup.TypeName == propertyGroup.TypeName
                                                    orderby metodsGroup.Count descending
                                                    select new XElement("Type", new XAttribute("Name", (string)metodsGroup.TypeName),
                                                                                new XAttribute("Methods", metodsGroup.Count),
                                                                                new XAttribute("Properties", propertyGroup.Count)));
            typeInfoXml.WriteTo(writer);

            var typeInfo = from metodsGroup in MethodsInfo
                           from propertyGroup in PropertyInfo
                           where metodsGroup.TypeName == propertyGroup.TypeName
                           select new
                           {
                               Name = (string)metodsGroup.TypeName,
                               Methods = metodsGroup.Count,
                               Properties = propertyGroup.Count
                           };

            var grouping = from t in typeInfo
                           orderby t.Name ascending
                           group t by t.Methods into g
                           orderby g.Key descending
                           select new
                           {
                               MethodsCount = g.Key,
                               Group = g
                           };
                           

                           
        }
    }
}
