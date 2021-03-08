using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.EditModels
{
    public class EmployeeToEdit
    {
        [Required]
        public Int32 Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Вы не ввели имя")]
        [StringLength(50, ErrorMessage = "Имя может иметь длинну максимум 50 символов")]
        public String FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Вы не ввели фамилию")]
        [StringLength(50, ErrorMessage = "Фамилия может иметь длинну максимум 50 символов")]
        public String SecondName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Вы не ввели отчество")]
        [StringLength(50, ErrorMessage = "Отчество может иметь длинну максимум 50 символов")]
        public String ThirdName { get; set; }

        [Required]
        public Int32? TypeId { get; set; }

        [Required]
        public Int32? CompanyId { get; set; }

        [Display(Name = "Дата принятия на работу")]
        [Required(ErrorMessage = "Дата принятия на работу не заполнена")]
        [DataType(DataType.Date, ErrorMessage = "Поле 'Дата' имеет неверный формат!")]
        public DateTime? AssignedDate { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
