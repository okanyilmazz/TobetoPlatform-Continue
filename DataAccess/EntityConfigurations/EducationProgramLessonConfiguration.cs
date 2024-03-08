using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class EducationProgramLessonConfiguration : IEntityTypeConfiguration<EducationProgramLesson>
    {
        public void Configure(EntityTypeBuilder<EducationProgramLesson> builder)
        {
            builder.ToTable("EducationProgramLessons").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.LessonId).HasColumnName("LessonId").IsRequired();
            builder.Property(c => c.EducationProgramId).HasColumnName("EducationProgramId").IsRequired();


            builder.HasIndex(indexExpression: e => e.Id, name: "UK_Id").IsUnique();


            builder.HasOne(epl => epl.EducationProgram)
                .WithMany(ep => ep.EducationProgramLessons)
                .HasForeignKey(epl => epl.EducationProgramId);

            builder.HasOne(epl => epl.Lesson)
                .WithMany(ep => ep.EducationProgramLessons)
                .HasForeignKey(epl => epl.LessonId);

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}