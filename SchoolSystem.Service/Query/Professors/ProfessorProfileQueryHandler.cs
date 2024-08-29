using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;
using SchoolSystem.Domain.ViewModel;

namespace SchoolSystem.Service.Query.Professors;

public class ProfessorProfileQueryHandler(
    IProfessorRepository professorRepository,
    ISubjectsRepository subjectsRepository,
    IEnrollmentRepository enrollmentRepository
    ) : IRequestHandler<ProfessorProfileQuery, OperationResult<ProfessorProfileViewModel>>
{
    public async Task<OperationResult<ProfessorProfileViewModel>> Handle(ProfessorProfileQuery request, CancellationToken cancellationToken)
    {
        
        var professor = await professorRepository.GetProfessorProfileAsync(request.Id);
        var subjectsViewModels = professor.Subjects.Select(subject => new SubjectsViewModel
        {
            SubjectId = subject.Id,
            SubjectName = subject.Name,
            OverallClassAverage = subject.Enrollments.Any() ? (decimal)subject.Enrollments.Average(e => e.FinalGrade) : 0,
            Students = subject.Enrollments.Select(e => new StudentViewModel
            {
                StudentId = e.StudentId,
                StudentName = e.Student.Name
            }).ToList()
        }).ToList();

        var professorProfileViewModel = new ProfessorProfileViewModel
        {
            ProfessorId = professor.Id,
            ProfessorName = professor.Name,
            Subjects = subjectsViewModels
        };

        return OperationResult<ProfessorProfileViewModel>.SuccessResult(professorProfileViewModel,
            HttpStatusCode.Accepted);
    }
}