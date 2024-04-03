using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class MediaNewConfiguration : IEntityTypeConfiguration<MediaNew>
{
    public void Configure(EntityTypeBuilder<MediaNew> builder)
    {
        builder.ToTable("MediaNews").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Title).HasColumnName("Title").IsRequired();
        builder.Property(m => m.Description).HasColumnName("Description").IsRequired();
        builder.Property(m => m.ReleaseDate).HasColumnName("ReleaseDate").IsRequired();

        builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}