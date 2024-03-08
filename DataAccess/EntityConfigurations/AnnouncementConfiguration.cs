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
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcements").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.Title).HasColumnName("Title").IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
            builder.Property(a => a.AnnouncementDate).HasColumnName("AnnouncementDate").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasMany(s => s.AnnouncementProjects);
            builder.HasMany(s => s.AnnouncementReads);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
