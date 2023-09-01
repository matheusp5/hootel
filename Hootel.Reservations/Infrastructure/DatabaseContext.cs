using Hootel.Models;
using Hootel.Reservations.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Reservations.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        var entitiesWithCode = ChangeTracker.Entries()
            .Where(entry => entry.Entity is Reservation &&
                            (entry.State == EntityState.Added || entry.State == EntityState.Modified))
            .Select(entry => entry.Entity as Reservation);

        foreach (var entity in entitiesWithCode)
        {
            if (string.IsNullOrEmpty(entity.ReservationCode))
            {
                // Gera um código aleatório de 6 caracteres
                entity.ReservationCode = GenerateReservationCode.Generate();
            }
        }

        return base.SaveChanges();
    }

    public DbSet<Reservation> Reservations { get; set; }
}