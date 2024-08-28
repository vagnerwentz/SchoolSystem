using MediatR;
using SchoolSystem.Domain.Models.NonRelationalDatabase;
using SchoolSystem.Domain.Result;
using SchoolSystem.Domain.ViewModel;

namespace SchoolSystem.Service.Query.StudentPerformances;

public record GetStudentPerformanceByIdQuery(int Id) : IRequest<OperationResult<StudentPerformanceViewModel>>;