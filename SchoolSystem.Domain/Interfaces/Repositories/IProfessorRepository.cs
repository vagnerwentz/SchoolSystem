using SchoolSystem.Domain.Models;

namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface IProfessorRepository
{
    Task Create(Professor professor, CancellationToken cancellationToken);
}