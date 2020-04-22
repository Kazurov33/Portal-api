// Улица
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
    public class Street
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public City City {get; set; }
    }
}