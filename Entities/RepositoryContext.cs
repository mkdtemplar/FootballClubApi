using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Club> Clubs { get; set; }
    public DbSet<Player> Players { get; set; }
}