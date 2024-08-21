namespace SchoolSystem.Domain.Models;

public class Person(string name, string? photo = null)
{
    public string Name { get; private set; } = name;
    public string? Photo { get; private set; } = photo;
}