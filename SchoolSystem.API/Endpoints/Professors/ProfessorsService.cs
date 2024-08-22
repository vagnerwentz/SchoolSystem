using MediatR;
using SchoolSystem.API.Endpoints.Professors.Requests;
using SchoolSystem.Service.Commands.Professors.CreateProfessor;

namespace SchoolSystem.API.Endpoints.Professors;

public class ProfessorsService(ISender mediator)
{
    public async Task<IResult> CreateProfessorAsync(
        CreateProfessorRequest request
    )
    {
        var command = new CreateProfessorCommand(request.Name, request.Photo);
        
        var result = await mediator.Send(command);
        
        return TypedResults.Ok(result);
    }
}