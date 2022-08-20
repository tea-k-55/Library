using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace library
{
    class Connection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"server=TEODORA-PC\TEODORA; database=Library; integrated security=true;");
        }

        public static SqlCommand GetCommand()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GetConnection();
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
    }
}
