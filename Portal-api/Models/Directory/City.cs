// Городское поселение / Город / Поселок
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
  public class City
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public UrbanDistrict UrbanDistrict { get; set; }
    public District District { get; set; }
  }
}