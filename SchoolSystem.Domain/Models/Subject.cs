using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models;

public class Subject
{
    public int Id { get; private set; }
    
    public string Name { get; private set; } = null!;

    public string Code { get; private set; } = null!;

    public int ProfessorId { get; private set; }
    public Professor Professor { get; private set; } = null!;
    
    public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
}