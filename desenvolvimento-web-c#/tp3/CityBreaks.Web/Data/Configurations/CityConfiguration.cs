using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(city => city.Name)
            .HasColumnName("Name");

        builder.HasData(
            new City { Id = 1, Name = "Brasília", CountryId = 1 },
            new City { Id = 2, Name = "Rio de Janeiro", CountryId = 1 },
            new City { Id = 3, Name = "Tokyo", CountryId = 2 },
            new City { Id = 4, Name = "Osaka", CountryId = 2 },
            new City { Id = 5, Name = "Shenzhen", CountryId = 3 },
            new City { Id = 6, Name = "Macau", CountryId = 3 },
            new City { Id = 7, Name = "Moscow", CountryId = 4 },
            new City { Id = 8, Name = "Saint Petersburg", CountryId = 4 }
        );
    }
}
