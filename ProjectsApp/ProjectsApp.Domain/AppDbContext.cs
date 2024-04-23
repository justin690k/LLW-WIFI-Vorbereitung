using Microsoft.EntityFrameworkCore;
using ProjectsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsApp.Domain;

public class AppDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public static AppDbContext Get
        => _context
            ??= new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=C:\\Users\\User\\Desktop\\LLW-WIFI-Vorbereitung\\ProjectsApp\\projectTimes.db")
                    .Options);
        private static AppDbContext? _context;
    public AppDbContext(DbContextOptions options) 
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\User\\Desktop\\LLW-WIFI-Vorbereitung\\ProjectsApp\\projectTimes.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(e =>
        {
            e.HasKey(e => e.Id);

            e.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            e.Property(e => e.Description)
                .HasMaxLength(255);

            e.Property(e => e.Budget)
                .IsRequired();

            e.HasOne(e => e.Leader)
                .WithMany(e => e.Projects)
                .HasForeignKey("leader_id")
                .IsRequired();
        });

        modelBuilder.Entity<Employee>(e =>
        {
            e.HasKey(e => e.Id);

            e.Property(e => e.Firstname)
                .HasMaxLength(255)
                .IsRequired();

            e.Property(e => e.Lastname)
                .HasMaxLength(255);

            e.HasOne(e => e.Department)
                .WithMany(e => e.Employees)
                .HasForeignKey("department_id")
                .IsRequired();
        });
    }
}
