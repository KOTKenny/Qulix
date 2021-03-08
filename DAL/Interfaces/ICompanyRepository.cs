using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICompanyRepository
    {
        void CreateCompany(Company company);
        void DeleteCompany(Company company);
        DataSet GetAllCompanies(Company company);
        DataSet GetCompaniesByCondition(Company company, string orderBy, string direction, Dictionary<string, string> whereFields);
        dynamic GetCompanyById(Company company);
        void UpdateCompany(Company company);
        DataSet GetCompaniesByConditionWithSingleWhere(Company company, string orderBy, string direction, string whereField);
    }
}
