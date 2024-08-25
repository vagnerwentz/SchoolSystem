using SchoolSystem.API.Endpoints.Enrollments.Requests;

namespace SchoolSystem.API.Endpoints.Subjects;

public static class Endpoint
{
    public static void RegisterSubjectEndpoints(this IEndpointRouteBuilder routes) 
    {
        var subjects = routes.MapGroup("api/v1/subjects");

        subjects.MapGet("list", async (
            SubjectsService service
        ) => await service.GetAllSubjectsAsync());
    }

}