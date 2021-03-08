using BLL.DTO.CreateModels;
using BLL.DTO.EditModels;
using BLL.DTO.SearchModels;
using BLL.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyToView> GetCompanies(CompanyToSearch search, string sortingOrder);
        void CreateCompany(CompanyToCreate companyDto);
        CompanyToEdit GetCompanyById(int? id);
        void DeleteCompany(int? id);
        void UpdateCompany(CompanyToEdit companyDto);
        List<SelectListItem> GetCompaniesToSortDDL();
        List<SelectListItem> GetCompaniesToDDL();
        int GetCountOfCompanies();
        string GetNameOfBiggestCompany();
    }
}
