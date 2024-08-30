using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models;

public class Subject(string? Name, string? Code, int ProfessorId)
{
    public int Id { get; private set; }
    
    public string Name { get; private set; } = Name;

    public string Code { get; private set; } = Code;

    public int ProfessorId { get; private set; } = ProfessorId;
    public Professor Professor { get; private set; } = null!;
    
    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
}