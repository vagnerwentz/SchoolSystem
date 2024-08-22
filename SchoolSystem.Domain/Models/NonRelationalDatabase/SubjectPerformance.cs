using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models.NonRelationalDatabase;

public class SubjectPerformance
{
    [BsonElement("subjectId")]
    public string SubjectId { get; set; } = null!;

    [BsonElement("grades")]
    public List<decimal> Grades { get; set; } = new List<decimal>();
    
    [BsonElement("comments")]
    public string? Comments { get; set; }

    [BsonElement("performanceGraph")]
    public string? PerformanceGraph { get; set; }
}