using SchoolSystem.API.Endpoints.Professors.Requests;

namespace SchoolSystem.API.Endpoints.Professors;

public static class Endpoint
{
    public static void RegisterProfessorEndpoints(this IEndpointRouteBuilder routes) 
    {
        var professors = routes.MapGroup("api/v1/professors");

        professors.MapPost("create", async (
            ProfessorsService service,
            CreateProfessorRequest request
        ) => await service.CreateProfessorAsync(request));
    }
}