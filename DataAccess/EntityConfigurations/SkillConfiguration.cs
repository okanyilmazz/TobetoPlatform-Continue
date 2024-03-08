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
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: qt => qt.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: a => a.Name, name: "UK_Name").IsUnique();

            builder.HasMany(s => s.AccountSkills);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}