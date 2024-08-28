using MediatR;

namespace SchoolSystem.Service.Commands.StudentPerformances.AddStudentGrade;

public record AddStudentGradeCommand(
    string StudentId, 
    string SubjectId, 
    decimal Grade,
    string Description
    ) : IRequest<bool>;