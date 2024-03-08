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
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedias").HasKey(s => s.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.Name).HasColumnName("Name").IsRequired();
            builder.Property(s => s.IconPath).HasColumnName("IconPath").IsRequired();

            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: a => a.Name, name: "UK_Name").IsUnique();

            builder.HasMany(sm => sm.AccountSocialMedias);

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
