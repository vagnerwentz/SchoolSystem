namespace SchoolSystem.Domain.ViewModel;

public class GetAllStudentsViewModel(int id, string name, string? photo)
{
    public int Id { get; private set; } = id;
    public string Name { get; private set; } = name;
    public string? Photo { get; private set; } = photo;
}