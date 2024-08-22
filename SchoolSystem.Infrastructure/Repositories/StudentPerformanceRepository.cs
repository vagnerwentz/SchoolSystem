using MongoDB.Driver;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models.NonRelationalDatabase;

namespace SchoolSystem.Infrastructure.Repositories;

public class StudentPerformanceRepository : IStudentPerformanceRepository
{
    private readonly IMongoCollection<StudentPerformance> _studentPerformanceCollection;

    public StudentPerformanceRepository(IMongoDatabase database)
    {
        _studentPerformanceCollection = database.GetCollection<StudentPerformance>("StudentPerformances");
    }

    public async Task<StudentPerformance?> GetByStudentIdAsync(string studentId)
    {
        return await _studentPerformanceCollection
            .Find(sp => sp.StudentId == studentId)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(StudentPerformance studentPerformance)
    {
        await _studentPerformanceCollection.InsertOneAsync(studentPerformance);
    }

    public async Task UpdateAsync(StudentPerformance studentPerformance)
    {
        var filter = Builders<StudentPerformance>.Filter.Eq(sp => sp.Id, studentPerformance.Id);
        await _studentPerformanceCollection.ReplaceOneAsync(filter, studentPerformance);
    }
}