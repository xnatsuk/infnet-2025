using AppTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTurismo.Data.Configurations;

public class VacationPackageConfiguration : IEntityTypeConfiguration<VacationPackage>
{
    public void Configure(EntityTypeBuilder<VacationPackage> builder)
    {
        builder.ToTable("VacationPackages");
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(v => v.Title)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("Title");

        builder.Property(v => v.StartDate)
            .IsRequired()
            .HasColumnName("StartDate");

        builder.Property(v => v.Price)
            .IsRequired()
            .HasColumnName("Price")
            .HasColumnType("DECIMAL(10,2)");

        builder.Property(v => v.MaxCapacity)
            .IsRequired()
            .HasColumnName("MaxCapacity");

        builder.HasIndex(v => v.StartDate)
            .HasDatabaseName("IX_VacationPackages_StartDate");

        builder.HasIndex(v => v.Title)
            .HasDatabaseName("IX_VacationPackages_Title");

        builder.HasIndex(v => v.Price)
            .HasDatabaseName("IX_VacationPackages_Price");

        // Relacionamentos
        builder.HasMany(v => v.Reservations)
            .WithOne(r => r.VacationPackage)
            .HasForeignKey(r => r.VacationPackageId)
            .OnDelete(DeleteBehavior.Restrict);

        //  many-to-many com Destinations
        builder.HasMany(v => v.Destinations)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "VacationPackageDestinations",
                j => j.HasOne<Destination>().WithMany().HasForeignKey("DestinationId"),
                j => j.HasOne<VacationPackage>().WithMany().HasForeignKey("VacationPackageId"),
                j =>
                {
                    j.HasKey("VacationPackageId", "DestinationId");
                    j.ToTable("VacationPackageDestinations");
                    j.HasData(
                        new { VacationPackageId = 1, DestinationId = 1 },
                        new { VacationPackageId = 1, DestinationId = 2 },
                        new { VacationPackageId = 1, DestinationId = 3 },
                        new { VacationPackageId = 1, DestinationId = 4 },
                        new { VacationPackageId = 2, DestinationId = 5 },
                        new { VacationPackageId = 2, DestinationId = 6 },
                        new { VacationPackageId = 3, DestinationId = 7 },
                        new { VacationPackageId = 3, DestinationId = 11 },
                        new { VacationPackageId = 4, DestinationId = 9 },
                        new { VacationPackageId = 5, DestinationId = 8 },
                        new { VacationPackageId = 6, DestinationId = 12 }
                    );
                });

        builder.HasData(
            new
            {
                Id = 1,
                Title = "Europa Clássica",
                StartDate = new DateTime(2025, 7, 15),
                Price = 3500.00m,
                MaxCapacity = 20
            },
            new
            {
                Id = 2,
                Title = "América do Norte",
                StartDate = new DateTime(2025, 8, 10),
                Price = 4200.00m,
                MaxCapacity = 15
            },
            new
            {
                Id = 3,
                Title = "Ásia Moderna",
                StartDate = new DateTime(2025, 9, 5),
                Price = 5000.00m,
                MaxCapacity = 10
            },
            new
            {
                Id = 4,
                Title = "Brasil Maravilhoso",
                StartDate = new DateTime(2025, 7, 20),
                Price = 1800.00m,
                MaxCapacity = 25
            },
            new
            {
                Id = 5,
                Title = "Oceania Aventura",
                StartDate = new DateTime(2025, 10, 12),
                Price = 6500.00m,
                MaxCapacity = 12
            },
            new
            {
                Id = 6,
                Title = "Oriente Médio Luxo",
                StartDate = new DateTime(2025, 11, 8),
                Price = 4800.00m,
                MaxCapacity = 8
            }
        );
    }
}
