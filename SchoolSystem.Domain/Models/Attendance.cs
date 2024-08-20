namespace SchoolSystem.Domain.Models;

public class Attendance
{
    public Guid Id { get; private set; }
    public DateOnly Date { get; private set; }
    public bool Present { get; private set; }
    
    public int StudentId { get; private set; }
}