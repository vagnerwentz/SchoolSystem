using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models.NonRelationalDatabase;

public class StudentPerformance
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("studentId")]
    public string StudentId { get; set; } = null!;  // Referência ao ID do aluno no PostgreSQL

    [BsonElement("subjectPerformances")]
    public List<SubjectPerformance> SubjectPerformances { get; set; } = new List<SubjectPerformance>();
}

