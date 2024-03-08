using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CompetenceTestQuestionConfiguration : IEntityTypeConfiguration<CompetenceTestQuestion>
{
    public void Configure(EntityTypeBuilder<CompetenceTestQuestion> builder)
    {
        builder.ToTable("CompetenceTestQuestions").HasKey(ctq => ctq.Id);

        builder.Property(ctq => ctq.Id).HasColumnName("Id").IsRequired();
        builder.Property(ctq => ctq.CompetenceQuestionId).HasColumnName("CompetenceQuestionId").IsRequired();
        builder.Property(ctq => ctq.CompetenceTestId).HasColumnName("CompetenceTestId").IsRequired();

        builder.HasIndex(indexExpression: ctq => ctq.Id, name: "UK_Id").IsUnique();

        builder.HasOne(eq => eq.CompetenceTest)
            .WithMany(e => e.CompetenceTestQuestions)
            .HasForeignKey(eq => eq.CompetenceTestId);

        builder.HasOne(eq => eq.CompetenceQuestion)
            .WithMany(e => e.CompetenceTestQuestions)
            .HasForeignKey(eq => eq.CompetenceQuestionId);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}