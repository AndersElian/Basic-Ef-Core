using Basic.Ef.Core.Data.ValueConverters;
using Basic.Ef.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basic.Ef.Core.Data.EntityMapping;

public class PersonMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");
        builder.HasKey(p => p.Email);
        builder.Property(p => p.FirstName);
        builder.Property(p => p.LastName).IsRequired();
        builder.Property(p => p.DateOfBirth)
            .HasColumnType("varchar(8)")
            .HasConversion(new DateTimeToVarChar8());
        //Shadow property, not seen on the entity but in the database
        builder.Property<bool>("isRetired")
            .HasDefaultValue(false)
            .IsRequired();
        
        // Query filter to only get persons that are not retired
        builder.HasQueryFilter(p => EF.Property<bool>(p, "isRetired") == false);
        
        builder.HasData(
            new Person
            {
                Email = "JohnDoe@Studios.com",
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1969, 7, 23)
            });
    }
}