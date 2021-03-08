using BLL.Extensions;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.Services
{
    public class EmployeeTypeService
    {
        public static List<SelectListItem> GetEmployeeTypes()
        {
            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(employeeType.GetAllItems().Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name").ToList();
            ListOfEmployeesTypes.Insert(0, new SelectListItem { Text = "Все" });

            return ListOfEmployeesTypes;
        }
    }
}
