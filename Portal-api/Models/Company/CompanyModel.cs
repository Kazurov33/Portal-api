using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Company
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }

        [Display(Name = "Полное наименование")]
        public string Name { get; set; }

        [Display(Name = "Сокращенное наименование")]
        [Required(ErrorMessage = "Поле «Сокращенное наименование» обязательное")]
        public string ShortName { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле «Телефон» обязательное")]
        public string Phone { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }

        [Display(Name = "Фактический адрес")]
        public string ActualAddress { get; set; }

        [Display(Name = "Почтовый адрес")]
        public string MailingAddress { get; set; }

        [Display(Name = "ОГРН")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Неверно введен ОГРН")]
        public string OGRN { get; set; }

        [Display(Name = "ИНН")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Неверно введен ИНН")]
        public string INN { get; set; }

        [Display(Name = "КПП")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Неверно введен КПП")]
        public string KPP { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        public ICollection<Department> Departments { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public CompanyModel()
        {
            Departments = new List<Department>();
            Employees = new List<Employee>();
        }
    }
}