using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QulixTest.DAL.Models.ViewModels
{
    public class CompanyToView
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public string CompanyTypeName { get; set; }

        public int CountOfWorkers { get; set; }
    }
}