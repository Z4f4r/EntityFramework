using Entity_Framework.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Database.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(s => s.Courses)
            .WithMany(C => C.Students);
    }
}
