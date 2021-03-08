using DAL.Models;
using DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.DAL
{
    [TestClass]
    public class TestCompanyMethods
    {
        [TestMethod]
        public void TestCompanyCreate()
        {
            var rand = new Random();
            var name = String.Format("Test Company #{0}", rand.Next(1000));

            var company = new Company()
            {
                TypeId = rand.Next(10),
                Name = name
            };

            var DM = new DataManager(@"Data Source=.\SQLEXPRESS;Initial Catalog=QulixDB;Integrated Security=True;");

            var _repositoryManager = new RepositoryManager(DM);

            _repositoryManager.Company.CreateCompany(company);

            var ds = DM.QueryWithReturnData(String.Format("SELECT * FROM companies WHERE Name = '{0}'", name));

            Assert.IsTrue(ds.Tables[0].Rows.Count == 1);

        }
    }
}
