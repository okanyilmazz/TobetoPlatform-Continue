using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class MediaNewImageConfiguration : IEntityTypeConfiguration<MediaNewImage>
{
    public void Configure(EntityTypeBuilder<MediaNewImage> builder)
    {
        builder.ToTable("MediaNewImages").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.MediaNewId).HasColumnName("MediaNewId").IsRequired();
        builder.Property(b => b.ImagePath).HasColumnName("ImagePath").IsRequired();

        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

        builder.HasOne(b => b.MediaNew);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
