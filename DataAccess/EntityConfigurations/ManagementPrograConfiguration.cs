using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ManagementProgramConfiguration : IEntityTypeConfiguration<ManagementProgram>
{
    public void Configure(EntityTypeBuilder<ManagementProgram> builder)
    {
        builder.ToTable("ManagementPrograms").HasKey(mp => mp.Id);

        builder.Property(mp => mp.Name).HasColumnName("Name").IsRequired();

        builder.HasIndex(indexExpression: mp => mp.Id, name: "UK_Id").IsUnique();

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
