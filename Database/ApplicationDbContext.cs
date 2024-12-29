using Entity_Framework.Database.Configurations;
using Entity_Framework.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options)
{

    //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //{
        
    //}

    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<StudentEntity> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}