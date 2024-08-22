using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Interfaces.Repositories;

namespace SchoolSystem.Infrastructure.Repositories;

public class EnrollmentRepository(DatabaseContext databaseContext) : IEnrollmentRepository
{
    public async Task UpdateFinalGrandeAsync(string studentId, string subjectId, decimal average)
    {
        var enrollment = await databaseContext.Enrollment
            .FirstOrDefaultAsync(e => e.StudentId.ToString() == studentId && e.SubjectId.ToString() == subjectId);

        enrollment.FinalGrade = average;
        await databaseContext.SaveChangesAsync();
    }
}