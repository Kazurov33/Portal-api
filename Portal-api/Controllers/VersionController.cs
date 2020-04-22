using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class VersionController : ControllerBase
  {
    private readonly ILogger<WeatherForecastController> _logger;

    public VersionController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
      return "Version: 1.0.0";
    }
  }
}