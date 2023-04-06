using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Controllers
{
    public class ContractController : Controller
    {
        private IContractService _contractService;
        private IEmployeeService _employeeService;
        // GET: Contract

        public ContractController(IContractService contractService, IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
            this._contractService = contractService;
        }
        public ActionResult Index()
        {
            List<ContractModel> contracts = this._contractService.GetContracts();
            ViewBag.Contracts = contracts;
            return View();
        }

        public ActionResult Insert()
        {
            List<EmployeeModel> employeesWithoutContract = this._employeeService.EmployeesWithoutContract();
            ViewBag.EmployeesWithoutContract = employeesWithoutContract;
            return View();
        }

        public ActionResult Store(ContractModel contract)
        {
            bool result = false;
            result = this._contractService.InsertContract(contract);
            
            if (result)
            {

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Vjerovatno ste unijeli sifru ugovora koja vec postoji, pokusajte ponovo.";
                return View("Insert", contract);
            }
        }

        public ActionResult Edit(int EmployeeID)
        {
            
            ContractModel contract = this._contractService.GetContractByEmployeeID(EmployeeID);
            return View(contract);
        }
        public ActionResult Store1(ContractModel contract)
        {
            bool result = false;
            result = this._contractService.UpdateContract(contract);
            
            if (result)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", contract);
            }
        }
        public ActionResult Delete(int contractID)
        {
            bool result = this._contractService.DeleteContract(contractID);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Search(string searchValue)
        {
            List<ContractModel> allcontracts = this._contractService.GetContracts();
            if (string.IsNullOrEmpty(searchValue))
            {
                ViewBag.SearchValue = searchValue;
                return View(allcontracts);
            }
            else
            {
                List<ContractModel> contracts = this._contractService.GetContractsByRadnoMjesto(searchValue);
                ViewBag.Contracts = contracts;
                return View();
            }

        }

    }
}