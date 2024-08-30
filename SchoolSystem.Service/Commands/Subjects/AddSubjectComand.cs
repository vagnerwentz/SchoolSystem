using MediatR;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Commands.Subjects;

public record AddSubjectComand(string Name, string Code, int ProfessorId) : IRequest<OperationResult<AddSubjectComand>>;