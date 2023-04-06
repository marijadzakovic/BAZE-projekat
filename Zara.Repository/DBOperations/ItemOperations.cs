using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zara.Repository.Models.DB;

namespace Zara.Repository.DBOperations
{
    public class ItemOperations
    {
        public static List<ItemModel> GetItems(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from Artikal";
                    SqlDataReader reader = selectCommand.ExecuteReader(); //ova naredba ce da popuni reader obj sa svim onim sto je rezultat naredbe selectCommand

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

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

        public static List<ItemModel> GetManItems(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from Artikal where NazivSektora='Muski'";
                    SqlDataReader reader = selectCommand.ExecuteReader(); //ova naredba ce da popuni reader obj sa svim onim sto je rezultat naredbe selectCommand

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

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
        public static List<ItemModel> GetWomanItems(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from Artikal where NazivSektora='Zenski'";
                    SqlDataReader reader = selectCommand.ExecuteReader(); //ova naredba ce da popuni reader obj sa svim onim sto je rezultat naredbe selectCommand

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

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
        
        public static List<ItemModel> GetKidsItems(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from Artikal where NazivSektora='Djeciji'";
                    SqlDataReader reader = selectCommand.ExecuteReader(); //ova naredba ce da popuni reader obj sa svim onim sto je rezultat naredbe selectCommand

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

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

        public static ItemModel GetItemByID(int ItemID, string connectionString)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT * FROM Artikal WHERE Id = @itemID";
                    selectCommand.Parameters.AddWithValue("itemID", ItemID);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    reader.Read(); //eventualno provjera if reader.Read

                    ItemModel item = new ItemModel();
                    item.Id = reader.GetInt32(0);
                    item.Sifra = reader.GetInt32(1);
                    item.Naziv = reader.GetString(2);
                    item.OznakaVelicine = reader.GetString(3);
                    item.NazivSektora = reader.GetString(4);
                    item.Cijena = reader.GetDecimal(5);
                    item.Opis = reader.GetString(6);
                    item.Boja = reader.GetString(7);

                    connection.Close();
                    return item;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static bool InsertItem(ItemModel item, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.Connection = connection;
                    insertCommand.CommandText = "INSERT INTO Artikal (Sifra, Naziv, OznakaVelicine, NazivSektora, Cijena, Opis, Boja)" +
                                                "VALUES (@sifra, @naziv, @oznakaVelicine, @nazivSektora, @cijena, @opis, @boja)";
                    insertCommand.Parameters.AddWithValue("sifra", item.Sifra);
                    insertCommand.Parameters.AddWithValue("naziv", item.Naziv);
                    insertCommand.Parameters.AddWithValue("oznakaVelicine", item.OznakaVelicine);
                    insertCommand.Parameters.AddWithValue("nazivSektora", item.NazivSektora);
                    insertCommand.Parameters.AddWithValue("cijena", item.Cijena);
                    insertCommand.Parameters.AddWithValue("opis", item.Opis);
                    insertCommand.Parameters.AddWithValue("boja", item.Boja);

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
        public static bool UpdateItem(ItemModel item, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandText = "UPDATE Artikal " +
                                                "SET Sifra = @sifra, " +
                                                "Naziv = @naziv, "+
                                                "OznakaVelicine = @oznakaVelicine, " +
                                                "NazivSektora = @nazivSektora, " +
                                                "Cijena = @cijena, " + 
                                                "Opis = @opis, " +
                                                "Boja = @boja " +
                                                "WHERE Id = @id";
                    updateCommand.Parameters.AddWithValue("sifra", item.Sifra);
                    updateCommand.Parameters.AddWithValue("naziv", item.Naziv);
                    updateCommand.Parameters.AddWithValue("oznakaVelicine", item.OznakaVelicine);
                    updateCommand.Parameters.AddWithValue("nazivSektora", item.NazivSektora);
                    updateCommand.Parameters.AddWithValue("cijena", item.Cijena);
                    updateCommand.Parameters.AddWithValue("opis", item.Opis);
                    updateCommand.Parameters.AddWithValue("boja", item.Boja);
                    updateCommand.Parameters.AddWithValue("id", item.Id);
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

        public static bool DeleteItem(int itemID, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand deleteCommand = new SqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandText = "DELETE FROM Artikal WHERE " +
                                                "Id = @id";
                    deleteCommand.Parameters.AddWithValue("id", itemID);

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

        public static List<SizeModel> GetSizes(int itemID, string connectionString)
        {
            using(SqlConnection connection=new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT OznakaVelicine FROM Artikal WHERE sifra=(SELECT sifra FROM Artikal WHERE Id=@ItemId)";
                    selectCommand.Parameters.AddWithValue("ItemId", itemID);
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
                catch
                {
                    return null;
                }

               
            }
        }
        public static List<string> GetColors(int itemId, string connectionString)
        {
            using(SqlConnection connection=new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "SELECT distinct Boja FROM Artikal WHERE sifra=(SELECT sifra FROM Artikal WHERE Id=@ItemId)";
                    selectCommand.Parameters.AddWithValue("ItemId", itemId);
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<string> result = new List<string>();

                    while (reader.Read())
                    {
                        string boja;
                        boja = reader.GetString(0);
                        result.Add(boja);
                    }
                    connection.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<ItemModel> GetWomanItemsByName(string naziv, string connectionString)
        {
            using(SqlConnection connection = new SqlConnection()){
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select * from (select * from Artikal where nazivSektora='Zenski') as t1 where naziv=@Naziv";
                    selectCommand.Parameters.AddWithValue("Naziv", naziv);

                    SqlDataReader reader = selectCommand.ExecuteReader(); 

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

                    }
                    connection.Close();
                    return result;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<ItemModel> GetWomanItemsByPrice(string price, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select * from (select * from Artikal where nazivSektora='Zenski') as t1 where Cijena<@Price";
                    selectCommand.Parameters.AddWithValue("Price", price);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

                    }
                    connection.Close();
                    return result;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<ItemModel> GetManItemsByName(string naziv, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select * from (select * from Artikal where nazivSektora='Muski') as t1 where naziv=@Naziv";
                    selectCommand.Parameters.AddWithValue("Naziv", naziv);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

                    }
                    connection.Close();
                    return result;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<ItemModel> GetManItemsByPrice(string price, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select * from (select * from Artikal where nazivSektora='Muski') as t1 where Cijena=@Price";
                    selectCommand.Parameters.AddWithValue("Price", price);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

                    }
                    connection.Close();
                    return result;

                }
                catch
                {
                    return null;
                }
            }
        }
        public static List<ItemModel> GetKidsItemsByName(string naziv, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select * from (select * from Artikal where nazivSektora='Djeciji') as t1 where naziv=@Naziv";
                    selectCommand.Parameters.AddWithValue("Naziv", naziv);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

                    }
                    connection.Close();
                    return result;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<ItemModel> GetKidsItemsByPrice(string price, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "select * from (select * from Artikal where nazivSektora='Djeciji') as t1 where Cijena=@Price";
                    selectCommand.Parameters.AddWithValue("Price", price);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<ItemModel> result = new List<ItemModel>();

                    while (reader.Read())
                    {
                        ItemModel item = new ItemModel();
                        item.Id = reader.GetInt32(0);
                        item.Sifra = reader.GetInt32(1);
                        item.Naziv = reader.GetString(2);
                        item.OznakaVelicine = reader.GetString(3);
                        item.NazivSektora = reader.GetString(4);
                        item.Cijena = reader.GetDecimal(5);
                        item.Opis = reader.GetString(6);
                        item.Boja = reader.GetString(7);
                        result.Add(item);

                    }
                    connection.Close();
                    return result;

                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
