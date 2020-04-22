// Номер дома
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
  public class House
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public Street Street { get; set; }
  }
}