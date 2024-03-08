using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CompetenceTestConfiguration : IEntityTypeConfiguration<CompetenceTest>
{
    public void Configure(EntityTypeBuilder<CompetenceTest> builder)
    {
        builder.ToTable("CompetenceTests").HasKey(b => b.Id);

        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
        builder.Property(b => b.QuestionCount).HasColumnName("QuestionCount").IsRequired();


        builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();


        builder.HasMany(e => e.CompetenceTestQuestions);
        builder.HasMany(e => e.AccountCompetenceTests);


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
