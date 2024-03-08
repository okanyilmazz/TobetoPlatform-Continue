using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
{
    public void Configure(EntityTypeBuilder<ExamQuestion> builder)
    {
        builder.ToTable("ExamQuestions").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.QuestionId).HasColumnName("QuestionId").IsRequired();
        builder.Property(e => e.ExamId).HasColumnName("ExamId").IsRequired();

        builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

        builder.HasOne(eq => eq.Exam)
            .WithMany(e => e.ExamQuestions)
            .HasForeignKey(eq => eq.ExamId);

        builder.HasOne(eq => eq.Question)
            .WithMany(e => e.ExamQuestions)
            .HasForeignKey(eq => eq.QuestionId);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}