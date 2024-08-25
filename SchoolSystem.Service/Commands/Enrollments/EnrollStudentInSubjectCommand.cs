using MediatR;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Commands.Enrollments;

public record EnrollStudentInSubjectCommand(int StudentId, int SubjectId) : IRequest<OperationResult<EnrollStudentInSubjectCommand>>;