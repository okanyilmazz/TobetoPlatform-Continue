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
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {

        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages").HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.Property(l => l.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

            builder.HasMany(l => l.AccountLanguages);

            builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
        }
    }
}
