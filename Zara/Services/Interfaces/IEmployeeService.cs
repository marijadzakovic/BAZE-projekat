using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zara.Repository.Models.DB;

namespace Zara.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetEmployees();

       // EmployeeModel GetEmployeeFullDetails();
        EmployeeModel GetEmployeeByID(int EmployeeID);
        EmployeeFullDetailsModel GetEmployeeFullDetails(int employeeID);
        bool InsertEmployee(EmployeeModel employee);
        bool DeleteEmployee(int EmployeeID);
        bool UpdateEmployee(EmployeeModel employee);
        List<EmployeeModel> EmployeesWithoutContract();
    }
}