using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Zara.Repository.DBOperations;
using Zara.Repository.Models.DB;
using Zara.Services.Interfaces;

namespace Zara.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
       
        public List<EmployeeModel> GetEmployees()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return EmployeeOperations.GetEmployees(connectionString);
        }

        public EmployeeModel GetEmployeeByID(int EmployeeID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return EmployeeOperations.GetEmployeeByID(EmployeeID, connectionString);

        }

        public bool DeleteEmployee(int EmployeeID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return EmployeeOperations.DeleteEmployee(EmployeeID, connectionString);
        }

        public bool InsertEmployee(EmployeeModel employee)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return EmployeeOperations.InsertEmployee(employee, connectionString);
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return EmployeeOperations.UpdateEmployee(employee, connectionString);
        }

        public EmployeeFullDetailsModel GetEmployeeFullDetails(int employeeID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return EmployeeOperations.GetEmployeesFullDetails(employeeID, connectionString);
        }

        public List<EmployeeModel> EmployeesWithoutContract()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ZaraDB"].ConnectionString;
            return EmployeeOperations.EmployeesWithoutContract(connectionString);
        }

    }
}