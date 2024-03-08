using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AccountBadgeConfiguration : IEntityTypeConfiguration<AccountBadge>
{
    public void Configure(EntityTypeBuilder<AccountBadge> builder)
    {
        builder.ToTable("AccountBadges").HasKey(ab => ab.Id);
        builder.Property(ab => ab.Id).HasColumnName("Id").IsRequired();
        builder.Property(ab => ab.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(ab => ab.BadgeId).HasColumnName("BadgeId").IsRequired();

        builder.HasIndex(indexExpression: ab => ab.Id, name: "UK_Id").IsUnique();


        builder.HasOne(ab => ab.Account)
            .WithMany(ab => ab.AccountBadges)
            .HasForeignKey(ab => ab.AccountId);

        builder.HasOne(ab => ab.Badge)
            .WithMany(ab => ab.AccountBadges)
            .HasForeignKey(ab => ab.BadgeId);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

    }
}