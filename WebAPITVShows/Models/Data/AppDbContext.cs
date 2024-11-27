using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPITVShows.Models.Entities;

namespace WebAPITVShows.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TVShow> TVShows { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Insertar datos dummy para la tabla TVShows
            modelBuilder.Entity<TVShow>().HasData(
                new TVShow { Id = 1, Name = "Drake & Josh", Favorite = true },
                new TVShow { Id = 2, Name = "Dora la exploradora", Favorite = false },
                new TVShow { Id = 3, Name = "Los Jóvenes titanes", Favorite = true },
                new TVShow { Id = 4, Name = "Dr House", Favorite = true }
            );
        }
    }
}
