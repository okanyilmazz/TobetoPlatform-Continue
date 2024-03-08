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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(c => c.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(c => c.Email).HasColumnName("Email").IsRequired();
            builder.Property(c => c.Message).HasColumnName("Message").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
