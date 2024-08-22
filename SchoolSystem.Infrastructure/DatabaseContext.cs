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
    public DbSet<Enrollment> Enrollment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        // Configurando a chave composta para Enrollment (StudentId + SubjectId)
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.SubjectId });
    }
}