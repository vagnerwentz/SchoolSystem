namespace SchoolSystem.Domain.Utils;

public static class Calculate
{
    public static decimal Average(List<decimal> grades)
    {
        return grades.Count == 0 ? 0 : grades.Average();
    }
}