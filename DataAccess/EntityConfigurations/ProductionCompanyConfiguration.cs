using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ProductionCompanyConfiguration : IEntityTypeConfiguration<ProductionCompany>
    {

        public void Configure(EntityTypeBuilder<ProductionCompany> builder)
        {
            builder.ToTable("ProductionCompanies").HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: p => p.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: p => p.Name, name: "UK_Name").IsUnique();

            builder.HasMany(pc => pc.Lessons)
                .WithOne(l => l.ProductionCompany)
                .HasForeignKey(l => l.ProductionCompanyId);

            builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        }
    }
}