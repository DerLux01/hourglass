using hourglass.Models;
using Microsoft.EntityFrameworkCore;

namespace hourglass.Data;

public class AppDbContext : DbContext
{
    public DbSet<MediaItem> MediaItem { get; set; }
    public DbSet<Genre> Genre { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=hourglass.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaGenre>()
            .HasKey(mg => new {mg.MediaItemId, mg.GenreId});
    }
}