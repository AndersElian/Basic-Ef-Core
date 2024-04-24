using Basic.Ef.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basic.Ef.Core.Data.EntityMapping;

public class PersonMapping : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.Email);
        
        builder.HasData(
            new Person
            {
                Email = "JohnDoe@Studios.com",
                FirstName = "John",
                LastName = "Doe"
            });
    }
}