using ArabaSatis.Models;
using Microsoft.EntityFrameworkCore;

namespace ArabaSatis.Data
{
    public class ArabamDbContext : DbContext
    {
        public ArabamDbContext(DbContextOptions<ArabamDbContext>options):base(options)
        {
        }
        public DbSet<Markalar>?Markalars { get; set; }
        public DbSet<Yakit>? Yakits { get; set; }
    }
}
