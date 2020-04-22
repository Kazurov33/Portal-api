using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Api.Data;
namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CitiesController : ControllerBase
  {
    private readonly ILogger<CitiesController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public CitiesController(ApplicationDbContext appDbContext, ILogger<CitiesController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Countries
    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
      return Ok(await _appDbContext.Cities.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDistrictCities(int id)
    {
      var cities = await _appDbContext.Cities.Where(r=>r.District.Id == id).ToListAsync();
      if (cities == null)
      {
        return NotFound();
      }
      return Ok(cities);
    }
  }
}