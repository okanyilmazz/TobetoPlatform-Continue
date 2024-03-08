using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.ToTable("Badges").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.ThumbnailPath).HasColumnName("ThumbnailPath").IsRequired();


        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

        builder.HasMany(au => au.AccountBadges);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}

