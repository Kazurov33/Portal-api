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
  public class AddressController : ControllerBase
  {
    private readonly ILogger<AddressController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public AddressController(ApplicationDbContext appDbContext, ILogger<AddressController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var addresses = await _appDbContext.Addresses
      .Include(a => a.Country)
      .Include(a => a.Region)
      .Include(a => a.District)
      .Include(a => a.UrbanDistrict)
      .Include(a => a.City)
      .Include(a => a.Street)
      .Include(a => a.House)
      .Include(a => a.Room)
      .Select(address => new
      {
        id = address.Id,
        countryName = address.Country.Name,
        cityName = address.City.Name,
        regionName = address.Region.Name,
        districtName = address.District.Name,
        urbanDestrictName = address.District == null ? null : address.UrbanDistrict.Name,
        streetName = address.Street.Name,
        houseName = address.House.Name,
        roomName = address.Room == null ? null : address.Room.Name
      })
      .ToListAsync();
      return Ok(addresses);
    }
  }
}