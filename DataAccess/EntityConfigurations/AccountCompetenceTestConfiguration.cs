using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AccountCompetenceTestConfiguration : IEntityTypeConfiguration<AccountCompetenceTest>
{
    public void Configure(EntityTypeBuilder<AccountCompetenceTest> builder)
    {
        builder.ToTable("AccountCompetenceTests").HasKey(ab => ab.Id);
        builder.Property(ab => ab.Id).HasColumnName("Id").IsRequired();
        builder.Property(ab => ab.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(ab => ab.CompetenceTestId).HasColumnName("CompetenceTestId").IsRequired();

        builder.HasIndex(indexExpression: ab => ab.Id, name: "UK_Id").IsUnique();

        //builder.HasOne(ab => ab.Account)
        //  .WithMany(ab => ab.AccountCompetenceTests)
        //  .HasForeignKey(ab => ab.AccountId);

        //builder.HasOne(ab => ab.CompetenceTest)
        //    .WithMany(ab => ab.AccountCompetenceTests)
        //    .HasForeignKey(ab => ab.CompetenceTestId);



        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

    }
}
