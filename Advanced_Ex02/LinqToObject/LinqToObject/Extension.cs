using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObject
{
    public static class Extension
    {
      
        public static void CopyTo(this object sorce, object destination)
        {
            var properties = from sorceProperty in sorce.GetType().GetProperties()
                             from detinationProperty in destination.GetType().GetProperties()
                             where sorceProperty.Name == detinationProperty.Name 
                                    && sorceProperty.CanRead 
                                    && detinationProperty.CanWrite 
                                    && sorceProperty.PropertyType == detinationProperty.PropertyType
                             select new
                             {
                                 SorceP = sorceProperty,
                                 DetinationP = detinationProperty
                             };
            foreach (var p in properties)
            {
                p.DetinationP.SetValue(destination, p.SorceP.GetValue(sorce));
            }
        }
    }
}
