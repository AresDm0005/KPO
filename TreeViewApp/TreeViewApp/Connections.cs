using System.Configuration;
using System.Data.SqlClient;

namespace TreeViewApp
{
    public class Connections
    {
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["TreeViewApp.Properties.Settings.SDTreeViewConnectionString"].ConnectionString);

            return connection;
        }
    }
}
