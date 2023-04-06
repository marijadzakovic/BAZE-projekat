using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zara.Repository.Models.DB;
using Zara.Services.Implementations;
using Zara.Services.Interfaces;

namespace Zara.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private ISectorService _sectorService;

        public EmployeeController(IEmployeeService employeeService, ISectorService sectorService)
        {
            this._employeeService = employeeService;
            this._sectorService = sectorService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            

            List<EmployeeModel> employees = this._employeeService.GetEmployees();
            ViewBag.Employees = employees;
            return View();
        }
        public ActionResult ViewEmployeeDetails(int employeeID)
        {
            EmployeeFullDetailsModel result = this._employeeService.GetEmployeeFullDetails(employeeID);
            return View(result);
           
        }
        public ActionResult Create()
        {
            List<SectorModel> sectors = this._sectorService.GetSectors();
            ViewBag.Sectors = sectors;
            return View("Employee");
        }

        public ActionResult Store(EmployeeModel employee)
        {
            bool result=false;
            if (employee.ZaposleniID == 0)
            {
                result = this._employeeService.InsertEmployee(employee);
            }
            else
            {
                result = this._employeeService.UpdateEmployee(employee);
            }
            if (result)
            {

                return RedirectToAction("Index");
            } else
            {
                return View("Employee", employee);
            }
        }
        public ActionResult Delete(int employeeID)
        {
            bool result = this._employeeService.DeleteEmployee(employeeID);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return null;
            }
        }

        public ActionResult Edit(int EmployeeID)
        {
            List<SectorModel> sectors = this._sectorService.GetSectors();
            ViewBag.Sectors = sectors;
            EmployeeModel employee = this._employeeService.GetEmployeeByID(EmployeeID);
            return View("Employee", employee);
        }

        public ActionResult EmployeesWithoutContract()
        {
            List<EmployeeModel> result = this._employeeService.EmployeesWithoutContract();
            ViewBag.Result = result;
            return View("Index");
        }
    }
}