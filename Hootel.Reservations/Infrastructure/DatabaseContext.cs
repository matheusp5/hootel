using Hootel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Reservations.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Reservation> Reservations { get; set; }
}