using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .HasColumnName("Name");

        builder.HasData(
            new Property { Id = 1, Name = "Royal Tulip", PricePerNight = 140.00m, CityId = 1 },
            new Property { Id = 2, Name = "Hilton Rio de Janeiro Copacabana", PricePerNight = 250.00m, CityId = 2 },
            new Property { Id = 3, Name = "Aman Tokyo", PricePerNight = 1720.00m, CityId = 3 },
            new Property { Id = 4, Name = "Imperial Hotel Ōsaka", PricePerNight = 200.00m, CityId = 4 },
            new Property { Id = 5, Name = "Futian Shangri-La", PricePerNight = 180.00m, CityId = 5 },
            new Property { Id = 6, Name = "Artyzen Grand Lapa", PricePerNight = 180.00m, CityId = 6 },
            new Property { Id = 7, Name = "Hilton Moscow Leningradskaya", PricePerNight = 160.00m, CityId = 7 },
            new Property { Id = 8, Name = "Nevsky Royal Hotel", PricePerNight = 150.00m, CityId = 8 }
        );
    }
}
