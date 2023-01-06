using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.ViewModels;
using virtualReality.Entities;
using Microsoft.Extensions.Options;

namespace EntityFrameworkSample
{
    public class MyDbContext : DbContext
    {

        public DbSet<Users> Users { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<GameToType>GameToTypes { get; set; }
        public DbSet<Genre>Genre { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Pictures>Pictures { get; set; }

        public MyDbContext()
        {
            Users = this.Set<Users>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=virtualRealityDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users()
                {
                    Id = 1,
                    username = "nikiv",
                    password = "nikipass",
                    
                });

            //modelBuilder.Entity<Games>().HasData(
            //    new Games()
            //    {
            //        Id = 1,
            //        Name = "test",
            //        Price = 10,
            //        Genre = "testGenre",
            //        manufacturer = "epicgames",
            //        releaseDate = 2023
            //    });
        }
    }
}
