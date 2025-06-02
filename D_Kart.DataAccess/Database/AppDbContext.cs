using D_Kart.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace D_Kart.DataAccess.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
