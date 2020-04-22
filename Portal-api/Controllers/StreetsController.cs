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
  public class StreetsController : ControllerBase
  {
    private readonly ILogger<StreetsController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public StreetsController(ApplicationDbContext appDbContext, ILogger<StreetsController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
    // GET: /Countries
    [HttpGet]
    public async Task<IActionResult> GetAllStreets()
    {
      return Ok(await _appDbContext.Streets.ToListAsync());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCityStreets(int id)
    {
      var streets = await _appDbContext.Streets.Where(r=>r.City.Id == id).ToListAsync();
      if (streets == null)
      {
        return NotFound();
      }
      return Ok(streets);
    }
  }
}