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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions").HasKey(b => b.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
            builder.Property(b => b.OptionA).HasColumnName("OptionA");
            builder.Property(b => b.OptionB).HasColumnName("OptionB");
            builder.Property(b => b.OptionC).HasColumnName("OptionC");
            builder.Property(b => b.OptionD).HasColumnName("OptionD");
            builder.Property(b => b.CorrectOption).HasColumnName("CorrectOption").IsRequired();

            builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();

            builder.HasOne(qt => qt.QuestionType)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.QuestionTypeId);

            builder.HasMany(q => q.ExamQuestions);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}