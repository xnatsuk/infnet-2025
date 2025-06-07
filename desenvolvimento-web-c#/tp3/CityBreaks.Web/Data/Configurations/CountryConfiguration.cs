using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(country => country.CountryName)
            .HasMaxLength(100)
            .HasColumnName("CountryName");

        builder.HasData(
            new Country { Id = 1, CountryCode = "BR", CountryName = "Brasil" },
            new Country { Id = 2, CountryCode = "JP", CountryName = "Japan" },
            new Country { Id = 3, CountryCode = "CN", CountryName = "China" },
            new Country { Id = 4, CountryCode = "RU", CountryName = "Russia" }
        );
    }
}
