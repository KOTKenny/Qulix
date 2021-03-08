using BLL.DTO.CreateModels;
using BLL.DTO.EditModels;
using BLL.DTO.SearchModels;
using BLL.Interfaces;
using BLL.Services;
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

        private static IEmployeeService _employeeService;
        private static ICompanyService _companyService;

        public EmployeesController()
        {
            _employeeService = new EmployeeService();
            _companyService = new CompanyService();
        }

        // GET: Companies
        public ActionResult Index(EmployeeToSearch search, string Sorting_Order)
        {

            var ListOfEmployeesToView = _employeeService.GetEmployees(search, Sorting_Order);
            ViewBag.Employees = ListOfEmployeesToView;

            var ListOfEmployeesTypes = EmployeeTypeService.GetEmployeeTypes();
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var ListOfCompaniesToView = _companyService.GetCompaniesToDDL();
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
            var ListOfEmployeesTypes = EmployeeTypeService.GetEmployeeTypes();
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var ListOfCompaniesToView = _companyService.GetCompaniesToDDL();
            ViewBag.Companies = ListOfCompaniesToView;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, SecondName, ThirdName, TypeId, CompanyId")] EmployeeToCreate employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                return RedirectToAction("Index");
            }

            var ListOfEmployeesTypes = EmployeeTypeService.GetEmployeeTypes();
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var ListOfCompaniesToView = _companyService.GetCompaniesToDDL();
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _employeeService.GetEmployeeById(id);

            if (employee.Id == 0)
            {
                return HttpNotFound();
            }

            var ListOfEmployeesTypes = EmployeeTypeService.GetEmployeeTypes();
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var ListOfCompaniesToView = _companyService.GetCompaniesToDDL();
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, FirstName, SecondName, ThirdName, TypeId, CompanyId")] EmployeeToEdit employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            var ListOfEmployeesTypes = EmployeeTypeService.GetEmployeeTypes();
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var ListOfCompaniesToView = _companyService.GetCompaniesToDDL();
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _employeeService.GetEmployeeById(id);

            if (employee.Id == 0)
            {
                return HttpNotFound();
            }

            var ListOfEmployeesTypes = EmployeeTypeService.GetEmployeeTypes();
            ViewBag.EmployeesTypes = ListOfEmployeesTypes;

            var ListOfCompaniesToView = _companyService.GetCompaniesToDDL();
            ViewBag.Companies = ListOfCompaniesToView;

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
