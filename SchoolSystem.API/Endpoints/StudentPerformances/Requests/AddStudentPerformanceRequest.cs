namespace SchoolSystem.API.Endpoints.StudentPerformances.Requests;

public record AddStudentPerformanceRequest(
    string StudentId,
    string SubjectId,
    decimal Grade
);