using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CreateModels
{
    public class CompanyToCreate
    {
        [Display(Name = "Наименование")]
        [Required]
        public String Name { get; set; }

        [Display(Name = "Организационно - правовая форма")]
        [Required]
        public Int32? TypeId { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
