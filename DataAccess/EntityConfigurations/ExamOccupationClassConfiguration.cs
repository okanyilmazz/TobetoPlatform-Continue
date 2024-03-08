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
    public class ExamOccupationClassConfiguration : IEntityTypeConfiguration<ExamOccupationClass>
    {
        public void Configure(EntityTypeBuilder<ExamOccupationClass> builder)
        {
            builder.ToTable("ExamOccupationClasses").HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
            builder.Property(r => r.ExamId).HasColumnName("ExamId").IsRequired();
            builder.Property(r => r.OccupationClassId).HasColumnName("OccupationClassId").IsRequired();

            builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();

            builder.HasOne(eoc => eoc.OccupationClass)
                .WithMany(oc => oc.ExamOccupationClasses)
                .HasForeignKey(eoc => eoc.OccupationClassId);

            builder.HasOne(eoc => eoc.Exam)
                .WithMany(e => e.ExamOccupationClasses)
                .HasForeignKey(eoc => eoc.ExamId);

            builder.HasQueryFilter(q => !q.DeletedDate.HasValue);
        }
    }
}