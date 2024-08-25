using MediatR;
using SchoolSystem.Domain.Models;
using SchoolSystem.Domain.Result;

namespace SchoolSystem.Service.Query.Subjects.GetAllSubjects;

public record GetAllSubjectsQuery() : IRequest<OperationResult<List<Subject>>>;