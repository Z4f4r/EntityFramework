using Entity_Framework.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Database.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(c => c.CourseId);
    }
}