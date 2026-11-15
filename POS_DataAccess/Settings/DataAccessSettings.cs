using System.Configuration;

namespace POS_DataAccess
{
    static class DataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["SuperMarketDBConnectionString"].ConnectionString;

    }

}
