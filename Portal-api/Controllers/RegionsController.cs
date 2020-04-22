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
  public class RegionsController : ControllerBase
  {
    private readonly ILogger<RegionsController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public RegionsController(ApplicationDbContext appDbContext, ILogger<RegionsController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Countries
    [HttpGet]
    public async Task<IActionResult> GetAllRegions()
    {
      return Ok(await _appDbContext.Regions.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountryRegions(int id)
    {
      var regions = await _appDbContext.Regions.Where(r=>r.Country.Id == id).ToListAsync();
      if (regions == null)
      {
        return NotFound();
      }
      return Ok(regions);
    }
  }
}