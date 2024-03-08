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
    public class AccountHomeworkConfiguration : IEntityTypeConfiguration<AccountHomework>
    {
        public void Configure(EntityTypeBuilder<AccountHomework> builder)
        {
            builder.ToTable("AccountHomeworks").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.HomeworkId).HasColumnName("HomeworkId").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(a => a.Status).HasColumnName("Status").IsRequired();

            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasOne(ah=>ah.Homework)
                .WithMany(h=>h.AccountHomeworks)
                .HasForeignKey(ah=>ah.HomeworkId);

            builder.HasOne(ah => ah.Account)
                .WithMany(a => a.AccountHomeworks)
                .HasForeignKey(ah => ah.AccountId);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}