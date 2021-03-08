using BLL.DTO.CreateModels;
using BLL.DTO.EditModels;
using BLL.DTO.SearchModels;
using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QulixTest.Controllers
{
    public class CompaniesController : Controller
    {
        private static ICompanyService _companyService;

        public CompaniesController()
        {
            _companyService = new CompanyService();
        }

        // GET: Companies
        public ActionResult Index(CompanyToSearch search, string Sorting_Order)
        {
            var ListOfCompaniesToView = _companyService.GetCompanies(search, Sorting_Order);

            var ListOfCompaniesTypes = CompanyTypeService.GetCompanyTypes();

            ViewBag.CompaniesTypes = ListOfCompaniesTypes;
            ViewBag.Companies = ListOfCompaniesToView;
            ViewBag.Count = ListOfCompaniesToView.Count();

            return View(search);
        }

        public ActionResult Create()
        {
            var ListOfCompaniesTypes = CompanyTypeService.GetCompanyTypes();
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, TypeId")] CompanyToCreate company)
        {
            if (ModelState.IsValid)
            {
                _companyService.CreateCompany(company);
                return RedirectToAction("Index");
            }

            var ListOfCompaniesTypes = CompanyTypeService.GetCompanyTypes();

            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = _companyService.GetCompanyById(id);

            if (company.Id == 0)
            {
                return HttpNotFound();
            }

            var ListOfCompaniesTypes = CompanyTypeService.GetCompanyTypes();
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, TypeId")] CompanyToEdit company)
        {
            if (ModelState.IsValid)
            {
                _companyService.UpdateCompany(company);
                return RedirectToAction("Index");
            }

            var ListOfCompaniesTypes = CompanyTypeService.GetCompanyTypes();
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = _companyService.GetCompanyById(id);

            if (company.Id == 0)
            {
                return HttpNotFound();
            }

            var ListOfCompaniesTypes = CompanyTypeService.GetCompanyTypes();
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _companyService.DeleteCompany(id);
            return RedirectToAction("Index");
        }
    }
}
