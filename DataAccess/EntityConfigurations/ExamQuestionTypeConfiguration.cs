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
    public class ExamQuestionTypeConfiguration : IEntityTypeConfiguration<ExamQuestionType>
    {
        public void Configure(EntityTypeBuilder<ExamQuestionType> builder)
        {
            builder.ToTable("ExamQuestionTypes").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeId").IsRequired();
            builder.Property(e => e.ExamId).HasColumnName("ExamId").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
        }
    }
}