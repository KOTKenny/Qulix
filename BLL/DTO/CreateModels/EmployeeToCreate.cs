using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.CreateModels
{
    public class EmployeeToCreate
    {
        [Display(Name = "Имя")]
        [Required]
        public String FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        public String SecondName { get; set; }

        [Display(Name = "Отчество")]
        [Required]
        public String ThirdName { get; set; }

        [Required]
        public Int32? TypeId { get; set; }

        [Required]
        public Int32? CompanyId { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
