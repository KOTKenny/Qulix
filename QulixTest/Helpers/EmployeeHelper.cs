using QulixTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QulixTest.Helpers
{
    public class EmployeeHelper
    {
        public static string GetEmployeeCompanyName(int companyId)
        {
            var company = new Company() { Id = companyId };

            company.GetById();

            return company.Name;
        }

        public static string GetEmployeeCompanyName(Employee obj, string properyName)
        {
            var companyId = obj.GetType().GetProperty(properyName).GetValue(obj);

            var company = new Company() { Id = Convert.ToInt32(companyId) };

            company.GetById();

            if (company.Id == 0)
                return "Не задано";

            return company.Name;
        }

        public static string GetEmployeeTypeName(int typeId)
        {
            var employeeType = new EmployeeType() { Id = typeId };

            employeeType.GetById();

            return employeeType.Name;
        }

        public static string GetEmployeeTypeName(Employee obj, string properyName)
        {
            var typeId = obj.GetType().GetProperty(properyName).GetValue(obj);

            var employeeType = new EmployeeType() { Id = Convert.ToInt32(typeId) };

            employeeType.GetById();

            return employeeType.Name;
        }
    }
}