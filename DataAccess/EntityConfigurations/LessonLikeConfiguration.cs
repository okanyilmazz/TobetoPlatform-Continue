using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class LessonLikeConfiguration : IEntityTypeConfiguration<LessonLike>
{
    public void Configure(EntityTypeBuilder<LessonLike> builder)
    {
        builder.ToTable("LessonLikes").HasKey(ll => ll.Id);

        builder.Property(ll => ll.Id).HasColumnName("Id").IsRequired();
        builder.Property(ll => ll.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(ll => ll.LessonId).HasColumnName("LessonId").IsRequired();

        builder.HasIndex(indexExpression: ll => ll.Id, name: "UK_Id").IsUnique();

        builder.HasOne(ll => ll.Account);
        builder.HasOne(ll => ll.Lesson);

        builder.HasQueryFilter(ll => !ll.DeletedDate.HasValue);
    }
}
