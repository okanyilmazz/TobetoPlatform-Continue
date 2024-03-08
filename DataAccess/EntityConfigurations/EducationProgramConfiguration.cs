using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class EducationProgramConfiguration : IEntityTypeConfiguration<EducationProgram>
{
    public void Configure(EntityTypeBuilder<EducationProgram> builder)
    {
        builder.ToTable("EducationPrograms").HasKey(e => e.Id);

        builder.Property(ep => ep.Id).HasColumnName("Id").IsRequired();
        builder.Property(ep => ep.EducationProgramLevelId).HasColumnName("EducationProgramLevelId").IsRequired();
        builder.Property(ep => ep.EducationProgramDevelopmentId).HasColumnName("EducationProgramDevelopmentId").IsRequired();
        builder.Property(ep => ep.BadgeId).HasColumnName("BadgeId").IsRequired();
        builder.Property(ep => ep.Name).HasColumnName("Name").IsRequired();
        builder.Property(ep => ep.Description).HasColumnName("Description").IsRequired();
        builder.Property(ep => ep.Duration).HasColumnName("Duration").IsRequired();
        builder.Property(ep => ep.AuthorizedPerson).HasColumnName("AuthorizedPerson").IsRequired();
        builder.Property(ep => ep.Price).HasColumnName("Price").IsRequired();
        builder.Property(ep => ep.ThumbnailPath).HasColumnName("ThumbnailPath").IsRequired();
        builder.Property(ep => ep.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(ep => ep.Deadline).HasColumnName("Deadline").IsRequired();


        builder.HasIndex(indexExpression: e => e.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: e => e.Name, name: "UK_Name").IsUnique();


        builder.HasOne(ep => ep.EducationProgramLevel);
        builder.HasOne(ep => ep.EducationProgramDevelopment);
        builder.HasOne(ep => ep.Badge);

        builder.HasMany(ep => ep.EducationProgramLessons);
        builder.HasMany(ep => ep.EducationProgramOccupationClasses);
        builder.HasMany(ep => ep.EducationProgramProgrammingLanguages);
        builder.HasMany(ask => ask.AccountEducationPrograms);
        builder.HasMany(ep => ep.EducationProgramSubjects);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}