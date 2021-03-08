using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        DataSet GetAllEmployees(Employee employee);
        DataSet GetEmployeesByCondition(Employee employee, string orderBy, string direction, Dictionary<string, string> whereFields);
        dynamic GetEmployeeById(Employee employee);
        void UpdateEmployee(Employee employee);
        DataSet GetEmployeesByConditionWithSingleWhere(Employee employee, string orderBy, string direction, string whereField);
    }
}
