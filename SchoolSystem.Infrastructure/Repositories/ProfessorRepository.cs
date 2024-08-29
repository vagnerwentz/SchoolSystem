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

    public async Task<Professor> GetProfessorProfileAsync(int id)
    {
        return await databaseContext.Professor
            .Include(p => p.Subjects)
            .ThenInclude(s => s.Enrollments)
            .ThenInclude(e => e.Student)
            .FirstOrDefaultAsync(p => p.Id == id);
        return await databaseContext.Professor.FindAsync(id);
    }
}