using Habitify.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;

namespace Habitify.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : 
            base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
