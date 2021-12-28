using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace UnitTests
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("png");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}