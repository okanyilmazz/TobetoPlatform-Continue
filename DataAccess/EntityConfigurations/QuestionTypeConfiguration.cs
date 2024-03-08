using System;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable("QuestionTypes").HasKey(qt => qt.Id);

            builder.Property(qt => qt.Id).HasColumnName("Id").IsRequired();
            builder.Property(qt => qt.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: qt => qt.Id, name: "UK_Id").IsUnique();
            builder.HasIndex(indexExpression: qt => qt.Name, name: "UK_Name").IsUnique();


            builder.HasMany(qt => qt.Questions)
            .WithOne(q => q.QuestionType)
            .HasForeignKey(q => q.QuestionTypeId);

            builder.HasQueryFilter(qt => !qt.DeletedDate.HasValue);
        }
    }
}