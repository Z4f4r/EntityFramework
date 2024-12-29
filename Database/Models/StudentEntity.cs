namespace Entity_Framework.Database.Models;

public class StudentEntity
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public List<CourseEntity> Courses { get; set; } = [];
}
