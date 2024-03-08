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
    public class AccountOccupationClassConfiguration : IEntityTypeConfiguration<AccountOccupationClass>
    {
        public void Configure(EntityTypeBuilder<AccountOccupationClass> builder)
        {
            builder.ToTable("AccountOccupationClasses").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.OccupationClassId).HasColumnName("OccupationClassId").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasOne(aoc => aoc.OccupationClass)
                .WithMany(oc => oc.AccountOccupationClasses)
                .HasForeignKey(aoc => aoc.OccupationClassId);

            builder.HasOne(aoc => aoc.Account)
                .WithMany(a => a.AccountOccupationClasses)
                .HasForeignKey(aoc => aoc.AccountId);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
