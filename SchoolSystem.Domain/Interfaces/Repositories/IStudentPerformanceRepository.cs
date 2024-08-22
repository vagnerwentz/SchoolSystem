using SchoolSystem.Domain.Models.NonRelationalDatabase;

namespace SchoolSystem.Domain.Interfaces.Repositories;

public interface IStudentPerformanceRepository
{
    Task<StudentPerformance?> GetByStudentIdAsync(string studentId);
    Task AddAsync(StudentPerformance studentPerformance);
    Task UpdateAsync(StudentPerformance studentPerformance);
}