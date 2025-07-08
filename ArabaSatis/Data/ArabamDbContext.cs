using ArabaSatis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ArabaSatis.Data
{
    public class ArabamDbContext :IdentityDbContext<AppUser,AppRole,int>
    {
        public ArabamDbContext(DbContextOptions<ArabamDbContext>options):base(options)
        {
        }
        public DbSet<Markalar>?Markalars { get; set; }
        public DbSet<Yakit>? Yakits { get; set; }
        public DbSet<SeriModel>? SeriModels { get; set;}
        public DbSet<ArabaResim>? ArabaResim { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }

        public DbSet<Ilanlar> Ilanlars { get; set;}
        
    }
}
