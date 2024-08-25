using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Result;
using SchoolSystem.Domain.ViewModel;

namespace SchoolSystem.Service.Query.Students.GetAllStudents;

public class GetAllStudentsQueryHandler(IStudentRepository studentRepository) : IRequestHandler<GetAllStudentsQuery, OperationResult<List<GetAllStudentsViewModel>>>
{
    public async Task<OperationResult<List<GetAllStudentsViewModel>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await studentRepository.GetAllStudentsAsync(cancellationToken);
        var studentsViewModel = students.Select(s => new GetAllStudentsViewModel(s.Id, s.Name, s.Photo)).ToList();
        
        return OperationResult<List<GetAllStudentsViewModel>>.SuccessResult(studentsViewModel, HttpStatusCode.Accepted);
    }
}