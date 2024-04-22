using Microsoft.EntityFrameworkCore;
using MotocycleManagement.Domain.Models;

namespace MotocycleManagement.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<MotocycleModel> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public static AppDbContext Get
        {
            get => _instance ??= new AppDbContext();
        }
        private static AppDbContext? _instance;

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source=C:\\Users\\User\\Desktop\\LLW\\tuningparts.db");
    }
}
