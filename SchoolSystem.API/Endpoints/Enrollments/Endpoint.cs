using SchoolSystem.API.Endpoints.Enrollments.Requests;

namespace SchoolSystem.API.Endpoints.Enrollments;

public static class Endpoint
{
    public static void RegisterEnrollmentEndpoints(this IEndpointRouteBuilder routes) 
    {
        var enrollments = routes.MapGroup("api/v1/enrollment");

        enrollments.MapPost("student", async (
            EnrollmentsService service,
            EnrollStudentInSubjectRequest request
        ) => await service.EnrollStudentInSubjectAsync(request));
    }

}