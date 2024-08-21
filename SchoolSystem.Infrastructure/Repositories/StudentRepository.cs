using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Infrastructure.Repositories;

public class StudentRepository(DatabaseContext databaseContext) : IStudentRepository
{
    public async Task Create(Student student, CancellationToken cancellationToken)
    {
        await databaseContext.Student.AddAsync(student, cancellationToken);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }
}