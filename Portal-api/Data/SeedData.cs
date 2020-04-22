using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();
            //await context.Database.EnsureCreatedAsync();

        }
    }
}