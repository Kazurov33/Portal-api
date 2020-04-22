using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
  public class Address
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public Country Country { get; set; }
    [Required]
    public Region Region { get; set; }
    [Required]
    public District District { get; set; }
    public UrbanDistrict UrbanDistrict { get; set; }
    [Required]
    public City City { get; set; }
    [Required]
    public Street Street { get; set; }
    [Required]
    public House House { get; set; }
    public Room Room { get; set; }
  }
}