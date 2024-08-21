using SchoolSystem.Domain.Models;

namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    Task Create(Student student, CancellationToken cancellationToken);
}