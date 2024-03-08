using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ActivityMapConfiguration : IEntityTypeConfiguration<ActivityMap>
    {
        public void Configure(EntityTypeBuilder<ActivityMap> builder)
        {
            builder.ToTable("ActivityMaps").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            
            builder.Property(a => a.Date).HasColumnName("Date");
            builder.Property(a => a.Name).HasColumnName("Name");

            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasMany(a => a.Accounts);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}

