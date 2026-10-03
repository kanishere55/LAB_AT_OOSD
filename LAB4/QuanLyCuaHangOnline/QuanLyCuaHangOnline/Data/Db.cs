using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyCuaHangOnline
{
    public static class Db
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["QuanLyCuaHangOnlineDB"].ConnectionString; }
        }
        public static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
