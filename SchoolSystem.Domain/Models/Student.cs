namespace SchoolSystem.Domain.Models;

public class Student(string name, string? photo = null) : Person(name, photo)
{
    public int Id { get; private set; }
}