using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models.NonRelationalDatabase;

public class SubjectPerformance
{
    [BsonElement("subjectId")]
    public string SubjectId { get; set; } = null!;

    [BsonElement("grades")]
    public List<Grades> Grades { get; set; } = new List<Grades>();
    
    [BsonElement("comments")]
    public string? Comments { get; set; }

    [BsonElement("performanceGraph")]
    public string? PerformanceGraph { get; set; }
}

public class Grades
{
    public decimal Grade { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ChangedAt { get; set; }
}