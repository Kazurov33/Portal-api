// Район
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
    }
}