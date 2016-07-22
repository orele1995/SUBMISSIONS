﻿using System;
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
            var types =typeof(String).Assembly.GetTypes();
            var tXml = new XElement("MscorlibClasses", from t in types 
                                                       where t.IsClass && t.IsPublic
                                                       select new XElement("Type", new XAttribute("Name", t.FullName)
                                                                                 , new XElement("Properties", from p in t.GetProperties()
                                                                                                              select new XElement("Property", new XAttribute("Name", p.Name)
                                                                                                                                           , new XAttribute("Type", p.PropertyType)
                                                                                                                                )
                                                                                                 )
                                                                                  , new XElement("Methods", from m in t.GetMethods(BindingFlags.Public| BindingFlags.Instance | BindingFlags.DeclaredOnly)
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

            tXml.Save("Types.xml");

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


            var typeInfoXML =new XElement("Types", from t in tXml.Descendants("Type")
                                                   let count = t.Descendants("Method").Count()
                                                   orderby count
                                                   select new XElement("Type", new XAttribute("TypeName", (string)t.Attribute("Name")),
                                                          new XAttribute("Methods", count),
                                                          new XAttribute("Properties", t.Descendants("Property").Count());
            typeInfoXML.Save("Types2.xml");


            var typeInfo = from t in tXml.Descendants("Type")
                              let count = t.Descendants("Method").Count()
                              orderby count
                              select new
                              {
                                  TypeName = t.Attribute("Name"),
                                  Methods = count,
                                  Properties = t.Descendants("Property").Count()
                              };
            var grouping = from t in typeInfo
                           orderby t.TypeName ascending
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
