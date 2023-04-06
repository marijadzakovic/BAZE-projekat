using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.Models.DB;

namespace Zara.Services.Interfaces
{
    public interface IContractService
    {
        List<ContractModel> GetContracts();
        ContractModel GetContractByID(int ContractID);
        bool InsertContract(ContractModel contract);
        bool DeleteContract(int ContractID);
        bool UpdateContract(ContractModel contract);
        ContractModel GetContractByEmployeeID(int contractID);
        List<ContractModel> GetContractsByRadnoMjesto(string radnomjesto);
    }
}