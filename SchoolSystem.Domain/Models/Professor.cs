namespace SchoolSystem.Domain.Models;

public class Professor(string name, string? photo = null) : Person(name, photo)
{
    public int Id { get; private set; }
    
    public ICollection<Subject> Subjects { get; private set; } = new List<Subject>();
}