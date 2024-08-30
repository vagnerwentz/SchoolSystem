namespace SchoolSystem.API.Endpoints.Enrollments.Requests;

public record AddSubjectRequest(string Name, string Code, int ProfessorId);