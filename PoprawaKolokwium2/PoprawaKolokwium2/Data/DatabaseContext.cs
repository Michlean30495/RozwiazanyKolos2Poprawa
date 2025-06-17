using Microsoft.EntityFrameworkCore;
using PoprawaKolokwium2.Models;

namespace PoprawaKolokwium2.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Character> Character { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Title> Title { get; set; }
    public DbSet<Backpack> Backpack { get; set; }
    public DbSet<CharacterTitle> CharacterTitle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CharacterTitle>()
            .HasKey(ct => new { ct.CharacterId, ct.TitleId });

        modelBuilder.Entity<Backpack>()
            .HasKey(b => new { b.CharacterId, b.ItemId });

        modelBuilder.Entity<Character>().HasData(
            new Character {CharacterId = 1, FirstName = "Frank", LastName = "Castle", CurrentWeight = 1, MaxWeight = 100}
            );
        modelBuilder.Entity<Title>().HasData(
            new Title {TitleId = 1, Name = "Punisher"}
            );
        modelBuilder.Entity<Item>().HasData(
            new Item {ItemId = 1, Name = "shotgun", Weight = 4}
            );
        modelBuilder.Entity<Backpack>().HasData(
            new Backpack {CharacterId = 1, ItemId = 1, Amount = 2}
            );
        modelBuilder.Entity<CharacterTitle>().HasData(
            new CharacterTitle {CharacterId = 1, TitleId = 1, AcquiredAt = DateTime.Now});
    }
}