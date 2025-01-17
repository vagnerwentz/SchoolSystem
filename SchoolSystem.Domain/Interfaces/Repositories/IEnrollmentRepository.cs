using SchoolSystem.Domain.Models;

namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface IEnrollmentRepository
{
    Task UpdateFinalGrandeAsync(string studentId, string subjectId, decimal average);
    Task AddEnrollmentStudentInSubjectAsync(Enrollment enrollment, CancellationToken cancellationToken);
    Task<List<Enrollment>> GetEnrollmentStudentAsync(int studentId);

    public Task<List<Enrollment>> GetEnrollmentsBySubjectIdsAsync(List<int> subjectIds);

}