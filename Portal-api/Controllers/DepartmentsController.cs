using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models.Company;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DepartmentsController : ControllerBase
  {
    private readonly ILogger<DistrictsController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public DepartmentsController(ApplicationDbContext appDbContext, ILogger<DistrictsController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Departments
    [HttpGet]
    public async Task<IActionResult> GetAllDepartments()
    {
      return Ok(await _appDbContext.Departments.Include(p=>p.Employees).ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyDeparments(int id)
    {
      var departments = await _appDbContext.Departments.Where(r=>r.Company.Id == id).Include(p=>p.Employees).ToListAsync();
      if (departments == null)
      {
        return NotFound();
      }
      return Ok(departments);
    }
    // POST: api/Department
    [HttpPost]
    public IActionResult PostDepartment(Department department)
    {

        _appDbContext.Departments.Add(department);
        _appDbContext.SaveChanges();

        return NoContent();
    }
    }
}