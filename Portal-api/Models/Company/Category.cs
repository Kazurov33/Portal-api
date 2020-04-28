using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models.Company
{
  public class Category
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int TimeofTaken { get; set; }
    public int TimeofExecution { get; set; }
    public int NestingLevel { get; set; }
    [JsonIgnore]
    public Category HighCategory { get; set; }
    [JsonIgnore]
    public CompanyModel Company { get; set; }

    public ICollection<Employee> Employees { get; set; }
    public ICollection<Category> LowCategories { get; set; }
    public Category()
    {
        Employees = new List<Employee>();
        LowCategories = new List<Category>();
    }
  }
}