using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.DTO.ViewModels
{
    public class EmployeeToView
    {
        public Int32 Id { get; set; }

        public String FirstName { get; set; }

        public String SecondName { get; set; }

        public String ThirdName { get; set; }

        public string EmployeeTypeName { get; set; }

        public string EmployeeCompanyName { get; set; }

        public DateTime CreateDate { get; set; }
    }
}