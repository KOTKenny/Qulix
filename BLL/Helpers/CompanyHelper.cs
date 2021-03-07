using QulixTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QulixTest.Helpers
{
    public class CompanyHelper
    {
        public static int GetWorkersCount(int companyId)
        {
            var employee = new Employee() { CompanyId = companyId };

            var ds = employee.GetAllItems(null, null, "CompanyId");

            return ds.Tables[0].Rows.Count;
        }

        public static string GetCompanyTypeName(int typeId)
        {
            var companyType = new CompanyType() { Id = typeId };

            companyType.GetById();

            return companyType.Name;
        }

        public static int GetWorkersCount(Company obj, string properyName)
        {
            var companyId = obj.GetType().GetProperty(properyName).GetValue(obj);

            var employee = new Employee() { CompanyId = Convert.ToInt32(companyId) };

            var ds = employee.GetAllItems(null, null, "CompanyId");

            return ds.Tables[0].Rows.Count;
        }

        public static string GetCompanyTypeName(Company obj, string properyName)
        {
            var typeId = obj.GetType().GetProperty(properyName).GetValue(obj);

            var companyType = new CompanyType() { Id = Convert.ToInt32(typeId) };

            companyType.GetById();

            return companyType.Name;
        }
    }
}