using MediatR;
using SchoolSystem.API.Endpoints.StudentPerformances.Requests;
using SchoolSystem.API.Endpoints.Students.Requests;

namespace SchoolSystem.API.Endpoints.StudentPerformances;

public static class Endpoint
{
    public static void RegisterStudentPerformancesEndpoints(this IEndpointRouteBuilder routes) 
    {
        var studentPerformance = routes.MapGroup("api/v1/student/performance");

        studentPerformance.MapPost("create", async (
            StudentPerformancesService service,
            AddStudentPerformanceRequest request
        ) => await service.AddStudentPerformanceAsync(request));
    }
}