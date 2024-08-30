using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Commands.Subjects;

public class AddSubjectComandHandler(ISubjectsRepository repository)
    : IRequestHandler<AddSubjectComand, OperationResult<AddSubjectComand>>
{
    public async Task<OperationResult<AddSubjectComand>> Handle(AddSubjectComand request, CancellationToken cancellationToken)
    {
        var subject = new Subject(request.Name, request.Code, request.ProfessorId);
        await repository.AddSubjectAsync(subject);
        return OperationResult<AddSubjectComand>.SuccessResult(null, HttpStatusCode.Created,
            "Matéria criada com sucesso");
    }
}