using MediatR;
using SchoolSystem.API.Endpoints.StudentPerformances.Requests;
using SchoolSystem.Service.Commands.StudentPerformances.AddStudentGrade;
using SchoolSystem.Service.Query.StudentPerformances;

namespace SchoolSystem.API.Endpoints.StudentPerformances;

public class StudentPerformancesService(IMediator mediator)
{
    public async Task<IResult> AddStudentPerformanceAsync(
        AddStudentPerformanceRequest request
        )
    {
        var command = new AddStudentGradeCommand(
            request.StudentId, 
            request.SubjectId, 
            request.Grade,
            request.Description
        );
        
        var result = await mediator.Send(command);
        
        return TypedResults.Ok(result);
    }

    public async Task<IResult> GetStudentPerformanceById(int id)
    {
        var query = new GetStudentPerformanceByIdQuery(id);
        var result = await mediator.Send(query);
        return TypedResults.Ok(result);
    }
}