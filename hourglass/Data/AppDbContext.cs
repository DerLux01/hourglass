using hourglass.Models;
using hourglass.Models.InfoModelBases;
using hourglass.Models.InfoModels;
using hourglass.Models.ItemModels;
using Microsoft.EntityFrameworkCore;

namespace hourglass.Data;

public class AppDbContext : DbContext
{
    public DbSet<MediaItem> MediaItem { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Tag> Tag { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=hourglass.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaGenre>()
            .HasKey(mg => new {mg.MediaItemId, mg.GenreId});
        
        modelBuilder.Entity<MediaTag>()
            .HasKey(mt => new {mt.MediaItemId, mt.TagId});
            
        modelBuilder.Entity<MediaItem>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Book>("Book")
            .HasValue<Video>("Video");
    }
}