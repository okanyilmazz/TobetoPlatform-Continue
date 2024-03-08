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
    public class AccountLessonConfiguration : IEntityTypeConfiguration<AccountLesson>
    {
        public void Configure(EntityTypeBuilder<AccountLesson> builder)
        {
            builder.ToTable("AccountLessons").HasKey(b => b.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.LessonId).HasColumnName("LessonId").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasOne(al => al.Lesson)
                .WithMany(l => l.AccountLessons)
                .HasForeignKey(al => al.LessonId);

            builder.HasOne(al => al.Account)
                .WithMany(a => a.AccountLessons)
                .HasForeignKey(al => al.AccountId);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
