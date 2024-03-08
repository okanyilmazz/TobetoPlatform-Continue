using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AnnouncementReadConfiguration : IEntityTypeConfiguration<AnnouncementRead>
{
    public void Configure(EntityTypeBuilder<AnnouncementRead> builder)
    {
        builder.ToTable("AnnouncementReads").HasKey(b => b.Id);

        builder.Property(ar => ar.Id).HasColumnName("Id").IsRequired();
        builder.Property(ar => ar.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(ar => ar.AnnouncementId).HasColumnName("AnnouncementId").IsRequired();

        builder.HasOne(ar => ar.Announcement)
            .WithMany(a => a.AnnouncementReads)
            .HasForeignKey(a => a.AnnouncementId);


        builder.HasOne(ap => ap.Announcement)
            .WithMany(p => p.AnnouncementReads)
            .HasForeignKey(ap => ap.AnnouncementId);


        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
