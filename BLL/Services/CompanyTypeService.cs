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
    public class CompanyTypeService : ICompanyTypeService
    {
        private static IRepositoryManager _repositoryManager = new RepositoryManager(new DataManager());

        public List<SelectListItem> GetCompanyTypes()
        {
            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(_repositoryManager.CompanyType.GetCompanyTypesByConditionWithSingleWhere(companyType, "Id", "ASC", null).Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name")
                .ToList();

            return ListOfCompaniesTypes;
        }

        public List<SelectListItem> GetCompanyTypesToSortDDL()
        {
            var ListOfCompaniesTypes = GetCompanyTypes();
            ListOfCompaniesTypes.Insert(0, new SelectListItem { Text = "Все" });

            return ListOfCompaniesTypes;
        }
    }
}
