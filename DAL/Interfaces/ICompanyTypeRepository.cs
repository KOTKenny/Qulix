using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICompanyTypeRepository
    {
        void CreateCompanyType(CompanyType companyType);
        void DeleteCompanyType(CompanyType companyType);
        DataSet GetAllCompanyTypes(CompanyType companyType);
        DataSet GetCompanyTypesByCondition(CompanyType companyType, string orderBy, string direction, Dictionary<string, string> whereFields);
        dynamic GetCompanyTypeById(CompanyType companyType);
        void UpdateCompanyType(CompanyType companyType);
        DataSet GetCompanyTypesByConditionWithSingleWhere(CompanyType companyType, string orderBy, string direction, string whereField);
    }
}
