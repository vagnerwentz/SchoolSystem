using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Service.Commands.Professors.CreateProfessor;

public class CreateProfessorCommandHandler(IProfessorRepository professorRepository) : IRequestHandler<CreateProfessorCommand, int>
{
    public async Task<int> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var professor = new Professor(request.Name, request.Photo);
            await professorRepository.Create(professor, cancellationToken);
            
            return 1;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}