using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManager;
using EnvDTE;
using System.Configuration;
using System.Collections.Specialized;
using PriceComperationDatabaseManagerFactory;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace DatabaseManagerFactory
{
   public class PriceComperationDataManagerFactory
    {

        private static PriceComperationDataManagerFactory _theFactory;

        private PriceComperationDataManagerFactory() { }

        public static PriceComperationDataManagerFactory TheFactory
        {
            get
            {
                if (_theFactory == null)
                {
                    _theFactory = new PriceComperationDataManagerFactory();
                }
                return _theFactory;
            }
        }

        public IPriceComperationDataManager GetPriceComperationDataManager()
        {
            var converter = new DatabaseTypeConverter();

            DatabaseType type = converter.ToDatabaseType(ConfigurationManager.AppSettings["DatabaseType"]);
            switch (type)
            {
                case DatabaseType.DbManager:
                    return DbManager.TheDbManager;
                default:
                    return null;
            }
        }
    }
}
