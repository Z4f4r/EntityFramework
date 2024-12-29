namespace Entity_Framework.Database.Models;
public class CourseEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; } = 0;

    public int AuthorId { get; set; }

    public AuthorEntity? Author { get; set; }

    public List<LessonEntity> Lessons { get; set; } = [];

    public List<StudentEntity> Students { get; set; } = [];
}
