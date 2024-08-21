using MediatR;
using SchoolSystem.API.Endpoints.Students.Requests;

namespace SchoolSystem.API.Endpoints.Students;

public static class Endpoint
{
    public static void RegisterStudentEndpoints(this IEndpointRouteBuilder routes) 
    {
        var students = routes.MapGroup("api/v1/students");

        students.MapPost("create", async (
            StudentsService service,
            CreateStudentRequest request
        ) => await service.CreateStudentAsync(request));
    }
}