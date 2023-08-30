using Microsoft.EntityFrameworkCore;

namespace Hootel.Hotels.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Models.Hotel> Hotels { get; set; }
}