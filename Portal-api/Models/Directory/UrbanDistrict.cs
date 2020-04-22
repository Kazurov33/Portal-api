// Городской округ
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
    public class UrbanDistrict
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public District District { get; set; }
    }
}