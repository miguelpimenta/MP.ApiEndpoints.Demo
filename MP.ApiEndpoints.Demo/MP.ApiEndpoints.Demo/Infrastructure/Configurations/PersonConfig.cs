using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiEndpoints.Demo.Core.Domain.Entities;

namespace MP.ApiEndpoints.Demo.Infrastructure.Configurations
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        void IEntityTypeConfiguration<Person>.Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable(name: "Persons", schema: "dbo");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Version)
                .IsConcurrencyToken();

            builder
                .Property(e => e.Name)
                .IsRequired();

            builder
                .Property(e => e.BirthDate)
                .IsRequired();

            builder
                .HasData(
                    new Person
                    {
                        Id = Guid.Parse("688A4BAB-15A2-4159-BDF8-83CD551995BA"),
                        Name = "Test Person 01",
                        BirthDate = new DateTime(1980, 1, 1),
                        CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                        CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                        UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                        UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                        Version = 1
                    },
                    new Person
                    {
                        Id = Guid.Parse("AADF65A8-D14D-4F87-B25A-CC0B7741DB60"),
                        Name = "Test Person 02",
                        BirthDate = new DateTime(1985, 6, 1),
                        CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                        CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                        UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                        UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                        Version = 1
                    },
                    new Person
                    {
                        Id = Guid.Parse("8BEFCB97-6CDF-4A40-9511-9197BA715379"),
                        Name = "Test Person 03",
                        BirthDate = new DateTime(1990, 12, 1),
                        CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                        CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                        UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                        UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                        Version = 1
                    });
        }
    }
}