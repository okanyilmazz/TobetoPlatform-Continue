using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AccountViewLessonConfiguration : IEntityTypeConfiguration<AccountViewLesson>
{
    public void Configure(EntityTypeBuilder<AccountViewLesson> builder)
    {
        builder.ToTable("AccountViewLessons").HasKey(awl=>awl.Id);
        builder.Property(awl => awl.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(awl => awl.LessonId).HasColumnName("LessonId").IsRequired();


        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


        builder.HasOne(awl => awl.Account)
            .WithMany(a => a.AccountViewLessons)
            .HasForeignKey(awl => awl.AccountId);

        builder.HasOne(awl => awl.Lesson)
            .WithMany(sm => sm.AccountViewLessons)
            .HasForeignKey(awl => awl.LessonId);


        builder.HasQueryFilter(awl => !awl.DeletedDate.HasValue);
    }
}
