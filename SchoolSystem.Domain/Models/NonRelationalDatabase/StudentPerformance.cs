using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models.NonRelationalDatabase;

public class StudentPerformance
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("studentId")]
    public string StudentId { get; set; } = null!;

    [BsonElement("subjectPerformances")]
    public List<SubjectPerformance> SubjectPerformances { get; set; } = new List<SubjectPerformance>();
}

