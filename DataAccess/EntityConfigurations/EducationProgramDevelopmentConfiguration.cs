using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class EducationProgramDevelopmentConfiguration : IEntityTypeConfiguration<EducationProgramDevelopment>
{
    public void Configure(EntityTypeBuilder<EducationProgramDevelopment> builder)
    {
        builder.ToTable("EducationProgramDevelopments").HasKey(e => e.Id);
        builder.Property(ec => ec.Id).HasColumnName("Id").IsRequired();
        builder.Property(ec => ec.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(ec => ec.EducationPrograms);


        builder.HasIndex(indexExpression: ec => ec.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: ec => ec.Name, name: "UK_Name").IsUnique();

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

    }
}
