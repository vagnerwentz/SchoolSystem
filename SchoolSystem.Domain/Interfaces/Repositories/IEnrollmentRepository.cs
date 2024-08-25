using SchoolSystem.Domain.Models;

namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface IEnrollmentRepository
{
    Task UpdateFinalGrandeAsync(string studentId, string subjectId, decimal average);
    Task AddEnrollmentStudentInSubjectAsync(Enrollment enrollment, CancellationToken cancellationToken);
}