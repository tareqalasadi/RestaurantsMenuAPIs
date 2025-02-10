using Microsoft.EntityFrameworkCore;
using RestaurantsMenu.Models;
using Serilog;

namespace RestaurantsMenu.General
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your tables
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Login { get; set; }
    }
}
