using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.DBOperations;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Services.Implementations
{
    public class SectorService : ISectorService
    {
        public List<SectorModel> GetSectors()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return SectorOperations.GetSectors(connectionString);
        }
    }
}