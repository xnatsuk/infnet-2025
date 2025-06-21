using AppTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTurismo.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Name");

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("Email");

        builder.HasIndex(c => c.Email)
            .IsUnique()
            .HasDatabaseName("IX_Clients_Email");

        builder.HasMany(c => c.Reservations)
            .WithOne(r => r.Client)
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Client_Reservations");

        builder.HasData(
            new { Id = 1, Name = "João Silva", Email = "joao.silva@email.com" },
            new { Id = 2, Name = "Maria Oliveira", Email = "maria.oliveira@email.com" },
            new { Id = 3, Name = "Carlos Souza", Email = "carlos.souza@email.com" },
            new { Id = 4, Name = "Ana Paula", Email = "ana.paula@email.com" },
            new { Id = 5, Name = "Lucas Pereira", Email = "lucas.pereira@email.com" },
            new { Id = 6, Name = "Fernanda Costa", Email = "fernanda.costa@email.com" },
            new { Id = 7, Name = "Roberto Santos", Email = "roberto.santos@email.com" },
            new { Id = 8, Name = "Juliana Lima", Email = "juliana.lima@email.com" },
            new { Id = 9, Name = "Pedro Alves", Email = "pedro.alves@email.com" },
            new { Id = 10, Name = "Carla Mendes", Email = "carla.mendes@email.com" }
        );
    }
}
