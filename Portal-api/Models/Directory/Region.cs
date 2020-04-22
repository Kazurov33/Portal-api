//  Область
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
  public class Region
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }

  }
}