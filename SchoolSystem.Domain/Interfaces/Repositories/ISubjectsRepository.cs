using SchoolSystem.Domain.Models;

namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface ISubjectsRepository
{
    Task<List<Subject>> GetAllSubjectsAsync(CancellationToken cancellationToken);
}