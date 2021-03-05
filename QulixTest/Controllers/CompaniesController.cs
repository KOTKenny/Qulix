using QulixTest.DAL.Models;
using QulixTest.DAL.Models.SearchModels;
using QulixTest.DAL.Models.ViewModels;
using QulixTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QulixTest.Controllers
{
    public class CompaniesController : Controller
    {

        public static string OrderBy { get; set; } = "Id";

        public static string Direction { get; set; } = "ASC";

        // GET: Companies
        public ActionResult Index(CompanyToSearch search, string Sorting_Order)
        {
            Dictionary<string, string> Filter = new Dictionary<string, string>();

            // TO DO: ClearFilter

            if (Sorting_Order == OrderBy)
                Direction = Direction != "ASC" ? "ASC" : "DESC";
            else
            {
                OrderBy = Sorting_Order;
                Direction = "ASC";
            }

            foreach (var property in search.GetType().GetProperties())
            {
                var value = property.GetValue(search);
                if (value != null)
                    Filter.Add(property.Name, value.ToString());
            }

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(company.GetAllItemsWhere(OrderBy, Direction, Filter).Tables[0]);

            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(companyType.GetAllItems("Id", "ASC", null).Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name")
                .ToList();
            ListOfCompaniesTypes.Insert(0, new SelectListItem { Text = "Все" });


            var ListOfCompaniesToView = Mapper.MapCollection<CompanyToView, Company>(ListOfCompanies, new Dictionary<string, KeyValuePair<string, Delegate>> () {
                    { "CompanyTypeName", new KeyValuePair<string, Delegate>("TypeId", new Func<Company, string, string>(CompanyHelper.GetCompanyTypeName)) },
                    { "CountOfWorkers",  new KeyValuePair<string, Delegate>("Id", new Func<Company, string, int>(CompanyHelper.GetWorkersCount)) }
                }).ToList();

            ViewBag.CompaniesTypes = ListOfCompaniesTypes;
            ViewBag.Companies = ListOfCompaniesToView;
            ViewBag.Count = ListOfCompaniesToView.Count();

            return View(search);
        }

        // GET: Companies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(companyType.GetAllItems().Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name");
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, TypeId")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.Create();
                return RedirectToAction("Index");
            }

            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(companyType.GetAllItems().Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name");

            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = new Company() { Id = Convert.ToInt32(id) };
            company.GetById();

            if (company == null)
            {
                return HttpNotFound();
            }

            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(companyType.GetAllItems().Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name", company.TypeId);
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, TypeId")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.Update();
                return RedirectToAction("Index");
            }

            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(companyType.GetAllItems().Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name", company.TypeId);
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = new Company() { Id = Convert.ToInt32(id) };
            company.GetById();

            if (company == null)
            {
                return HttpNotFound();
            }

            var companyType = new CompanyType();
            var ListOfTypes = Converters.ConvertDataTable<CompanyType>(companyType.GetAllItems().Tables[0]);
            var ListOfCompaniesTypes = new SelectList(ListOfTypes, "Id", "Name", company.TypeId);
            ViewBag.CompaniesTypes = ListOfCompaniesTypes;

            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var company = new Company();
            company.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
