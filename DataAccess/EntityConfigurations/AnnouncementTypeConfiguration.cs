using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AnnouncementTypeConfiguration : IEntityTypeConfiguration<AnnouncementType>
{
    public void Configure(EntityTypeBuilder<AnnouncementType> builder)
    {
        builder.ToTable("AnnouncementTypes").HasKey(b => b.Id);

        builder.Property(at => at.Id).HasColumnName("Id").IsRequired();
        builder.Property(at => at.Name).HasColumnName("Name").IsRequired();


        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
