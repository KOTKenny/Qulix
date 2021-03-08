using DAL.Attributes;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DAL.Models
{
    public class Company : IEntity
    {
        public String TableName { get; set; }

        public Company()
        {
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

    }
}