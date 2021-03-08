using DAL.Attributes;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL.Models
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
            return DM.GetDataByCondition(this, null, null, null);
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
            return DM.GetDataByCondition(this, orderBy, direction, whereField);
        }
    }
}