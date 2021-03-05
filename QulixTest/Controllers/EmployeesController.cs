using QulixTest.DAL;
using QulixTest.DAL.Models;
using QulixTest.DAL.Models.SearchModels;
using QulixTest.DAL.Models.ViewModels;
using QulixTest.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QulixTest.Controllers
{
    public class EmployeesController : Controller
    {

        public static string OrderBy { get; set; } = "Id";

        public static string Direction { get; set; } = "ASC";

        // GET: Companies
        public ActionResult Index(EmployeeToSearch search, string Sorting_Order)
        {
            Dictionary<string, string> Filter = new Dictionary<string, string>();

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

            var employee = new Employee();
            var ListOfEmployees = Converters.ConvertDataTable<Employee>(employee.GetAllItemsWhere(OrderBy, Direction, Filter).Tables[0]);

            var ListOfEmployeesToView = Mapper.MapCollection<EmployeeToView, Employee>(ListOfEmployees, new Dictionary<string, KeyValuePair<string, Delegate>>() {
                    { "EmployeeTypeName", new KeyValuePair<string, Delegate>("TypeId", new Func<Employee, string, string>(EmployeeHelper.GetEmployeeTypeName)) },
                    { "EmployeeCompanyName",  new KeyValuePair<string, Delegate>("CompanyId", new Func<Employee, string, string>(EmployeeHelper.GetEmployeeCompanyName)) }
                }).ToList();

            ViewBag.Employees = ListOfEmployeesToView;

            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(employeeType.GetAllItems().Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name").ToList();
            ListOfEmployeesTypes.Insert(0, new SelectListItem { Text = "Все" });
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(company.GetAllItems().Tables[0]);
            var ListOfCompaniesToView = new SelectList(ListOfCompanies, "Id", "Name").ToList();
            ListOfCompaniesToView.Insert(0, new SelectListItem { Text = "Все" });
            ViewBag.Companies = ListOfCompaniesToView;

            ViewBag.Count = ListOfEmployeesToView.Count();

            return View(search);
        }

        // GET: Companies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(employeeType.GetAllItems().Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name");
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(company.GetAllItems().Tables[0]);
            var ListOfCompaniesToView = new SelectList(ListOfCompanies, "Id", "Name");
            ViewBag.Companies = ListOfCompaniesToView;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, SecondName, ThirdName, TypeId, CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Create();
                return RedirectToAction("Index");
            }

            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(employeeType.GetAllItems().Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name");
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(company.GetAllItems().Tables[0]);
            var ListOfCompaniesToView = new SelectList(ListOfCompanies, "Id", "Name");
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = new Employee() { Id = Convert.ToInt32(id) };
            employee.GetById();

            if (employee == null)
            {
                return HttpNotFound();
            }

            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(employeeType.GetAllItems().Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name");
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(company.GetAllItems().Tables[0]);
            var ListOfCompaniesToView = new SelectList(ListOfCompanies, "Id", "Name");
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, FirstName, SecondName, ThirdName, TypeId, CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Update();
                return RedirectToAction("Index");
            }

            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(employeeType.GetAllItems().Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name");
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(company.GetAllItems().Tables[0]);
            var ListOfCompaniesToView = new SelectList(ListOfCompanies, "Id", "Name");
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = new Employee() { Id = Convert.ToInt32(id) };
            employee.GetById();

            if (employee == null)
            {
                return HttpNotFound();
            }

            var employeeType = new EmployeeType();
            var ListOfTypes = Converters.ConvertDataTable<EmployeeType>(employeeType.GetAllItems().Tables[0]);
            var ListOfEmployeesTypes = new SelectList(ListOfTypes, "Id", "Name");
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var company = new Company();
            var ListOfCompanies = Converters.ConvertDataTable<Company>(company.GetAllItems().Tables[0]);
            var ListOfCompaniesToView = new SelectList(ListOfCompanies, "Id", "Name");
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = new Employee();
            employee.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
