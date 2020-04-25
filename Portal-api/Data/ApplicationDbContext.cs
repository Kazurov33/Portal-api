using Microsoft.EntityFrameworkCore;
using Api.Models.Directory;
using Api.Models.Company;

namespace Api.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {

    }
    public DbSet<Country> Countries { get; set;}
    public DbSet<Region> Regions { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<UrbanDistrict> UrbanDistricts { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<House> Houses { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Address> Addresses { get; set;}

    public DbSet<CompanyModel> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Role> Roles { get; set; }

  }
}