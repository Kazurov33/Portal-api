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
  public class CategoriesController : ControllerBase
  {
    private readonly ILogger<CategoriesController> _logger;
    private readonly ApplicationDbContext _appDbContext;
    public CategoriesController(ApplicationDbContext appDbContext, ILogger<CategoriesController> logger)
    {
      _logger = logger;
      _appDbContext = appDbContext;
    }
        // GET: /Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _appDbContext.Categories.Include(x => x.LowCategories).ThenInclude(p => p.LowCategories).Include(x=>x.Employees).ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _appDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        // POST: Categories
        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();

            return Ok(category);
        }
        // DELETE: Roles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _appDbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();

            return Ok(category);
        }
    }
}