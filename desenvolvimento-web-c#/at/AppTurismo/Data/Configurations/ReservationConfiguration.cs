using AppTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTurismo.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations");
        builder.HasKey(x => x.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.ClientId)
            .IsRequired();

        builder.Property(r => r.VacationPackageId)
            .IsRequired();

        builder.Property(r => r.BookingDate)
            .IsRequired()
            .HasColumnName("BookingDate")
            .HasDefaultValueSql("datetime('now')");


        builder.Property(r => r.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(r => r.DeletedAt)
            .HasColumnName("DeletedAt");

        builder.HasIndex(r => r.ClientId)
            .HasDatabaseName("IX_Reservations_ClientId");

        builder.HasIndex(r => r.VacationPackageId)
            .HasDatabaseName("IX_Reservations_VacationPackageId");

        builder.HasIndex(r => r.BookingDate)
            .HasDatabaseName("IX_Reservations_BookingDate");

        builder.HasIndex(r => r.IsDeleted)
            .HasDatabaseName("IX_Reservations_IsDeleted");

        builder.HasIndex(r => new { r.ClientId, r.VacationPackageId })
            .IsUnique();

        builder.HasOne(r => r.Client)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.VacationPackage)
            .WithMany(v => v.Reservations)
            .HasForeignKey(r => r.VacationPackageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(r => !r.IsDeleted);

        builder.HasData(
            new
            {
                Id = 1,
                ClientId = 1,
                VacationPackageId = 1,
                BookingDate = new DateTime(2025, 6, 1, 10, 30, 0),
                IsDeleted = false
            },
            new
            {
                Id = 2,
                ClientId = 2,
                VacationPackageId = 1,
                BookingDate = new DateTime(2025, 6, 2, 14, 15, 0),
                IsDeleted = false
            },
            new
            {
                Id = 3,
                ClientId = 3,
                VacationPackageId = 2,
                BookingDate = new DateTime(2025, 6, 5, 9, 45, 0),
                IsDeleted = false
            },
            new
            {
                Id = 4,
                ClientId = 4,
                VacationPackageId = 3,
                BookingDate = new DateTime(2025, 6, 10, 16, 20, 0),
                IsDeleted = false
            },
            new
            {
                Id = 5,
                ClientId = 5,
                VacationPackageId = 4,
                BookingDate = new DateTime(2025, 6, 15, 11, 10, 0),
                IsDeleted = false
            },
            new
            {
                Id = 6,
                ClientId = 6,
                VacationPackageId = 1,
                BookingDate = new DateTime(2025, 6, 18, 13, 30, 0),
                IsDeleted = false
            },
            new
            {
                Id = 7,
                ClientId = 7,
                VacationPackageId = 5,
                BookingDate = new DateTime(2025, 6, 20, 8, 50, 0),
                IsDeleted = false
            },
            new
            {
                Id = 8,
                ClientId = 8,
                VacationPackageId = 2,
                BookingDate = new DateTime(2025, 6, 22, 15, 40, 0),
                IsDeleted = true,
                DeletedAt = new DateTime(2025, 6, 23, 10, 0, 0)
            }
        );
    }
}
