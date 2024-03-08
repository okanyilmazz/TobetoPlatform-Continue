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
    public class AccountSkillConfiguration : IEntityTypeConfiguration<AccountSkill>
    {
        public void Configure(EntityTypeBuilder<AccountSkill> builder)
        {
            builder.ToTable("AccountSkills").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(a => a.SkillId).HasColumnName("SkillId").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasOne(ask => ask.Account)
                .WithMany(a => a.AccountSkills)
                .HasForeignKey(ask => ask.AccountId);

            builder.HasOne(ask => ask.Skill)
                .WithMany(s => s.AccountSkills)
                .HasForeignKey(ask => ask.SkillId);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
