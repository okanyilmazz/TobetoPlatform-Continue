using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.ToTable("Universities").HasKey(c => c.Id);

            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: u => u.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: u => u.Name, name: "UK_Name").IsUnique();


            builder.HasMany(u => u.AccountUniversities);

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}