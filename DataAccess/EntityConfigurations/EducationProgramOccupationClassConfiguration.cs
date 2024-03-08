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
    public class EducationProgramOccupationClassConfiguration : IEntityTypeConfiguration<EducationProgramOccupationClass>
    {
        public void Configure(EntityTypeBuilder<EducationProgramOccupationClass> builder)
        {
            builder.ToTable("EducationProgramOccupationClasses").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.EducationProgramId).HasColumnName("EducationProgramId").IsRequired();
            builder.Property(e => e.OccupationClassId).HasColumnName("OccupationClassId").IsRequired();


            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();


            builder.HasOne(epoc => epoc.OccupationClass)
                .WithMany(oc => oc.EducationProgramOccupationClasses)
                .HasForeignKey(epoc => epoc.OccupationClassId);

            builder.HasOne(epoc => epoc.EducationProgram)
              .WithMany(ep => ep.EducationProgramOccupationClasses)
              .HasForeignKey(epoc => epoc.EducationProgramId);


            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
        }
    }
}