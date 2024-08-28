using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models.NonRelationalDatabase;
using SchoolSystem.Domain.Result;
using SchoolSystem.Domain.ViewModel;

namespace SchoolSystem.Service.Query.StudentPerformances;

public class GetStudentPerformanceByIdQueryHandler(
    IStudentPerformanceRepository studentPerformanceRepository,
    IEnrollmentRepository enrollmentRepository
    )
    : IRequestHandler<GetStudentPerformanceByIdQuery, OperationResult<StudentPerformanceViewModel>>
{
    public async Task<OperationResult<StudentPerformanceViewModel>> Handle(GetStudentPerformanceByIdQuery request, CancellationToken cancellationToken)
    {
        var studentPerformance = await studentPerformanceRepository.GetByStudentIdAsync(request.Id.ToString());
        var enrollments = await enrollmentRepository.GetEnrollmentStudentAsync(request.Id);
        
        var subjectsPerformanceList = enrollments.Select(e => new SubjectsPerformanceDto
        {
            SubjectId = e.SubjectId.ToString(),
            SubjectName = e.Subject.Name,
            Grades = studentPerformance.SubjectPerformances
                .Where(sp => sp.SubjectId == e.SubjectId.ToString())
                .SelectMany(sp => sp.Grades)
                .ToList(),
            FinalGrade = decimal.Round((decimal)e.FinalGrade, 2, MidpointRounding.AwayFromZero)
        }).ToList();

        var studentPerformanceViewModel = new StudentPerformanceViewModel
        {
            StudentId = request.Id.ToString(),
            SubjectsPerformance = subjectsPerformanceList
        };

        return OperationResult<StudentPerformanceViewModel>.SuccessResult(studentPerformanceViewModel, HttpStatusCode.OK);
    }
}