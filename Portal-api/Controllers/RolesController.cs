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
  public class RolesController : ControllerBase
  {
    private readonly ILogger<CountriesController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public RolesController(ApplicationDbContext appDbContext, ILogger<CountriesController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Roles
    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
      return Ok(await _appDbContext.Roles.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(int id)
    {
      var role = await _appDbContext.Roles.FindAsync(id);
      if (role == null)
      {
        return NotFound();
      }
      return Ok(role);
    }
    // POST: api/Roles
    [HttpPost]
    public IActionResult PostRole(Role role)
    {
        _appDbContext.Roles.Add(role);
        _appDbContext.SaveChanges();

        return Ok(role);
    }
        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _appDbContext.Roles.Find(id);
            if (role == null)
            {
                return NotFound();
            }

            _appDbContext.Roles.Remove(role);
            _appDbContext.SaveChanges();

            return Ok(role);
        }
    }
}