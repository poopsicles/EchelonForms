using Microsoft.EntityFrameworkCore;

namespace Echelon.Models;

internal class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;

    public string DbPath { get; }

    public DatabaseContext()
    {
        DbPath = System.IO.Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "echelon.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(c => c.UserID);
        modelBuilder.Entity<Note>()
            .HasKey(c => c.NoteID);
    }
}

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PublicKey { get; set; } = null!;
    public byte[] ProtectedPrivateKey { get; set; } = null!;
}

public class Note
{
    public int NoteID { get; set; }
    public int UserID { get; set; }
    public byte[] EncryptedKey { get; set; } = null!;
    public byte[] EncryptedTitle { get; set; } = null!;
    public byte[] EncryptedBody { get; set; } = null!;
    public DateTime LastModified { get; set; }
}