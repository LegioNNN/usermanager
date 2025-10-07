// DAL/DbHelper.cs
using System.Configuration;
using System.Data.SqlClient;

namespace MyProject.DAL
{
    public class DbHelper
    {
        private static string connStr = "Server=.;Database=UserManagementDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }
    }
}
