using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QulixTest.DAL.Models.SearchModels
{
    public class EmployeeToSearch
    {
        [Display(Name = "ID")]
        public Int32? Id { get; set; }

        [Display(Name = "Фамилия")]
        public String SecondName { get; set; }

        [Display(Name = "Должность")]
        public Int32? TypeId { get; set; }

        [Display(Name = "Компания")]
        public Int32? CompanyId { get; set; }
    }
}