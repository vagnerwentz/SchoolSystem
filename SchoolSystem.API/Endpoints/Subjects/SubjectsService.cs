using MediatR;
using SchoolSystem.Service.Query.Subjects.GetAllSubjects;

namespace SchoolSystem.API.Endpoints.Subjects;

public class SubjectsService(IMediator mediator)
{
    public async Task<IResult> GetAllSubjectsAsync()
    {
        var command = new GetAllSubjectsQuery();
        
        var result = await mediator.Send(command);
        
        return TypedResults.Ok(result);
    }
}