using Entity_Framework.Database;
using Entity_Framework.Database.Models;
using Entity_Framework.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly ApplicationDbContext db;

    public CourseController(ApplicationDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<List<CourseEntity>> GetAll()
    {
        return await db.Courses
            .AsNoTracking()
            .OrderBy(c => c.Title)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public ActionResult<CourseEntity> Get(int id)
    {
        var course = db.Courses.Find(id);
        if (course == null) return NotFound();

        return Ok(course);
    }

    [HttpPost]
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

        await db.AddAsync(courseEntity);
        await db.SaveChangesAsync();
    }
}

