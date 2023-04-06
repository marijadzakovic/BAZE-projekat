using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.Models.DB;

namespace Zara.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Login(UserModel userData);
    }
}