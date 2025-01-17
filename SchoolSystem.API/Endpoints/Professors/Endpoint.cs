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

        professors.MapGet("list", async (ProfessorsService service) => await service.GetAllProfessorsAsync());

        professors.MapGet("profile/{id:int}", async (
            int id,
            ProfessorsService service
        ) => await service.GetProfessorProfile(id));
    }
}