using MediatR;
using SchoolSystem.API.Endpoints.Enrollments.Requests;
using SchoolSystem.Service.Commands.Enrollments;

namespace SchoolSystem.API.Endpoints.Enrollments;

public class EnrollmentsService(IMediator mediator)
{
    public async Task<IResult> EnrollStudentInSubjectAsync(
        EnrollStudentInSubjectRequest request
    )
    {
        var command = new EnrollStudentInSubjectCommand(request.StudentId, request.SubjectId);
        
        var result = await mediator.Send(command);
        
        return TypedResults.Ok(result);
    }
}