using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Commands.Enrollments;

public class EnrollStudentInSubjectCommandHandler(IEnrollmentRepository enrollmentRepository) : IRequestHandler<EnrollStudentInSubjectCommand, OperationResult<EnrollStudentInSubjectCommand>>
{
    public async Task<OperationResult<EnrollStudentInSubjectCommand>> Handle(EnrollStudentInSubjectCommand request, CancellationToken cancellationToken)
    {
        var enrollment = new Enrollment()
        {
            StudentId =request.StudentId,
            SubjectId = request.SubjectId,
            Absences = 0,
            FinalGrade = 0,
            MedicalReport = null
        };
        await enrollmentRepository.AddEnrollmentStudentInSubjectAsync(enrollment, cancellationToken);
        return OperationResult<EnrollStudentInSubjectCommand>.SuccessResult(null, HttpStatusCode.Created);
    }
}