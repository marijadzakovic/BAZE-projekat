using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.DBOperations;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Services.Implementations
{
    public class SizeService : ISizeService
    {
        public List<SizeModel> GetSizes()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return SizeOperations.GetSizes(connectionString);
        }
    }
}