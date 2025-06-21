using AppTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTurismo.Data.Configurations;

public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.ToTable("Destinations");
        builder.HasKey(x => x.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name");

        builder.Property(d => d.Country)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("Country");

        builder.HasIndex(d => new { d.Name, d.Country })
            .IsUnique()
            .HasDatabaseName("IX_Destinations_Name_Country");

        builder.HasData(
            new { Id = 1, Name = "Paris", Country = "França" },
            new { Id = 2, Name = "Roma", Country = "Itália" },
            new { Id = 3, Name = "Londres", Country = "Reino Unido" },
            new { Id = 4, Name = "Barcelona", Country = "Espanha" },
            new { Id = 5, Name = "Nova York", Country = "Estados Unidos" },
            new { Id = 6, Name = "Los Angeles", Country = "Estados Unidos" },
            new { Id = 7, Name = "Tóquio", Country = "Japão" },
            new { Id = 8, Name = "Sydney", Country = "Austrália" },
            new { Id = 9, Name = "Rio de Janeiro", Country = "Brasil" },
            new { Id = 10, Name = "Buenos Aires", Country = "Argentina" },
            new { Id = 11, Name = "Bangkok", Country = "Tailândia" },
            new { Id = 12, Name = "Dubai", Country = "Emirados Árabes" }
        );
    }
}
