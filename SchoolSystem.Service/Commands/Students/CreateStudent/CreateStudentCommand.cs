using MediatR;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Commands.Students.CreateStudent;

public record CreateStudentCommand(string Name, string? Photo) : IRequest<OperationResult<Student>>;