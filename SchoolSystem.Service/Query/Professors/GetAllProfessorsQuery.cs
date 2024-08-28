using MediatR;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Query.Professors;

public record GetAllProfessorsQuery : IRequest<OperationResult<List<Professor>>>;