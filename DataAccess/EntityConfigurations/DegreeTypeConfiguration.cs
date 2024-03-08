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
    public class DegreeTypeConfiguration : IEntityTypeConfiguration<DegreeType>
    {
        public void Configure(EntityTypeBuilder<DegreeType> builder)
        {
            builder.ToTable("DegreeTypes").HasKey(d => d.Id);

            builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
            builder.Property(d => d.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: d => d.Name, name: "UK_Name").IsUnique();

            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
        }
    }
}
