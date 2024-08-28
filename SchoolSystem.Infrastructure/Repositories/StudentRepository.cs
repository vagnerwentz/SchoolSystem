using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Infrastructure.Repositories;

public class StudentRepository(DatabaseContext databaseContext) : IStudentRepository
{
    public async Task AddAsync(Student student, CancellationToken cancellationToken)
    {
        await databaseContext.Student.AddAsync(student, cancellationToken);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("TESTANDO O LOG CHEGANDO NO PROJETO DE INFRA");
        return await databaseContext.Student.ToListAsync(cancellationToken);
    }
}