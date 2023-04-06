using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.DBOperations;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Services.Implementations
{
    public class ContractService : IContractService
    {
        public bool DeleteContract(int ContractID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ContractOperations.DeleteContract(ContractID, connectionString);
        }

        public ContractModel GetContractByEmployeeID(int contractID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ContractOperations.GetContractByEmployeeID(contractID, connectionString);
        }

        public ContractModel GetContractByID(int ContractID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ContractOperations.GetContractByID(ContractID, connectionString);
        }

        public List<ContractModel> GetContracts()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ContractOperations.GetContracts(connectionString);
        }

        public List<ContractModel> GetContractsByRadnoMjesto(string radnomjesto)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ContractOperations.GetContractsByRadnoMjesto(radnomjesto, connectionString);
        }

        public bool InsertContract(ContractModel contract)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ContractOperations.InsertContract(contract, connectionString);
        }

        public bool UpdateContract(ContractModel contract)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return ContractOperations.UpdateContract(contract, connectionString);
        }
    }
}