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
    public class CompanyTypeService
    {
        public static List<SelectListItem> GetCompanyTypes()
        {
            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(companyType.GetAllItems("Id", "ASC", null).Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name")
                .ToList();
            ListOfCompaniesTypes.Insert(0, new SelectListItem { Text = "Все" });

            return ListOfCompaniesTypes;
        }
    }
}
