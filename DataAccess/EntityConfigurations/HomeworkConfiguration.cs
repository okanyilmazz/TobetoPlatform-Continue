using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
{
    public void Configure(EntityTypeBuilder<Homework> builder)
    {
        builder.ToTable("Homeworks").HasKey(h => h.Id);

        builder.Property(h => h.Id).HasColumnName("Id").IsRequired();
        builder.Property(h => h.LessonId).HasColumnName("LessonId").IsRequired();
        builder.Property(h => h.Name).HasColumnName("Name").IsRequired();
        builder.Property(h => h.Description).HasColumnName("Description").IsRequired();
        builder.Property(h => h.Deadline).HasColumnName("DeadLine").IsRequired();

        builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();


        builder.HasOne(h => h.Lesson)
            .WithMany(oc => oc.Homeworks)
            .HasForeignKey(h => h.LessonId);

        builder.HasMany(h => h.AccountHomeworks);


        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}