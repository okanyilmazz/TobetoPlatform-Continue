using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams").HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
            builder.Property(b => b.Duration).HasColumnName("Duration").IsRequired();
            builder.Property(b => b.QuestionCount).HasColumnName("QuestionCount").IsRequired();


            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();


            builder.HasMany(e => e.ExamQuestions);
            builder.HasMany(e => e.ExamOccupationClasses);


            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}