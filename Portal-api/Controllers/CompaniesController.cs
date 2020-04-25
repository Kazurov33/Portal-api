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
  public class CompaniesController : ControllerBase
  {
    private readonly ILogger<CitiesController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public CompaniesController (ApplicationDbContext appDbContext, ILogger<CitiesController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Companies
    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
      return Ok(await _appDbContext.Companies.Include(p=>p.Departments).Include(d=>d.Employees).ToListAsync());
    }
        // GET: api/Companies/5
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _appDbContext.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // POST: api/Companies
        [HttpPost]
        public IActionResult PostCompany(CompanyModel company)
        {

            _appDbContext.Companies.Add(company);
            _appDbContext.SaveChanges();

            return Ok(company);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public IActionResult PutCompany(int id, CompanyModel company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _appDbContext.Entry(company).State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return Ok(company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _appDbContext.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            _appDbContext.Companies.Remove(company);
            _appDbContext.SaveChanges();

            return Ok(company);
        }
    }
}