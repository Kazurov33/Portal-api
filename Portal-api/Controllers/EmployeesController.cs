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
  public class EmployeesController : ControllerBase
  {
    private readonly ILogger<DistrictsController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public EmployeesController(ApplicationDbContext appDbContext, ILogger<DistrictsController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Employees
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
      return Ok(await _appDbContext.Employees.ToListAsync());
    }
        [HttpGet("{id}")]
        public IActionResult FindEmployee(int id)
        {
            var employee = _appDbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    [HttpGet("Department/{id}")]
    public async Task<IActionResult> GetDepartmentEmployees(int id)
    {
      var employees = await _appDbContext.Employees.Where(r=>r.Department.Id == id).ToListAsync();
      if (employees == null)
      {
        return NotFound();
      }
      return Ok(employees);
    }
    [HttpGet("{id}/free")]
    public async Task<IActionResult> GetFreeEmployeeOfCompany(int id)
    {
        var employees = await _appDbContext.Employees.Where(r => r.Company.Id == id).Where(r => r.Department.Id == null).ToListAsync();
        if (employees == null)
        {
            return NotFound();
        }
        return Ok(employees);
    }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _appDbContext.Entry(employee).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return Ok(employee);
        }
    }
}