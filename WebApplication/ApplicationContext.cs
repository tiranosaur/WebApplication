using System;
using Microsoft.EntityFrameworkCore;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite(@"Data Source=MyDatabase.db;");
            optionsBuilder.UseMySql(
                "server=127.0.0.1;port=3306;user=png;password=png;database=png;",
                new MySqlServerVersion(new Version(5, 7))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Random rnd = new Random();
            modelBuilder.Entity<User>().HasData( new User() { Id = 1, Name = "tiranosaur", Email = "tiranosaur@gmail.com", Age = 40});
            for (int i = 2; i < 100; i++)
            {
                Console.WriteLine();
                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = i,
                        Name = $"{StringHelper.Random(rnd.Next(5, 10))}",
                        Email = $"{StringHelper.Random(rnd.Next(5, 10))}@{StringHelper.Random(4)}.com"
                    }
                );
            }
        }
    }
}