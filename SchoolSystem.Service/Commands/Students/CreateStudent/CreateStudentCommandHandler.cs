using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;

namespace SchoolSystem.Service.Commands.Students.CreateStudent;

public class CreateStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<CreateStudentCommand, int>
{
    public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var student = new Student(request.Name, request.Photo);
            await studentRepository.Create(student, cancellationToken);
            
            return 1;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}