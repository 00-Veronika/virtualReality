using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using virtualReality.Entities;

namespace EntityFrameworkSample
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            Users = this.Set<User>();
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamesInGenre> GamesInGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=virtualRealityDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword("nikipass");

            var user = new User
            {
                Id = 1,
                UserName = "nikiv",
                PasswordHash = passwordHash,
                Email = "test@email.com",
                FirstName = "Nikola",
                LastName = "Valchanov",
                Phone = "070018100",
                Role = "admin"
            };

            modelBuilder.Entity<User>().HasData(user);

            var listOfGenres = new List<Genre>
            {
                new Genre() { Id = 1, Name = "Horror" },
                new Genre() { Id = 2, Name = "Action" }
            };

            modelBuilder.Entity<Genre>().HasData(listOfGenres);

            var listOfGames = new List<Game>
            {
                new Game()
                {
                    Id = 1,
                    Name = "Horror Game #1",
                    Manufacturer = "Chris Games™",
                    Price = 10.25M,
                    ReleaseDate = DateTime.Now,
                    Url = "/css/assets/images/current-01.jpg"
                },
                new Game()
                {
                    Id = 2,
                    Name = "Action Game #1",
                    Manufacturer = "Chris Games™",
                    Price = 59.99M,
                    ReleaseDate = DateTime.Now,
                    Url = "/css/assets/images/current-02.jpg"
                },
                new Game()
                {
                    Id = 3,
                    Name = "Action Game #2",
                    Manufacturer = "Chris Games™",
                    Price = 29.99M,
                    ReleaseDate = DateTime.Now,
                    Url = "/css/assets/images/current-03.jpg"
                },
                new Game()
                {
                    Id = 4,
                    Name = "Action Game #2",
                    Manufacturer = "Chris Games™",
                    Price = 19.99M,
                    ReleaseDate = DateTime.Now,
                    Url = "/css/assets/images/current-04.jpg"
                }
            };

            modelBuilder.Entity<Game>().HasData(listOfGames);

            var listOfGamesInGenres = new List<GamesInGenre>
            {
                new GamesInGenre {  Id = 1, GameId = 1, GenreId = 1 },
                new GamesInGenre {  Id = 2, GameId = 2, GenreId = 2 },
                new GamesInGenre {  Id = 3, GameId = 3, GenreId = 1 },
                new GamesInGenre {  Id = 4, GameId = 4, GenreId = 2 }
            };

            modelBuilder.Entity<GamesInGenre>().HasData(listOfGamesInGenres);
        }
    }
}
