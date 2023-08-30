using Hootel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hootel.Rooms.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; }
}