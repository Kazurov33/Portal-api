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
  public class DistrictsController : ControllerBase
  {
    private readonly ILogger<DistrictsController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public DistrictsController(ApplicationDbContext appDbContext, ILogger<DistrictsController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Districts
    [HttpGet]
    public async Task<IActionResult> GetAllDistricts()
    {
      return Ok(await _appDbContext.Districts.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegionDistricts(int id)
    {
      var districts = await _appDbContext.Districts.Where(r=>r.Region.Id == id).ToListAsync();
      if (districts == null)
      {
        return NotFound();
      }
      return Ok(districts);
    }
  }
}