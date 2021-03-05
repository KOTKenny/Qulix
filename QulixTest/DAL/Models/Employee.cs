using QulixTest.DAL.Attributes;
using QulixTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace QulixTest.DAL.Models
{
    public class Employee : IEntity
    {
        public DataManager DM;

        public String TableName { get; set; }

        public Employee()
        {
            DM = new DataManager();
            TableName = "employees";
            this.CreateDate = DateTime.Now;
        }

        [DataGet]
        public Int32 Id { get; set; }

        [DataSet]
        [DataGet]
        [Display(Name = "Имя")]
        [Required]
        public String FirstName { get; set; }

        [DataSet]
        [DataGet]
        [Display(Name = "Фамилия")]
        [Required]
        public String SecondName { get; set; }

        [DataSet]
        [DataGet]
        [Display(Name = "Отчество")]
        [Required]
        public String ThirdName { get; set; }

        [DataSet]
        [DataGet]
        [Required]
        public Int32? TypeId { get; set; }

        [DataSet]
        [DataGet]
        [Required]
        public Int32? CompanyId { get; set; }

        [DataSet]
        [DataGet]
        public DateTime CreateDate { get; set; }

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

        public DataSet GetAllItemsWhere(string orderBy, string direction, Dictionary<string, string> whereFields)
        {
            return DM.GetAllDataWithWhere(this, orderBy, direction, whereFields);
        }
    }
}