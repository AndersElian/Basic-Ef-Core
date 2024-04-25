using System.Reflection;
using Basic.Ef.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Basic.Ef.Core.Data
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Person> Persons => Set<Person>();

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Easy Way with one DbContext engine
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Hard Way with manual configuration but good for multiple DbContext and engines
            // modelBuilder.ApplyConfiguration(new GenreMapping());
            // modelBuilder.ApplyConfiguration(new MovieMapping());
            // modelBuilder.ApplyConfiguration(new PersonMapping());
        }
    }
}
