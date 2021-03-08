using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataManager dataManager) :
            base(dataManager)
        {

        }

        public void CreateEmployee(Employee employee) => Create(employee);

        public void DeleteEmployee(Employee employee) => Delete(employee);

        public DataSet GetAllEmployees(Employee employee) => GetAllItems(employee);

        public dynamic GetEmployeeById(Employee employee) => GetById(employee);

        public DataSet GetEmployeesByCondition(Employee employee, string orderBy, string direction, Dictionary<string, string> whereFields) =>
            GetItemsByCondition(employee, orderBy, direction, whereFields);

        public DataSet GetEmployeesByConditionWithSingleWhere(Employee employee, string orderBy, string direction, string whereField) =>
            GetItemsByCondition(employee, orderBy, direction, whereField);

        public void UpdateEmployee(Employee employee) => Update(employee);
    }
}
