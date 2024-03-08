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
    public class LessonCategoryConfiguration : IEntityTypeConfiguration<LessonCategory>
    {
        public void Configure(EntityTypeBuilder<LessonCategory> builder)
        {
            builder.ToTable("LessonCategories").HasKey(c => c.Id);

            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
