using Entity_Framework.Database;
using Entity_Framework.Database.Models;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Entity_Framework.Repositories;

public class CourseRepository
{
    private readonly ApplicationDbContext dbContext;

    public CourseRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<CourseEntity>> Get()
    {
        return await dbContext.Courses
            .AsNoTracking()
            .OrderBy(c => c.Title)
            .ToListAsync();
    }

    public async Task<List<CourseEntity>> GetWithLessons()
    {
        return await dbContext.Courses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .ToListAsync();
    }

    public async Task<CourseEntity?> GetById(int id)
    {
        return await dbContext.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<CourseEntity>> GetByFilter(string title, decimal price)
    {
        var query = dbContext.Courses.AsNoTracking();

        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(c => c.Title.Contains(title));
        }

        if (price > 0)
        {
            query = query.Where(p => p.Price > price);
        }

        return await query.ToListAsync();
    }

    public async Task<List<CourseEntity>> GetByPage(int page,  int pageSize)
    {
        return await dbContext.Courses
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task Add(int id, int authorId, string title, string description, decimal price)
    {
        var courseEntity = new CourseEntity
        {
            Id = id,
            AuthorId = authorId,
            Title = title,
            Description = description,
            Price = price
        };

        await dbContext.AddAsync(courseEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(int id, int authorId, string title, string description, decimal price)
    {
        var courseEntity = await dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new Exception();

        courseEntity.Title = title;
        courseEntity.Description = description;
        courseEntity.Price = price;

        await dbContext.SaveChangesAsync();
    }
    public async Task Update2(int id, int authorId, string title, string description, decimal price)
    {
        await dbContext.Courses
            .Where(c => c.Id != id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(c => c.Title, title)
            .SetProperty(c => c.Description, description)
            .SetProperty(c => c.Price, price));
    }

    public async Task Delete(int id)
    {
        await dbContext.Courses
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}
