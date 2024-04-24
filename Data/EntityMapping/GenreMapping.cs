﻿using Basic.Ef.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basic.Ef.Core.Data.EntityMapping;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Name);

        // builder.HasMany(g => g.Movies)
        //     .WithOne(m => m.Genre)
        //     .HasForeignKey(m => m.Genre.Id)
        //     .OnDelete(DeleteBehavior.Cascade);
    }
}