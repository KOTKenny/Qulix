using QulixTest.DAL;
using QulixTest.DAL.Models;
using System;

namespace QulixTest.Helpers
{
    public class StatisticHelper
    {
        public static string GetNameOfBiggestCompany()
        {
            var dm = new DataManager();
            var ds = dm.QueryWithReturnData(String.Format("SELECT C.Name " +
                "FROM companies AS C " +
                "JOIN dbo.employees AS E ON E.CompanyId = C.Id " +
                "GROUP BY C.Id, C.Name " +
                "ORDER BY COUNT(E.Id) DESC"));

            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

        public static int GetCountOfCompanies()
        {
            var company = new Company();

            return company.GetAllItems().Tables[0].Rows.Count;
        }

        public static int GetCountOfEmployees()
        {
            var employee = new Employee();

            return employee.GetAllItems().Tables[0].Rows.Count;
        }

        public static int GetCountOfDevelopers()
        {
            var employee = new Employee() { TypeId = 1 };

            return employee.GetAllItems(null, null, "TypeId").Tables[0].Rows.Count;
        }

        public static int GetCountOfTesters()
        {
            var employee = new Employee() { TypeId = 4 };

            return employee.GetAllItems(null, null, "TypeId").Tables[0].Rows.Count;
        }
    }
}