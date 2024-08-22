using MongoDB.Bson.Serialization.Attributes;

namespace SchoolSystem.Domain.Models.NonRelationalDatabase;

public class SubjectPerformance
{
    [BsonElement("subjectId")]
    public string SubjectId { get; set; } = null!;  // Referência ao ID da matéria no PostgreSQL

    [BsonElement("grades")]
    public List<decimal> Grades { get; set; } = new List<decimal>();  // Array de notas

    [BsonElement("finalGrade")]
    public decimal? FinalGrade { get; set; }  // Nota final calculada

    [BsonElement("absences")]
    public int Absences { get; set; }  // Número de faltas

    [BsonElement("comments")]
    public string? Comments { get; set; }  // Comentários do professor

    [BsonElement("performanceGraph")]
    public string? PerformanceGraph { get; set; }  // URL ou dados do gráfico de desempenho
}