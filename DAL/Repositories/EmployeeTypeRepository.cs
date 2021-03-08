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
    public class EmployeeTypeRepository : RepositoryBase<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(DataManager dataManager) 
            : base(dataManager) { }

        public void CreateEmployeeType(EmployeeType employeeType) => Create(employeeType);

        public void DeleteEmployeeType(EmployeeType employeeType) => Delete(employeeType);

        public DataSet GetAllEmployeeTypes(EmployeeType employeeType) => GetAllItems(employeeType);

        public DataSet GetEmployeeTypesByCondition(EmployeeType employeeType, string orderBy, string direction, Dictionary<string, string> whereFields) => GetItemsByCondition(employeeType, orderBy, direction, whereFields);

        public dynamic GetEmployeeTypeById(EmployeeType employeeType) => GetById(employeeType);

        public void UpdateEmployeeType(EmployeeType employeeType) => Update(employeeType);

        public DataSet GetEmployeeTypesByConditionWithSingleWhere(EmployeeType employeeType, string orderBy, string direction, string whereField) => GetItemsByCondition(employeeType, orderBy, direction, whereField);
    }
}
