using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.DBOperations;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Services.Implementations
{
    public class UserService : IUserService
    {
        public UserModel Login(UserModel userData)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return UserOperations.Login(userData, connectionString);
        }
    }
}