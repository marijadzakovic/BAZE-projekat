using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zara.Repository.Models.DB;

namespace Zara.Repository.DBOperations
{
    public class SizeOperations
    {
        public static List<SizeModel> GetSizes(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from velicina";
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<SizeModel> result = new List<SizeModel>();

                    while (reader.Read())
                    {
                        SizeModel size = new SizeModel();
                        size.OznakaVelicine = reader.GetString(0);
                        result.Add(size);
                    }
                    connection.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
                }
            

            }
        }
}
