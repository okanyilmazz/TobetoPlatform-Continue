using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects").HasKey(c => c.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.Name).HasColumnName("Name").IsRequired();

        builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();
        builder.HasIndex(indexExpression: l => l.Id, name: "UK_Id").IsUnique();

        builder.HasMany(ls => ls.EducationProgramSubjects);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
