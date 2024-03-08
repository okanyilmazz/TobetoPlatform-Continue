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
    public class AccountLanguageConfiguration : IEntityTypeConfiguration<AccountLanguage>
    {
        public void Configure(EntityTypeBuilder<AccountLanguage> builder)
        {
            builder.ToTable("AccountLanguages").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(a => a.LanguageId).HasColumnName("LanguageId").IsRequired();
            builder.Property(a => a.LanguageLevelId).HasColumnName("LanguageLevelId").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


            builder.HasOne(al => al.Account)
                .WithMany(a => a.AccountLanguages)
                .HasForeignKey(al => al.AccountId);

            builder.HasOne(al => al.Language)
                .WithMany(l => l.AccountLanguages)
                .HasForeignKey(al => al.LanguageId);

            builder.HasOne(al => al.LanguageLevel);


            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
