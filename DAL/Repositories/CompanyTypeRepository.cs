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
    public class CompanyTypeRepository : RepositoryBase<CompanyType>, ICompanyTypeRepository
    {
        public CompanyTypeRepository(DataManager dataManager) 
            : base(dataManager) { }

        public void CreateCompanyType(CompanyType companyType) => Create(companyType);

        public void DeleteCompanyType(CompanyType companyType) => Delete(companyType);

        public DataSet GetAllCompanyTypes(CompanyType companyType) => GetAllItems(companyType);

        public DataSet GetCompanyTypesByCondition(CompanyType companyType, string orderBy, string direction, Dictionary<string, string> whereFields) => GetItemsByCondition(companyType, orderBy, direction, whereFields);

        public dynamic GetCompanyTypeById(CompanyType companyType) => GetById(companyType);

        public void UpdateCompanyType(CompanyType companyType) => Update(companyType);

        public DataSet GetCompanyTypesByConditionWithSingleWhere(CompanyType companyType, string orderBy, string direction, string whereField) => GetItemsByCondition(companyType, orderBy, direction, whereField);
    }
}
