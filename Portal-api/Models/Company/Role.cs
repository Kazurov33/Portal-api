using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models.Company
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int? CompanyId { get; set; }
        [JsonIgnore]
        public CompanyModel Company { get; set; }
    }
}