using System.Net;
using MediatR;
using SchoolSystem.API.Endpoints.Students.Requests;
using SchoolSystem.Service.Commands.Students.CreateStudent;

namespace SchoolSystem.API.Endpoints.Students;

public class StudentsService(IMediator mediator)
{
    public async Task<IResult> CreateStudentAsync(
        CreateStudentRequest request
        )
    {
        var command = new CreateStudentCommand(request.Name, request.Photo);
        
        var result = await mediator.Send(command);
        
        return TypedResults.Ok(result);
    }
}