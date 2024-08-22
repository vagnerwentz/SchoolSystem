using MediatR;
using SchoolSystem.API.Endpoints.StudentPerformances.Requests;
using SchoolSystem.Service.Commands.StudentPerformances.AddStudentGrade;

namespace SchoolSystem.API.Endpoints.StudentPerformances;

public class StudentPerformancesService(IMediator mediator)
{
    public async Task<IResult> AddStudentPerformanceAsync(
        AddStudentPerformanceRequest request
        )
    {
        var command = new AddStudentGradeCommand(request.StudentId, request.SubjectId, request.Grade);
        
        var result = await mediator.Send(command);
        
        return TypedResults.Ok(result);
    }
}