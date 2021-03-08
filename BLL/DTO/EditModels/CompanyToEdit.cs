using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.EditModels
{
    public class CompanyToEdit
    {
        [Required]
        public Int32 Id { get; set; }

        [Required(ErrorMessage = "Вы не ввели наименование")]
        [StringLength(400, ErrorMessage = "Наименование может иметь длинну максимум 400 символов")]
        public String Name { get; set; }

        [Display(Name = "Организационно - правовая форма")]
        [Required]
        public Int32? TypeId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
