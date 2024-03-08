using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

internal class OccupationConfiguration : IEntityTypeConfiguration<Occupation>
{
    public void Configure(EntityTypeBuilder<Occupation> builder)
    {
        builder.ToTable("Occupations").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.Name).HasColumnName("Name").IsRequired();

        builder.HasIndex(indexExpression: o => o.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: o => o.Name, name: "UK_Name").IsUnique();


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
