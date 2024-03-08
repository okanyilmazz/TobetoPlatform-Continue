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
    public class AccountActivityMapConfiguration : IEntityTypeConfiguration<AccountActivityMap>
    {
        public void Configure(EntityTypeBuilder<AccountActivityMap> builder)
        {
            builder.ToTable("AccountActivityMap").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(a => a.ActivityId).HasColumnName("ActivityId").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasOne(ask => ask.Account)
                .WithMany(a => a.ActivityMaps)
                .HasForeignKey(ask => ask.AccountId);

            builder.HasOne(ask => ask.ActivityMap)
                .WithMany(s => s.Accounts)
                .HasForeignKey(ask => ask.ActivityId);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
