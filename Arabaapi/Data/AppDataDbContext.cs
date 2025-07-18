using Arabaapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Arabaapi.Data
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext>options):base(options)
        {
        }
        public DbSet<Markalar> Markalars { get; set; }
        public DbSet<LoginModel>LoginModels { get; set; }

    }
}
