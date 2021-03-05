using QulixTest.DAL.Attributes;
using QulixTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QulixTest.DAL.Models
{
    public class EmployeeType : IEntity
    {
        public DataManager DM;

        public String TableName { get; set; }

        public EmployeeType()
        {
            DM = new DataManager();
            TableName = "employeeTypes";
        }

        [DataGet]
        public Int32 Id { get; set; }

        [DataSet]
        [DataGet]
        public String Name { get; set; }

        public void Create()
        {
            DM.CreateData(this);
        }

        public void Delete(Int32 id)
        {
            this.Id = id;
            DM.DeleteData(this);
        }

        public DataSet GetAllItems()
        {
            return DM.GetAllData(this, null, null, null);
        }

        public dynamic GetById()
        {
            return DM.GetDataBy(this, "Id", null);
        }

        public void Update()
        {
            DM.UpdateData(this);
        }

        public DataSet GetAllItems(string orderBy, string direction, string whereField)
        {
            return DM.GetAllData(this, orderBy, direction, whereField);
        }
    }
}