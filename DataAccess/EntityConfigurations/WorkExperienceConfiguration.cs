using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations;

public class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
{
    public void Configure(EntityTypeBuilder<WorkExperience> builder)
    {
        builder.ToTable("WorkExperiences").HasKey(w => w.Id);

        builder.Property(w => w.Id).HasColumnName("Id").IsRequired();
        builder.Property(w => w.Department).HasColumnName("Department").IsRequired();
        builder.Property(w => w.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(w => w.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(w => w.Industry).HasColumnName("Industry").IsRequired();
        builder.Property(w => w.CompanyName).HasColumnName("CompanyName").IsRequired();
        builder.Property(w => w.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(w => w.Description).HasColumnName("Description").IsRequired();

        builder.HasIndex(indexExpression: u => u.Id, name: "UK_Id").IsUnique();

        builder.HasOne(w => w.Account)
            .WithMany(a => a.WorkExperiences)
            .HasForeignKey(w => w.AccountId);

        builder.HasOne(w => w.City);

        builder.HasQueryFilter(w => !w.DeletedDate.HasValue);
    }
}