using System.Reflection;
using AppTurismo.Data.Configurations;
using AppTurismo.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTurismo.Data;

public class AppTurismoContext(DbContextOptions<AppTurismoContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<VacationPackage> VacationPackages { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Destination> Destinations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite(@"Data Source=AppTurismo.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    // exclusão lógica automática
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Deleted)
            {
                var isDeletedProperty = entry.Entity.GetType().GetProperty("IsDeleted");
                var deletedAtProperty = entry.Entity.GetType().GetProperty("DeletedAt");

                if (isDeletedProperty != null && deletedAtProperty != null)
                {
                    entry.State = EntityState.Modified;
                    entry.Property("IsDeleted").CurrentValue = true;
                    entry.Property("DeletedAt").CurrentValue = DateTime.UtcNow;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
