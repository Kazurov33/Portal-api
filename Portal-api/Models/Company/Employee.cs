using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models.Company
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Position { get; set; }
       
        public int? RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }

        public int? CompanyId { get; set; }
        [JsonIgnore]
        public CompanyModel Company { get; set; }
        
        public int? DepartmentId { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
    }
}