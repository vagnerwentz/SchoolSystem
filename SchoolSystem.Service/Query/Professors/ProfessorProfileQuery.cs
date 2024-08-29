using MediatR;
using SchoolSystem.Domain.Result;
using SchoolSystem.Domain.ViewModel;

namespace SchoolSystem.Service.Query.Professors;

public record ProfessorProfileQuery(int Id) : IRequest<OperationResult<ProfessorProfileViewModel>>;