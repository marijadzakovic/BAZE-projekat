using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zara.Repository.Models.DB;

namespace Zara.Repository.DBOperations
{
    public class SectorOperations
    {
        public static List<SectorModel> GetSectors(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from sektor";
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<SectorModel> result = new List<SectorModel>();

                    while (reader.Read())
                    {
                        SectorModel sector = new SectorModel();
                        sector.Naziv = reader.GetString(0);


                        result.Add(sector);

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