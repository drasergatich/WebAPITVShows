using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPITVShows.Models.Entities;

namespace WebAPITVShows.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TVShow> TVShows { get; set; }
    }
}
