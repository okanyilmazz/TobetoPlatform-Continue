using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class EducationProgramSubjectConfiguration : IEntityTypeConfiguration<EducationProgramSubject>
{
    public void Configure(EntityTypeBuilder<EducationProgramSubject> builder)
    {
        builder.ToTable("EducationProgramSubjects").HasKey(eps => eps.Id);

        builder.Property(eps => eps.Id).HasColumnName("Id").IsRequired();
        builder.Property(eps => eps.EducationProgramId).HasColumnName("EducationProgramId").IsRequired();
        builder.Property(eps => eps.SubjectId).HasColumnName("SubjectId").IsRequired();




        builder.HasOne(eppl => eppl.EducationProgram)
            .WithMany(pl => pl.EducationProgramSubjects)
            .HasForeignKey(eppl => eppl.EducationProgramId);


        builder.HasOne(eppl => eppl.Subject)
            .WithMany(pl => pl.EducationProgramSubjects)
            .HasForeignKey(eppl => eppl.SubjectId);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);


    }
}
