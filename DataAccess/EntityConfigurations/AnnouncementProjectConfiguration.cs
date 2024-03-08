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
    public class AnnouncementProjectConfiguration : IEntityTypeConfiguration<AnnouncementProject>
    {
        public void Configure(EntityTypeBuilder<AnnouncementProject> builder)
        {
            builder.ToTable("AnnouncementProjects").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.ProjectId).HasColumnName("ProjectId").IsRequired();
            builder.Property(a => a.AnnouncementId).HasColumnName("AnnouncementId").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasOne(ap => ap.Project)
                .WithMany(p => p.AnnouncementProjects)
                .HasForeignKey(ap => ap.ProjectId);

            builder.HasOne(ap => ap.Announcement)
               .WithMany(p => p.AnnouncementProjects)
               .HasForeignKey(ap => ap.AnnouncementId);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
