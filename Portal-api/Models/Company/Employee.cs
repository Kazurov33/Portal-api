using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Company
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string UserName { get; set; }
        [Required]
        public CompanyModel Company { get; set; }
        [Required]
        public Department Department { get; set; }
        public string Position { get; set; }

    }
}