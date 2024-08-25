using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Infrastructure.Repositories;

public class SubjectsRepository(DatabaseContext databaseContext) : ISubjectsRepository
{
    public async Task<List<Subject>> GetAllSubjectsAsync(CancellationToken cancellationToken)
    {
        return await databaseContext.Subject.ToListAsync(cancellationToken);
    }
}