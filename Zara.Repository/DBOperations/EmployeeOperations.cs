using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zara.Repository.Models.DB;

namespace Zara.Repository.DBOperations
{
    public class EmployeeOperations
    {
        public static List<EmployeeModel> GetEmployees(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from zaposleni";
                    SqlDataReader reader = selectCommand.ExecuteReader(); //ova naredba ce da popuni reader obj sa svim onim sto je rezultat naredbe selectCommand

                    List<EmployeeModel> result = new List<EmployeeModel>();

                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.ZaposleniID = reader.GetInt32(0);
                        employee.Ime = reader.GetString(1);
                        employee.Telefon = reader.GetString(2);
                        employee.NazivSektora = reader.GetString(3);

                        result.Add(employee);

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

        public static EmployeeModel GetEmployeeByID(int EmployeeID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM zaposleni WHERE ZaposleniID = @ZaposleniID";
                    selectCommand.Parameters.AddWithValue("ZaposleniID", EmployeeID);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read(); //eventualno provjera if reader.Read

                    EmployeeModel employee = new EmployeeModel();
                    employee.ZaposleniID = reader.GetInt32(0);
                    employee.Ime = reader.GetString(1);
                    employee.Telefon = reader.GetString(2);
                    employee.NazivSektora = reader.GetString(3);

                    connection.Close();
                    return employee;
                } catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public static bool InsertEmployee(EmployeeModel employee, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Zaposleni (Ime, Telefon, NazivSektora)" + 
                                                "VALUES (@Name, @PhoneNumber, @SectorName)";
                    insertCommand.Parameters.AddWithValue("Name", employee.Ime);
                    insertCommand.Parameters.AddWithValue("PhoneNumber", employee.Telefon);
                    insertCommand.Parameters.AddWithValue("SectorName", employee.NazivSektora);
                 
                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    connection.Close();
                    return rowsAffected == 1;

                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool UpdateEmployee(EmployeeModel employee, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Zaposleni " +
                                                "SET Ime = @Name, " +
                                                "Telefon = @PhoneNumber, " +
                                                "NazivSektora = @SectorName " +
                                                "WHERE ZaposleniID = @EmployeeID";

                    updateCommand.Parameters.AddWithValue("EmployeeID", employee.ZaposleniID);
                    updateCommand.Parameters.AddWithValue("Name", employee.Ime);
                    updateCommand.Parameters.AddWithValue("PhoneNumber", employee.Telefon);
                    updateCommand.Parameters.AddWithValue("SectorName", employee.NazivSektora);
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

        public static bool DeleteEmployee(int employeeID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Zaposleni WHERE " +
                                                "ZaposleniID = @EmployeeID";
                    deleteCommand.Parameters.AddWithValue("EmployeeID", employeeID);

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
        public static EmployeeFullDetailsModel GetEmployeesFullDetails(int employeeID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select * from (select * from zaposleni z where z.ZaposleniID = @employeeID) as t1, ugovor u " +
                                                "where u.ZaposleniID = t1.ZaposleniID";
                    selectCommand.Parameters.AddWithValue("employeeID", employeeID);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read(); //eventualno provjera if reader.Read

                    EmployeeFullDetailsModel employee = new EmployeeFullDetailsModel();
                    employee.ZaposleniID = reader.GetInt32(0);
                    employee.Ime = reader.GetString(1);
                    employee.Telefon = reader.GetString(2);
                    employee.NazivSektora = reader.GetString(3);
                    employee.Sifra = reader.GetInt32(4);
                    employee.RadnoMjesto = reader.GetString(6);
                    employee.Plata = reader.GetDecimal(7);
                    employee.DatumZaposlenja = reader.GetDateTime(8);
                    employee.BrRadnihSatiUNedelji = reader.GetInt32(9);

                    connection.Close();
                    return employee;
                }
                catch (Exception ex)
                {
                    return null; 
                }
            }
        }
        public static List<EmployeeModel> EmployeesWithoutContract(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select t2.ZaposleniID, Ime, Telefon, NazivSektora from zaposleni as t2, " +
                        "(select ZaposleniID from Zaposleni except (select zaposleniID from Ugovor)) as t1 " + 
                                    "where t1.ZaposleniID = t2.ZaposleniID";
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<EmployeeModel> result = new List<EmployeeModel>();

                    while (reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.ZaposleniID = reader.GetInt32(0);
                        employee.Ime = reader.GetString(1);
                        employee.Telefon = reader.GetString(2);
                        employee.NazivSektora = reader.GetString(3);

                        result.Add(employee);

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
