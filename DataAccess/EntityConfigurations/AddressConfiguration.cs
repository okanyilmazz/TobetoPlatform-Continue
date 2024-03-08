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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses").HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId");
            builder.Property(a => a.CityId).HasColumnName("CityId");
            builder.Property(a => a.CountryId).HasColumnName("CountryId");
            builder.Property(a => a.DistrictId).HasColumnName("DistrictId");
            builder.Property(a => a.AddressDetail).HasColumnName("AddressDetail").IsRequired();


            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

            builder.HasOne(a => a.City);
            builder.HasOne(a => a.District);
            builder.HasOne(a => a.Country);
            builder.HasOne(a => a.Account);



            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
