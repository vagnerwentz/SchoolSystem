namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface IEnrollmentRepository
{
    Task UpdateFinalGrandeAsync(string studentId, string subjectId, decimal average);
}