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
    public class LessonSubTypeConfiguration : IEntityTypeConfiguration<LessonSubType>
    {
        public void Configure(EntityTypeBuilder<LessonSubType> builder)
        {
            builder.ToTable("LessonSubTypes").HasKey(c => c.Id);

            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
