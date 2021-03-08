using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QulixTest.Controllers
{
    public class HomeController : Controller
    {
        private static ICompanyService _companyService;
        private static IEmployeeService _employeeService;

        public HomeController()
        {
            _companyService = new CompanyService();
            _employeeService = new EmployeeService();
        }

        public ActionResult Index()
        {
            ViewBag.BiggestCompany = _companyService.GetNameOfBiggestCompany();
            ViewBag.CountOfCompanies = _companyService.GetCountOfCompanies();
            ViewBag.CountOfEmployees = _employeeService.GetCountOfEmployees();
            ViewBag.CountOfTesters = _employeeService.GetCountOfTesters();
            ViewBag.CountOfDevelopers = _employeeService.GetCountOfDevelopers();

            return View();
        }

    }
}