using Entity_Framework.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Database.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.Author)
            .WithOne(c => c.Course)
            .HasForeignKey<CourseEntity>(c => c.AuthorId);

        builder
            .HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId);

        builder
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);
    }
}
