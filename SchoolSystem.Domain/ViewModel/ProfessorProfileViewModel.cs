namespace SchoolSystem.Domain.ViewModel;

public class ProfessorProfileViewModel
{
    public int ProfessorId { get; set; }
    public string ProfessorName { get; set; }
    public List<SubjectsViewModel> Subjects { get; set; }
}

public class SubjectsViewModel
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public decimal OverallClassAverage { get; set; }
    public List<StudentViewModel> Students { get; set; }
}

public class StudentViewModel
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
}