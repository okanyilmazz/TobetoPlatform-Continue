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
    public class OccupationClassConfiguration : IEntityTypeConfiguration<OccupationClass>

    {
        public void Configure(EntityTypeBuilder<OccupationClass> builder)
        {
            builder.ToTable("OccupationClasses").HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: p => p.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: p => p.Name, name: "UK_Name").IsUnique();


            //builder.HasMany(oc => oc.Homeworks)
            //    .WithOne(h => h.OccupationClass)
            //    .HasForeignKey(h => h.OccupationClassId);

            //builder.HasMany(oc => oc.Sessions)
            //    .WithOne(s => s.OccupationClass)
            //    .HasForeignKey(h => h.OccupationClassId);

            builder.HasMany(oc => oc.EducationProgramOccupationClasses);
            builder.HasMany(oc => oc.ExamOccupationClasses);
            builder.HasMany(oc => oc.AccountOccupationClasses);
            builder.HasMany(oc => oc.OccupationClassSurveys);



            builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        }
    }
}