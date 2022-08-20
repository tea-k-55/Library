using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace library
{
    class Author
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }

        public static DataTable Load()
        {
            SqlCommand cmd = Connection.GetCommand();
            cmd.CommandText = "uspAuthor";

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

        public static DataTable LoadFields(string id)
        {
            SqlCommand cmd = Connection.GetCommand();
            cmd.CommandText = "uspAuthorFields";

            cmd.Parameters.AddWithValue("@authorID", id);

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

        public static DataTable LoadComboBox()
        {
            SqlCommand cmd = Connection.GetCommand();
            cmd.CommandText = "uspAuthorComboBox";

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

        public static bool Delete(string id)
        {
            SqlCommand cmd = Connection.GetCommand();
            cmd.CommandText = "uspDeleteAuthor";

            cmd.Parameters.AddWithValue("@authorID", id);

            try
            {
                cmd.Connection.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static bool Add(string id, string fname, string lname, DateTime dob)
        {
            SqlCommand cmd = Connection.GetCommand();
            cmd.CommandText = "uspAddAuthor";

            cmd.Parameters.AddWithValue("@authorID", id);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            if (dob != DateTime.MaxValue || dob != DateTime.MinValue)
            {
                cmd.Parameters.AddWithValue("@dob", dob);
            }

            try
            {
                cmd.Connection.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
