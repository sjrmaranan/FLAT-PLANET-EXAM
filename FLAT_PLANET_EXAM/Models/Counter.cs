using System.Configuration;
using System.Data.SqlClient;

namespace FLAT_PLANET_EXAM.Models
{
    public class Counter
    {
        public int RetrieveCounter()
        {
            int counter;
            string connectionString = ConfigurationManager.ConnectionStrings["CounterCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT myc FROM tblc";

                using (SqlCommand comm = new SqlCommand(sql, con))
                {
                    comm.Connection.Open();
                    counter = (int)comm.ExecuteScalar();
                }
                con.Close();
            }
            return counter;
        }
        public void UpdateCounter()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CounterCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "UPDATE tblc SET myc=myc+1";
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand comm = new SqlCommand(sql, con))
                {
                    comm.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}