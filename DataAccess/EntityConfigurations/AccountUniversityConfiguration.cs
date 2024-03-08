using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AccountUniversityConfiguration : IEntityTypeConfiguration<AccountUniversity>
{
    public void Configure(EntityTypeBuilder<AccountUniversity> builder)
    {
        builder.ToTable("AccountUniversities").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(a => a.DegreeTypeId).HasColumnName("DegreeTypeId").IsRequired();
        builder.Property(a => a.UniversityId).HasColumnName("UniversityId").IsRequired();
        builder.Property(a => a.UniversityDepartmentId).HasColumnName("UniversityDepartmentId");
        builder.Property(a => a.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(a => a.EndDate).HasColumnName("EndDate");
        builder.Property(a => a.IsEducationActive).HasColumnName("IsEducationActive");

        
        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


        builder.HasOne(au => au.Account)
            .WithMany(a => a.AccountUniversities)
            .HasForeignKey(au => au.AccountId);

        builder.HasOne(au => au.University)
            .WithMany(u => u.AccountUniversities)
            .HasForeignKey(au => au.UniversityId);

        builder.HasOne(au => au.UniversityDepartment);

        builder.HasOne(au => au.DegreeType);


        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
