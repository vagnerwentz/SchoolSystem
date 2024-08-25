using SchoolSystem.Domain.Models;

namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    Task AddAsync(Student student, CancellationToken cancellationToken);
    Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);
}