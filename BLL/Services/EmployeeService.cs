using BLL.DTO.CreateModels;
using BLL.DTO.EditModels;
using BLL.DTO.SearchModels;
using BLL.DTO.ViewModels;
using BLL.Extensions;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        public static string OrderBy { get; set; } = "Id";

        public static string Direction { get; set; } = "ASC";

        private static IRepositoryManager _repositoryManager;

        public EmployeeService()
        {
            _repositoryManager = new RepositoryManager(new DataManager());
        }

        public List<EmployeeToView> GetEmployees(EmployeeToSearch search, string sortingOrder)
        {
            Dictionary<string, string> Filter = new Dictionary<string, string>();

            // TO DO: ClearFilter

            if (sortingOrder == OrderBy)
                Direction = Direction != "ASC" ? "ASC" : "DESC";
            else
            {
                OrderBy = sortingOrder;
                Direction = "ASC";
            }

            foreach (var property in search.GetType().GetProperties())
            {
                var value = property.GetValue(search);
                if (value != null)
                    Filter.Add(property.Name, value.ToString());
            }

            var employee = new Employee();
            var ListOfEmployees = Converters.ConvertDataTable<Employee>(_repositoryManager.Employee.GetEmployeesByCondition(employee, OrderBy, Direction, Filter).Tables[0]);

            var ListOfEmployeesToView = Mapper.MapCollection<EmployeeToView, Employee>(ListOfEmployees, new Dictionary<string, KeyValuePair<string, Delegate>>() {
                    { "EmployeeTypeName", new KeyValuePair<string, Delegate>("TypeId", new Func<Employee, string, string>(EmployeeHelper.GetEmployeeTypeName)) },
                    { "EmployeeCompanyName",  new KeyValuePair<string, Delegate>("CompanyId", new Func<Employee, string, string>(EmployeeHelper.GetEmployeeCompanyName)) }
                }).ToList();

            return ListOfEmployeesToView;
        }

        public EmployeeToEdit GetEmployeeById(int? id)
        {
            var employee = new Employee() { Id = Convert.ToInt32(id) };
            _repositoryManager.Employee.GetEmployeeById(employee);

            var employeeDto = Mapper.Map<EmployeeToEdit>(employee);

            return employeeDto;
        }

        public void CreateEmployee(EmployeeToCreate employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);

            _repositoryManager.Employee.CreateEmployee(employee);
        }

        public void DeleteEmployee(int? id)
        {
            var employee = new Employee() { Id = Convert.ToInt32(id) };

            _repositoryManager.Employee.DeleteEmployee(employee);
        }

        public void UpdateEmployee(EmployeeToEdit employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);

            _repositoryManager.Employee.UpdateEmployee(employee);
        }

        public int GetCountOfEmployees()
        {
            var employee = new Employee();

            return _repositoryManager.Employee.GetAllEmployees(employee).Tables[0].Rows.Count;
        }

        public int GetCountOfDevelopers()
        {
            var employee = new Employee() { TypeId = 1 };

            return _repositoryManager.Employee.GetEmployeesByConditionWithSingleWhere(employee, null, null, "TypeId")
                .Tables[0].Rows.Count;
        }

        public int GetCountOfTesters()
        {
            var employee = new Employee() { TypeId = 4 };

            return _repositoryManager.Employee.GetEmployeesByConditionWithSingleWhere(employee, null, null, "TypeId")
                .Tables[0].Rows.Count;
        }
    }
}
