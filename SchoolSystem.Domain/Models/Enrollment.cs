namespace SchoolSystem.Domain.Models;

public class Enrollment
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public decimal? FinalGrade { get; set; }
    public int Absences { get; set; } 
    public string? MedicalReport { get; set; } 
}