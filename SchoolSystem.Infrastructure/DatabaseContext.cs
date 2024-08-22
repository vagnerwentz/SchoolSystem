using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    public DbSet<Student> Student { get; set; }
    public DbSet<Professor> Professor { get; set; }
    public DbSet<Subject> Subject { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}