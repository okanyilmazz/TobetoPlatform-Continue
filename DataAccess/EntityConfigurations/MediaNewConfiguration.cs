using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class MediaNewConfiguration : IEntityTypeConfiguration<MediaNew>
    {
        public void Configure(EntityTypeBuilder<MediaNew> builder)
        {
            builder.ToTable("MediaNews").HasKey(m => m.Id);

            builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
            builder.Property(m => m.Title).HasColumnName("Title").IsRequired();
            builder.Property(m => m.Description).HasColumnName("Description").IsRequired();
            builder.Property(m => m.ThumbnailPath).HasColumnName("ThumbnailPath").IsRequired();
            builder.Property(m => m.ReleaseDate).HasColumnName("ReleaseDate").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}