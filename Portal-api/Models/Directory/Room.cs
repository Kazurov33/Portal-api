// Квартира
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Directory
{
  public class Room
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public House House { get; set; }
  }
}