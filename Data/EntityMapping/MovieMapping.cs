using Basic.Ef.Core.Data.ValueConverters;
using Basic.Ef.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basic.Ef.Core.Data.EntityMapping;

public class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasMaxLength(100);
        builder.Property(m => m.ReleaseDate)
            .HasColumnType("varchar(8)")
            .HasConversion(new DateTimeToVarChar8());
        builder.Property(m => m.Synopsis).HasMaxLength(500);
        // If we do not want a separate entity for Person we can use as ComplexProperty instead
        // builder.ComplexProperty(m => m.Director);

        // If we want to map the foreign key to a non conventional name
        // builder.HasOne(movie => movie.Genre)
        // .WithMany(genre => genre.Movies)
        // .HasPrincipalKey(genre => genre.Id)
        // .HasForeignKey(movie => movie.MainGenreId)
        // .OnDelete(DeleteBehavior.Cascade);

        // Anonymous object because GenreId and DirectorEmail are not part of the Movie entity but is the relation in the Db
        builder.HasData(new
        {
            Id = 1,
            Title = "The Matrix",
            ReleaseDate = new DateTime(1999, 3, 31),
            Synopsis = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
            GenreId = 1,
            DirectorEmail = "JohnDoe@Studios.com"
        });
    }
}