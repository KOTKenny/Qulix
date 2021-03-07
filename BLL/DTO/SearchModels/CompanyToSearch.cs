using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QulixTest.DAL.Models.SearchModels
{
    public class CompanyToSearch
    {
        [Display(Name = "ID")]
        public Int32? Id { get; set; }

        [Display(Name = "Организационно - правовая форма")]
        public Int32? TypeId { get; set; }
    }
}