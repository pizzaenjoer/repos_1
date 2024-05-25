using Microsoft.EntityFrameworkCore;
using System;
using Project.Model;
using Project.Model.AuthApp;


namespace Project.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car>? Cars { get; set; }

        public DbSet<AuthUser>? AuthUsers { get; set; }

        public DbSet<Mileage>? Mileage { get; set; }

        public DbSet<Mileages>? Mileages { get; set; }
    }
}
