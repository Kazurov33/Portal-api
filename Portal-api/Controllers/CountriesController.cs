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
  public class CountriesController : ControllerBase
  {
    private readonly ILogger<CountriesController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public CountriesController(ApplicationDbContext appDbContext, ILogger<CountriesController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Countries
    [HttpGet]
    public async Task<IActionResult> GetAllCountries()
    {
      return Ok(await _appDbContext.Countries.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountry(int id)
    {
      var country = await _appDbContext.Countries.FindAsync(id);
      if (country == null)
      {
        return NotFound();
      }
      return Ok(country);
    }
  }
}