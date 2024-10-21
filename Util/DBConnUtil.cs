using Microsoft.Data.SqlClient;

namespace Util
{
    public class DBConnUtil
    {
        static string cnstring = "Data Source=.\\sqlexpress;Initial Catalog=CarConnect;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection GetConnectionString()
        {
            SqlConnection cn = new SqlConnection(cnstring);
            return cn;
        }
    }
}
