using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Query.Subjects.GetAllSubjects;

public class GetAllSubjectsQueryHandler(ISubjectsRepository subjectsRepository) : IRequestHandler<GetAllSubjectsQuery, OperationResult<List<Subject>>>
{
    public async Task<OperationResult<List<Subject>>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
    {
        var subjects = await subjectsRepository.GetAllSubjectsAsync(cancellationToken);
        return OperationResult<List<Subject>>.SuccessResult(subjects, HttpStatusCode.OK);
    }
}