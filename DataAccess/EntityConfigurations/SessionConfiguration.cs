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
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions").HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.LessonId).HasColumnName("LessonId");
            builder.Property(s => s.StartDate).HasColumnName("StartDate");
            builder.Property(s => s.EndDate).HasColumnName("EndDate");
            builder.Property(s => s.RecordPath).HasColumnName("RecordPath");

            builder.HasIndex(indexExpression: qt => qt.Id, name: "UK_Id").IsUnique();

            builder.HasOne(s => s.Lesson)
                .WithMany(s => s.Sessions)
                .HasForeignKey(s => s.LessonId);


            builder.HasMany(s => s.AccountSessions);

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
