using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.ToTable("ExamResults").HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
            builder.Property(r => r.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(r => r.ExamId).HasColumnName("ExamId").IsRequired();
            builder.Property(r => r.CorrectOptionCount).HasColumnName("CorrectOptionCount").IsRequired();
            builder.Property(r => r.IncorrectOptionCount).HasColumnName("IncorrectOptionCount").IsRequired();
            builder.Property(r => r.EmptyOptionCount).HasColumnName("EmptyOptionCount").IsRequired();
            builder.Property(r => r.Result).HasColumnName("Result").IsRequired();


            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();


            builder.HasOne(er => er.Account);
            builder.HasOne(er => er.Exam);


            builder.HasQueryFilter(q => !q.DeletedDate.HasValue);
        }
    }
}

