using QulixTest.DAL.Attributes;
using QulixTest.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace QulixTest.DAL.Models
{
    public class Company : IEntity
    {
        public DataManager DM;

        public String TableName { get; set; }

        public Company()
        {
            DM = new DataManager();
            TableName = "companies";
            this.CreateDate = DateTime.Now;
        }

        [DataGet]
        public Int32 Id { get; set; }

        [DataSet]
        [DataGet]
        [Display(Name = "Наименование")]
        [Required]
        public String Name { get; set; }

        [DataSet]
        [DataGet]
        [Display(Name = "Организационно - правовая форма")]
        [Required]
        public Int32? TypeId { get; set; }

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

        public DataSet GetAllItemsWhere(string orderBy, string direction, Dictionary<string, string> whereFields)
        {
            return DM.GetAllDataWithWhere(this, orderBy, direction, whereFields);
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