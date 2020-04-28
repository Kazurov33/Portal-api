using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models.Company
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public int? CompanyId { get; set; }
        [JsonIgnore]
        public CompanyModel Company { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public Role()
        {
            Employees = new List<Employee>();
        }
    }
}