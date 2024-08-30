using MediatR;
using SchoolSystem.API.Endpoints.Enrollments.Requests;
using SchoolSystem.Service.Commands.Subjects;
using SchoolSystem.Service.Query.Subjects.GetAllSubjects;

namespace SchoolSystem.API.Endpoints.Subjects;

public class SubjectsService(IMediator mediator)
{
    public async Task<IResult> GetAllSubjectsAsync()
    {
        var query = new GetAllSubjectsQuery();
        
        var result = await mediator.Send(query);
        
        return TypedResults.Ok(result);
    }

    public async Task<IResult> AddSubjectAsync(AddSubjectRequest request)
    {
        var command = new AddSubjectComand(request.Name, request.Code, request.ProfessorId);
        
        var result = await mediator.Send(command);
        
        return TypedResults.Ok(result);
    }
}