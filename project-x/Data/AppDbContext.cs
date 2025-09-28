using Microsoft.EntityFrameworkCore;
using project_x.Models;
using System.Security.Cryptography.X509Certificates;

namespace project_x.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        // Define your DbSets here. For example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}