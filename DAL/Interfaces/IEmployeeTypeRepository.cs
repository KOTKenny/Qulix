using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployeeTypeRepository
    {
        void CreateEmployeeType(EmployeeType employeeType);
        void DeleteEmployeeType(EmployeeType employeeType);
        DataSet GetAllEmployeeTypes(EmployeeType employeeType);
        DataSet GetEmployeeTypesByCondition(EmployeeType employeeType, string orderBy, string direction, Dictionary<string, string> whereFields);
        dynamic GetEmployeeTypeById(EmployeeType employeeType);
        void UpdateEmployeeType(EmployeeType employeeType);
        DataSet GetEmployeeTypesByConditionWithSingleWhere(EmployeeType employeeType, string orderBy, string direction, string whereField);
    }
}
