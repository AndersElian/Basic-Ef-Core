using Basic.EF.Core.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Basic.EF.Core.API.Data
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();

        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("""
                Host=localhost;
                Database=moviesdb;
                Username=postgres;
                Password=MySaPassword
                """);
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
