using SchoolSystem.Domain.Models.NonRelationalDatabase;

namespace SchoolSystem.Domain.ViewModel;

public class StudentPerformanceViewModel
{
    public string StudentId { get; set; }
    public List<SubjectsPerformanceDto> SubjectsPerformance { get; set; }
}

public class SubjectsPerformanceDto
{
    public string SubjectId { get; set; }
    public string SubjectName { get; set; }
    public List<Grades> Grades { get; set; }
    
    public decimal FinalGrade { get; set; } 
    
    public string? Comments { get; set; }
    
    public string? PerformanceGraph { get; set; }
}