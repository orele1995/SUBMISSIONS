using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManager;
using EnvDTE;
using System.Configuration;
using System.Collections.Specialized;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace PriceComperationController
{
    class PriceControllerFactory
    {

        private static PriceControllerFactory _theFactory;

        private PriceControllerFactory() { }

        public static PriceControllerFactory TheFactory
        {
            get
            {
                if (_theFactory == null)
                {
                    _theFactory = new PriceControllerFactory();
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
