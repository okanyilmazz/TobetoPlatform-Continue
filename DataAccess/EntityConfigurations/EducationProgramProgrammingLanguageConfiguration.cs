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
    public class EducationProgramProgrammingLanguageConfiguration : IEntityTypeConfiguration<EducationProgramProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<EducationProgramProgrammingLanguage> builder)
        {
            builder.ToTable("EducationProgramProgrammingLanguages").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.Id).HasColumnName("EducationProgramId").IsRequired();
            builder.Property(e => e.Id).HasColumnName("ProgrammingLanguageId").IsRequired();


            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();


            builder.HasOne(eppl => eppl.ProgrammingLanguage)
                .WithMany(pl => pl.EducationProgramProgrammingLanguages)
                .HasForeignKey(eppl => eppl.ProgrammingLanguageId);

            builder.HasOne(eppl => eppl.EducationProgram)
                 .WithMany(pl => pl.EducationProgramProgrammingLanguages)
                 .HasForeignKey(eppl => eppl.EducationProgramId);

            builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
        }
    }
}