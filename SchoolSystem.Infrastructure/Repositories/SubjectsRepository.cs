using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Infrastructure.Repositories;

public class SubjectsRepository(DatabaseContext databaseContext) : ISubjectsRepository
{
    public async Task AddSubjectAsync(Subject subject)
    {
        await databaseContext.AddAsync(subject);
        await databaseContext.SaveChangesAsync();
    }

    public async Task<List<Subject>> GetAllSubjectsAsync(CancellationToken cancellationToken)
    {
        return await databaseContext.Subject.ToListAsync(cancellationToken);
    }

    public async Task<List<Subject>> GetSubjectsByProfessorIdAsync(int professorId)
    {
        return await databaseContext.Subject.Where(s => s.Professor.Id == professorId)
            .Include(p => p.Professor)
            .ToListAsync();
    }
}