using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Commands.Students.CreateStudent;

public class CreateStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<CreateStudentCommand, OperationResult<Student>>
{
    public async Task<OperationResult<Student>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var student = new Student(request.Name, request.Photo);
            await studentRepository.AddAsync(student, cancellationToken);

            return OperationResult<Student>.SuccessResult(
                null, 
                HttpStatusCode.Created, 
                $"O estudante {student.Name} foi adicionado ao sistema escolar."
            );
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}