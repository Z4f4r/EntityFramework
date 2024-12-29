using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity_Framework.Database.Models;

namespace Entity_Framework.Database.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.Course)
            .WithOne(c => c.Author)
            .HasForeignKey<AuthorEntity>(c => c.CourseId);
    }
}

