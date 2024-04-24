using Basic.Ef.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basic.Ef.Core.Data.EntityMapping;

public class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasMaxLength(100).IsRequired();
        builder.Property(m => m.ReleaseDate).IsRequired();
        // builder.ComplexProperty(m => m.Director);

        // builder.HasOne(m => m.Genre)
        // .WithMany(g => g.Movies)
        // .HasPrincipalKey(g => g.Id)
        // .HasForeignKey(m => m.MainGenreId)
        // .OnDelete(DeleteBehavior.Cascade);
    }
}