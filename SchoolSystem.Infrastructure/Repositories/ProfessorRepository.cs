using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Infrastructure.Repositories;

public class ProfessorRepository(DatabaseContext databaseContext) : IProfessorRepository
{
    public async Task Create(Professor professor, CancellationToken cancellationToken)
    {
        await databaseContext.Professor.AddAsync(professor, cancellationToken);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Professor>> GetAllProfessorsAsync(CancellationToken cancellationToken)
    {
        return await databaseContext.Professor.ToListAsync(cancellationToken);
    }
}