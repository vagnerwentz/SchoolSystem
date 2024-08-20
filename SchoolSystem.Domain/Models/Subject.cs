using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models;

public class Subject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    [BsonElement("Professor")]
    public Professor Professors { get; set; } = null!;

    [BsonElement("Students")]
    public List<Student> Students { get; set; } = [];

    [BsonElement("Attendance")]
    public List<Attendance> Attendances { get; set; } = [];
}