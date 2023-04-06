using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zara.Repository.Models.DB;

namespace Zara.Repository.DBOperations
{
    public class ContractOperations
    {
        public static List<ContractModel> GetContracts(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from Ugovor";
                    SqlDataReader reader = selectCommand.ExecuteReader(); //ova naredba ce da popuni reader obj sa svim onim sto je rezultat naredbe selectCommand

                    List<ContractModel> result = new List<ContractModel>();

                    while (reader.Read())
                    {
                        ContractModel contract = new ContractModel();
                        contract.Sifra = reader.GetInt32(0);
                        contract.ZaposleniID = reader.GetInt32(1);
                        contract.RadnoMjesto = reader.GetString(2);
                        contract.Plata = reader.GetDecimal(3);
                        contract.DatumZaposlenja = reader.GetDateTime(4);
                        contract.BrRadnihSatiUNedelji = reader.GetInt32(5);


                        result.Add(contract);

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


        public static List<ContractModel> GetContractsByRadnoMjesto(string radnomjesto, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from Ugovor WHERE RadnoMjesto=@radnoMjesto";
                    selectCommand.Parameters.AddWithValue("radnoMjesto", radnomjesto);
                    SqlDataReader reader = selectCommand.ExecuteReader(); 

                    List<ContractModel> result = new List<ContractModel>();

                    while (reader.Read())
                    {
                        ContractModel contract = new ContractModel();
                        contract.Sifra = reader.GetInt32(0);
                        contract.ZaposleniID = reader.GetInt32(1);
                        contract.RadnoMjesto = reader.GetString(2);
                        contract.Plata = reader.GetDecimal(3);
                        contract.DatumZaposlenja = reader.GetDateTime(4);
                        contract.BrRadnihSatiUNedelji = reader.GetInt32(5);


                        result.Add(contract);

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

        public static ContractModel GetContractByID(int ContractID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Ugovor WHERE Sifra = @Sifra";
                    selectCommand.Parameters.AddWithValue("Sifra", ContractID);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read(); //eventualno provjera if reader.Read

                    ContractModel contract = new ContractModel();
                    contract.Sifra = reader.GetInt32(0);
                    contract.ZaposleniID = reader.GetInt32(1);
                    contract.RadnoMjesto = reader.GetString(2);
                    contract.Plata = reader.GetDecimal(3);
                    contract.DatumZaposlenja = reader.GetDateTime(4);
                    contract.BrRadnihSatiUNedelji = reader.GetInt32(5);

                    connection.Close();
                    return contract;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static ContractModel GetContractByEmployeeID(int ContractID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Ugovor WHERE ZaposleniID = @zaposleniID";
                    selectCommand.Parameters.AddWithValue("zaposleniID", ContractID);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read(); //eventualno provjera if reader.Read

                    ContractModel contract = new ContractModel();
                    contract.Sifra = reader.GetInt32(0);
                    contract.ZaposleniID = reader.GetInt32(1);
                    contract.RadnoMjesto = reader.GetString(2);
                    contract.Plata = reader.GetDecimal(3);
                    contract.DatumZaposlenja = reader.GetDateTime(4);
                    contract.BrRadnihSatiUNedelji = reader.GetInt32(5);

                    connection.Close();
                    return contract;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool InsertContract(ContractModel contract, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Ugovor (Sifra, ZaposleniID, RadnoMjesto, Plata, DatumZaposlenja, BrRadnihSatiUNedelji)" +
                                                "VALUES (@Sifra, @ZaposleniID, @RadnoMjesto, @Plata, @DatumZaposlenja, @BrSati)";
                    insertCommand.Parameters.AddWithValue("Sifra", contract.Sifra);
                    insertCommand.Parameters.AddWithValue("ZaposleniID", contract.ZaposleniID);
                    insertCommand.Parameters.AddWithValue("RadnoMjesto", contract.RadnoMjesto);
                    insertCommand.Parameters.AddWithValue("Plata", contract.Plata);
                    insertCommand.Parameters.AddWithValue("DatumZaposlenja", contract.DatumZaposlenja);
                    insertCommand.Parameters.AddWithValue("BrSati", contract.BrRadnihSatiUNedelji);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();
                    return rowsAffected == 1;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool UpdateContract(ContractModel contract, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Ugovor " +
                                                "SET Sifra = @Sif, " +
                                                "RadnoMjesto = @RadnoMj, " +
                                                "Plata = @Pl, " +
                                                "DatumZaposlenja = @Dat, " +
                                                "BrRadnihSatiUNedelji = @BrSati " +
                                                "WHERE ZaposleniID = @ZapID";

                    updateCommand.Parameters.AddWithValue("ZapID", contract.ZaposleniID);
                    updateCommand.Parameters.AddWithValue("RadnoMj", contract.RadnoMjesto);
                    updateCommand.Parameters.AddWithValue("Pl", contract.Plata);
                    updateCommand.Parameters.AddWithValue("Dat", contract.DatumZaposlenja);
                    updateCommand.Parameters.AddWithValue("BrSati", contract.BrRadnihSatiUNedelji);
                    updateCommand.Parameters.AddWithValue("Sif", contract.Sifra);
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    connection.Close();

                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool DeleteContract(int ContractID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Ugovor WHERE " +
                                                "Sifra = @ContractID";
                    deleteCommand.Parameters.AddWithValue("ContractID", ContractID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    connection.Close();
                    return rowsAffected == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
