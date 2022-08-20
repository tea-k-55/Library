using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace library
{
    class Statistics
    {
        public static DataTable Chart(int year, int id)
        {
            SqlCommand cmd = Connection.GetCommand();
            cmd.CommandText = "uspAnalytics";

            cmd.Parameters.AddWithValue("@authorID", id);
            cmd.Parameters.AddWithValue("@period", year);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                cmd.Connection.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
