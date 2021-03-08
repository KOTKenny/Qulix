using BLL.DTO.CreateModels;
using BLL.DTO.EditModels;
using BLL.DTO.SearchModels;
using BLL.DTO.ViewModels;
using BLL.Extensions;
using BLL.Helpers;
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
    public class CompanyService : ICompanyService
    {
        public static string OrderBy { get; set; } = "Id";

        public static string Direction { get; set; } = "ASC";

        private static IRepositoryManager _repositoryManager;

        public CompanyService()
        {
            _repositoryManager = new RepositoryManager(new DataManager());
        }

        public List<CompanyToView> GetCompanies(CompanyToSearch search, string sortingOrder)
        {
            Dictionary<string, string> Filter = new Dictionary<string, string>();

            // TO DO: ClearFilter

            if (sortingOrder == OrderBy)
                Direction = Direction != "ASC" ? "ASC" : "DESC";
            else
            {
                OrderBy = sortingOrder;
                Direction = "ASC";
            }

            foreach (var property in search.GetType().GetProperties())
            {
                var value = property.GetValue(search);
                if (value != null)
                    Filter.Add(property.Name, value.ToString());
            }

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(_repositoryManager.Company.GetCompaniesByCondition(company, OrderBy, Direction, Filter).Tables[0]);

            var ListOfCompaniesToView = Mapper.MapCollection<CompanyToView, Company>(ListOfCompanies, new Dictionary<string, KeyValuePair<string, Delegate>>() {
                    { "CompanyTypeName", new KeyValuePair<string, Delegate>("TypeId", new Func<Company, string, string>(CompanyHelper.GetCompanyTypeName)) },
                    { "CountOfWorkers",  new KeyValuePair<string, Delegate>("Id", new Func<Company, string, int>(CompanyHelper.GetWorkersCount)) }
                }).ToList();

            return ListOfCompaniesToView;
        }

        public CompanyToEdit GetCompanyById(int? id)
        {
            var company = new Company() { Id = Convert.ToInt32(id) };
            _repositoryManager.Company.GetCompanyById(company);

            var companyDto = Mapper.Map<CompanyToEdit>(company);

            return companyDto;
        }

        public void CreateCompany(CompanyToCreate companyDto)
        {
            var company = Mapper.Map<Company>(companyDto);

            _repositoryManager.Company.CreateCompany(company);
        }

        public void DeleteCompany(int? id)
        {
            var company = new Company() { Id = Convert.ToInt32(id) };

            _repositoryManager.Company.DeleteCompany(company);
        }

        public void UpdateCompany(CompanyToEdit companyDto)
        {
            var company = Mapper.Map<Company>(companyDto);

            _repositoryManager.Company.UpdateCompany(company);
        }

        public List<SelectListItem> GetCompaniesToSortDDL()
        {
            var ListOfCompaniesToView = GetCompaniesToDDL();
            ListOfCompaniesToView.Insert(0, new SelectListItem { Text = "Все" });

            return ListOfCompaniesToView;
        }

        public List<SelectListItem> GetCompaniesToDDL()
        {
            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(_repositoryManager.Company.GetAllCompanies(company).Tables[0]);
            var ListOfCompaniesToView = new SelectList(ListOfCompanies, "Id", "Name").ToList();

            return ListOfCompaniesToView;
        }

        public int GetCountOfCompanies()
        {
            var company = new Company();

            return _repositoryManager.Company.GetAllCompanies(company).Tables[0].Rows.Count;
        }

        public string GetNameOfBiggestCompany()
        {
            var dm = new DataManager();
            var ds = dm.QueryWithReturnData(String.Format("SELECT C.Name " +
                "FROM companies AS C " +
                "JOIN dbo.employees AS E ON E.CompanyId = C.Id " +
                "GROUP BY C.Id, C.Name " +
                "ORDER BY COUNT(E.Id) DESC"));

            return ds.Tables[0].Rows[0]["Name"].ToString();
        }
    }
}
