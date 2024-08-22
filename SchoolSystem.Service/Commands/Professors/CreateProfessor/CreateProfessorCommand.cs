using MediatR;

namespace SchoolSystem.Service.Commands.Professors.CreateProfessor;

public record CreateProfessorCommand(string Name, string? Photo) : IRequest<int>;