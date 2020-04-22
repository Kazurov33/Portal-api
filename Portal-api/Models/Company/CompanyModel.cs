using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Company
{
    public class CompanyModel
    {
        [Key]
        public int CompanyId { get; set; }

        [Display(Name = "������ ������������")]
        public string Name { get; set; }

        [Display(Name = "����������� ������������")]
        [Required(ErrorMessage = "���� ������������ ������������ ������������")]
        public string ShortName { get; set; }

        [Display(Name = "�������")]
        [Required(ErrorMessage = "���� �������� ������������")]
        public string Phone { get; set; }

        [Display(Name = "����������� �����")]
        public string LegalAddress { get; set; }

        [Display(Name = "����������� �����")]
        public string ActualAddress { get; set; }

        [Display(Name = "�������� �����")]
        public string MailingAddress { get; set; }

        [Display(Name = "����")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "������� ������ ����")]
        public string OGRN { get; set; }

        [Display(Name = "���")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "������� ������ ���")]
        public string INN { get; set; }

        [Display(Name = "���")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "������� ������ ���")]
        public string KPP { get; set; }

        [Display(Name = "��������")]
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