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
        public String TableName { get; set; }

        public EmployeeType()
        {
            TableName = "employeeTypes";
        }

        [DataGet]
        public Int32 Id { get; set; }

        [DataSet]
        [DataGet]
        public String Name { get; set; }

    }
}