using System.Net;
using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Models.NonRelationalDatabase;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Commands.Enrollments;

public class EnrollStudentInSubjectCommandHandler(
    IEnrollmentRepository enrollmentRepository,
    IStudentPerformanceRepository studentPerformanceRepository
    ) : IRequestHandler<EnrollStudentInSubjectCommand, OperationResult<EnrollStudentInSubjectCommand>>
{
    public async Task<OperationResult<EnrollStudentInSubjectCommand>> Handle(EnrollStudentInSubjectCommand request, CancellationToken cancellationToken)
    {
        var enrollment = new Enrollment()
        {
            StudentId = request.StudentId,
            SubjectId = request.SubjectId,
            Absences = 0,
            FinalGrade = 0,
            MedicalReport = null
        };

        var studentPerformance = await studentPerformanceRepository.GetByStudentIdAsync(request.StudentId.ToString());
        if (studentPerformance == null)
        {
            studentPerformance = new StudentPerformance()
            {
                StudentId = request.StudentId.ToString(),
                SubjectPerformances =
                [
                    new SubjectPerformance
                    {
                        SubjectId = request.SubjectId.ToString(),
                        Grades = []
                    }
                ]
            };
        } else
        {
            var existingSubjectPerformance = studentPerformance.SubjectPerformances
                .FirstOrDefault(sp => sp.SubjectId == request.SubjectId.ToString());

            if (existingSubjectPerformance == null)
            {
                studentPerformance.SubjectPerformances.Add(new SubjectPerformance
                {
                    SubjectId = request.SubjectId.ToString(),
                    Grades = []
                });
                
                await studentPerformanceRepository.UpdateAsync(studentPerformance);
            }
        }
        
        var addSubjectsPerformanceTask = studentPerformanceRepository.AddAsync(studentPerformance);
        var addEnrollmentStudentInSubjectTask = enrollmentRepository.AddEnrollmentStudentInSubjectAsync(enrollment, cancellationToken); 
        
        await Task.WhenAll(addSubjectsPerformanceTask, addEnrollmentStudentInSubjectTask);
        return OperationResult<EnrollStudentInSubjectCommand>.SuccessResult(null, HttpStatusCode.Created);
    }
}