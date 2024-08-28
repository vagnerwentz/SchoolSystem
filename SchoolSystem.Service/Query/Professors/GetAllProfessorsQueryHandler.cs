using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Query.Professors;

public class GetAllProfessorsQueryHandler(IProfessorRepository professorRepository) : IRequestHandler<GetAllProfessorsQuery, OperationResult<List<Professor>>>
{
    public async Task<OperationResult<List<Professor>>> Handle(GetAllProfessorsQuery request, CancellationToken cancellationToken)
    {
        var professors = await professorRepository.GetAllProfessorsAsync(cancellationToken);

        return OperationResult<List<Professor>>.SuccessResult(professors, HttpStatusCode.Accepted);
    }
}