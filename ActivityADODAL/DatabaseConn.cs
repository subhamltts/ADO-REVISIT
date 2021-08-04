using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityADODAL
{
    public class DatabaseConn
    {
        public static SqlConnection sqlConn = null;
        public static SqlConnection ConnectToDB()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ProjectXConStr"].ConnectionString;
            try
            {
                return new SqlConnection(connStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
