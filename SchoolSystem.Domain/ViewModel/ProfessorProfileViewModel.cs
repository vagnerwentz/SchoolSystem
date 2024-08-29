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

// const mockData = {
//     professorName: 'Professor X',
//     subjects: [
//     {
//         id: 1,
//         name: 'Matemática',
//         averageGrade: 8.5,
//         students: [
//         { id: 101, name: 'Estudante A' },
//         { id: 102, name: 'Estudante B' },
//         ],
//     },
//     {
//         id: 2,
//         name: 'Física',
//         averageGrade: 7.3,
//         students: [
//         { id: 103, name: 'Estudante C' },
//         { id: 104, name: 'Estudante D' },
//         ],
//     },
//     ],
// };