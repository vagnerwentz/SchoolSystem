using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Infrastructure.Repositories;

public class EnrollmentRepository(DatabaseContext databaseContext) : IEnrollmentRepository
{
    public async Task UpdateFinalGrandeAsync(string studentId, string subjectId, decimal average)
    {
        var enrollment = await databaseContext.Enrollment
            .FirstOrDefaultAsync(e => e.StudentId.ToString() == studentId && e.SubjectId.ToString() == subjectId);

        enrollment!.FinalGrade = average;
        await databaseContext.SaveChangesAsync();
    }

    public async Task AddEnrollmentStudentInSubjectAsync(Enrollment enrollment, CancellationToken cancellationToken)
    {
        await databaseContext.Enrollment.AddAsync(enrollment, cancellationToken);
        await databaseContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Enrollment>> GetEnrollmentStudentAsync(int studentId)
    {
        return await databaseContext.Enrollment.Where(e => e.StudentId == studentId)
            .Include(e => e.Subject)
            .ToListAsync();
    }
}