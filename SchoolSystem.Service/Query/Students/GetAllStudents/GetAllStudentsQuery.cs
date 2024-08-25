using MediatR;
using SchoolSystem.Domain.Result;
using SchoolSystem.Domain.ViewModel;

namespace SchoolSystem.Service.Query.Students.GetAllStudents;

public record GetAllStudentsQuery : IRequest<OperationResult<List<GetAllStudentsViewModel>>>;