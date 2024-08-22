using MediatR;
using SchoolSystem.Domain.Interfaces.Repositories;
using SchoolSystem.Domain.Models.NonRelationalDatabase;
using SchoolSystem.Domain.Utils;

namespace SchoolSystem.Service.Commands.StudentPerformances.AddStudentGrade;

public class AddStudentGradeCommandHandler(
    IStudentPerformanceRepository repository,
    IEnrollmentRepository enrollmentRepository)
    : IRequestHandler<AddStudentGradeCommand, bool>
{
    public async Task<bool> Handle(AddStudentGradeCommand request, CancellationToken cancellationToken)
    {
        var studentPerformance = await repository.GetByStudentIdAsync(request.StudentId);

        if (studentPerformance == null)
        {
            studentPerformance = new StudentPerformance
            {
                StudentId = request.StudentId,
                SubjectPerformances =
                [
                    new SubjectPerformance
                    {
                        SubjectId = request.SubjectId,
                        Grades = [request.Grade]
                    }
                ]
            };

            await repository.AddAsync(studentPerformance);
        }
        else
        {
            var subjectPerformance = studentPerformance.SubjectPerformances
                .FirstOrDefault(sp => sp.SubjectId == request.SubjectId);

            if (subjectPerformance == null)
            {
                studentPerformance.SubjectPerformances.Add(new SubjectPerformance
                {
                    SubjectId = request.SubjectId,
                    Grades = new List<decimal> { request.Grade }
                });
            }
            else
            {
                subjectPerformance.Grades.Add(request.Grade);
            }

            await repository.UpdateAsync(studentPerformance);
        }
        
        var student = await repository.GetByStudentIdAsync(request.StudentId);
        var subjectPerformanceToBeUpdated = student.SubjectPerformances.FirstOrDefault(p => p.SubjectId == request.SubjectId);
        if (subjectPerformanceToBeUpdated is null) return true;
        
        var average = Calculate.Average(subjectPerformanceToBeUpdated!.Grades);
        await enrollmentRepository.UpdateFinalGrandeAsync(student.StudentId, subjectPerformanceToBeUpdated.SubjectId, average);
        return true;
    }
}