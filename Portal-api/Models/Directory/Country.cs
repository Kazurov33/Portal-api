using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Directory
{
  public class Country
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}