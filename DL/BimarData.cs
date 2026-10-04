using BL.Contracts;
using System.Data.SqlClient;

namespace DL
{
    public class BimarData : IBimarData
    {
        public bool Insert(string firstName, string lastName, string nationalCode)
        {
            var cmd = new SqlCommand();
            var sqlConnection = new SqlConnection("myConnectionString");
            cmd.Connection = sqlConnection;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@NationalCode", nationalCode);

            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public int SelectBimarId(string nationalCode)
        {
            var cmd = new SqlCommand("select Id from Bimar where NationalCode=@nationalCode;");
            var sqlConnection = new SqlConnection("myConnectionString");
            cmd.Connection = sqlConnection;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@NationalCode", nationalCode);

            try
            {
                sqlConnection.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
