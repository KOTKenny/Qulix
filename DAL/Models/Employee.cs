using DAL.Attributes;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class Employee : IEntity
    {
        public String TableName { get; set; }

        public Employee()
        {
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

    }
}