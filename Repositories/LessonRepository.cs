using Entity_Framework.Database;
using Entity_Framework.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Repositories;

public class LessonRepository
{
    private readonly ApplicationDbContext dbContext;

    public LessonRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Add(int courseId, LessonEntity lesson)
    {
        var course = await dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId)
            ?? throw new Exception();

        course.Lessons.Add(lesson);

        await dbContext.SaveChangesAsync();
    }

    public async Task AddLesson2(int courseId, string title)
    {
        var lesson = new LessonEntity
        {
            Id = courseId,
            Title = title
        };

        await dbContext.AddAsync(lesson);

        await dbContext.SaveChangesAsync();
    }

}
