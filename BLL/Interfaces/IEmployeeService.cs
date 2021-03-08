using BLL.DTO.CreateModels;
using BLL.DTO.EditModels;
using BLL.DTO.SearchModels;
using BLL.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeToView> GetEmployees(EmployeeToSearch search, string sortingOrder);
        void CreateEmployee(EmployeeToCreate employeeDto);
        EmployeeToEdit GetEmployeeById(int? id);
        void DeleteEmployee(int? id);
        void UpdateEmployee(EmployeeToEdit employeeDto);
        int GetCountOfEmployees();
        int GetCountOfDevelopers();
        int GetCountOfTesters();
    }
}
