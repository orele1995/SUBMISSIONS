using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComperationController
{
    public enum DatabaseType
    {
        DbManager
    };

    public class DatabaseTypeConverter
    {
        public DatabaseType ToDatabaseType(string type)
        {
            switch (type)
            {
                case "DbManager":
                    return DatabaseType.DbManager;
                default:
                 throw new ArgumentException("cant convert this string to DatabaseType");

            }
        }
    }
}
