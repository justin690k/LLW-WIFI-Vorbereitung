using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Models;

namespace MoviesApp.Domain;

public class AppDbContext : DbContext
{
    public static AppDbContext Get
    {
        get => _context ??= new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=C:\\Users\\User\\Desktop\\LLW-WIFI-Vorbereitung\\MoviesApp\\movies.db")
            .Options);
    }
    private static AppDbContext? _context;

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genre { get; set; }

    protected AppDbContext(DbContextOptions options) 
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\User\\Desktop\\LLW-WIFI-Vorbereitung\\MoviesApp\\movies.db");
}
