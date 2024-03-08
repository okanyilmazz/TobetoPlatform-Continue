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
    public class UniversityDepartmentConfiguration : IEntityTypeConfiguration<UniversityDepartment>
    {
        public void Configure(EntityTypeBuilder<UniversityDepartment> builder)
        {
            builder.ToTable("UniversityDepartments").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.UniversityId).HasColumnName("UniversityId").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: a => a.Name, name: "UK_Name").IsUnique();

            builder.HasOne(ud => ud.University);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}