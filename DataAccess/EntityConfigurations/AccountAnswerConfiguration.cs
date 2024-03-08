using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AccountAnswerConfiguration : IEntityTypeConfiguration<AccountAnswer>
{
    public void Configure(EntityTypeBuilder<AccountAnswer> builder)
    {
        builder.ToTable("AccountAnswers").HasKey(b => b.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(a => a.ExamId).HasColumnName("ExamId").IsRequired();
        builder.Property(a => a.QuestionId).HasColumnName("QuestionId").IsRequired();

        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

        builder.HasOne(a=>a.Account);
        builder.HasOne(a=>a.Exam);
        builder.HasOne(a=>a.Question);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}