using MediatR;

namespace SchoolSystem.Service.Commands.Students.CreateStudent;

public record CreateStudentCommand(string Name, string? Photo) : IRequest<int>;