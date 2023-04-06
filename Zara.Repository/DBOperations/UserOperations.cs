using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zara.Repository.Models.DB;

namespace Zara.Repository.DBOperations
{
    public class UserOperations
    {
        public static List<UserModel> GetUsers(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from User";
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    List<UserModel> result = new List<UserModel>();

                    while (reader.Read())
                    {
                        UserModel user = new UserModel();
                        user.Username = reader.GetString(0);
                        user.Password = reader.GetString(1);


                        result.Add(user);

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
        public static UserModel Login(UserModel userData, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    SqlCommand selectCommand = new SqlCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandText = "Select * from [User] WHERE Username=@username AND Password=@password";
                    selectCommand.Parameters.AddWithValue("username", userData.Username);
                    selectCommand.Parameters.AddWithValue("password", userData.Password);

                    SqlDataReader reader = selectCommand.ExecuteReader();
                    if (!reader.Read())
                    {
                        return null;
                    }

                    //reader.getstring popunjavanje isadmin ..email, name
                    connection.Close();
                    return userData;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
