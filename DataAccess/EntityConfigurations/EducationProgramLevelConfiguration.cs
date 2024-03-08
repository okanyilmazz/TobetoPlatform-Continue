using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class EducationProgramLevelConfiguration : IEntityTypeConfiguration<EducationProgramLevel>
{
    public void Configure(EntityTypeBuilder<EducationProgramLevel> builder)
    {
        builder.ToTable("EducationProgramLevels").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();


        builder.HasIndex(indexExpression:c => c.Name,name:"UK_Name").IsUnique();
        builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();


        builder.HasMany(ec => ec.EducationPrograms);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}