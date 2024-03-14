using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.EntityConfigurations;

public class AccountEducationProgramConfiguration : IEntityTypeConfiguration<AccountEducationProgram>
{
    public void Configure(EntityTypeBuilder<AccountEducationProgram> builder)
    {
        builder.ToTable("AccountEducationPrograms").HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(a => a.EducationProgramId).HasColumnName("EducationProgramId").IsRequired();
        builder.Property(a => a.StatusPercent).HasColumnName("StatusPercent").IsRequired();
        builder.Property(a => a.TimeSpent).HasColumnName("TimeSpent").IsRequired();
        


        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

        builder.HasOne(a => a.Account)
            .WithMany(a => a.AccountEducationPrograms)
            .HasForeignKey(a => a.AccountId);


        builder.HasOne(a => a.EducationProgram)
            .WithMany(ep => ep.AccountEducationPrograms)
            .HasForeignKey(a => a.EducationProgramId);


        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
