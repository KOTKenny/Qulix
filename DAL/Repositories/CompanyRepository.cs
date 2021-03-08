using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(DataManager dataManager) 
            : base(dataManager) { }

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) => Delete(company);

        public DataSet GetAllCompanies(Company company) => GetAllItems(company);

        public DataSet GetCompaniesByCondition(Company company, string orderBy, string direction, Dictionary<string, string> whereFields) => GetItemsByCondition(company, orderBy, direction, whereFields);

        public dynamic GetCompanyById(Company company) => GetById(company);

        public void UpdateCompany(Company company) => Update(company);

        public DataSet GetCompaniesByConditionWithSingleWhere(Company company, string orderBy, string direction, string whereField) => GetItemsByCondition(company, orderBy, direction, whereField);
    }
}
