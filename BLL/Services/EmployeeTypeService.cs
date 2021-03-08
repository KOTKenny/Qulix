using BLL.Extensions;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private static IRepositoryManager _repositoryManager = new RepositoryManager(new DataManager());

        public List<SelectListItem> GetEmployeeTypes()
        {
            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(_repositoryManager.EmployeeType.GetAllEmployeeTypes(employeeType).Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name").ToList();

            return ListOfEmployeesTypes;
        }

        public List<SelectListItem> GetEmployeeTypesToSortDDL()
        {
            var ListOfEmployeesTypes = GetEmployeeTypes();
            ListOfEmployeesTypes.Insert(0, new SelectListItem { Text = "Все" });

            return ListOfEmployeesTypes;
        }
    }
}
