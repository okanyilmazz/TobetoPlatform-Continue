using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CompetenceCategoryConfiguration : IEntityTypeConfiguration<CompetenceCategory>
{
    public void Configure(EntityTypeBuilder<CompetenceCategory> builder)
    {
        builder.ToTable("CompetenceCategories").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");

        builder.HasMany(e => e.CompetenceQuestions);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}