using BLL.Services;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Helpers
{
    public class EmployeeHelper
    {
        private static IRepositoryManager _repositoryManager = new RepositoryManager(new DataManager());
        public static string GetEmployeeCompanyName(int companyId)
        {
            var company = new Company() { Id = companyId };

            _repositoryManager.Company.GetCompanyById(company);

            return company.Name;

        }

        public static string GetEmployeeCompanyName(Employee obj, string properyName)
        {
            var companyId = obj.GetType().GetProperty(properyName).GetValue(obj);

            var company = new Company() { Id = Convert.ToInt32(companyId) };

            _repositoryManager.Company.GetCompanyById(company);

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