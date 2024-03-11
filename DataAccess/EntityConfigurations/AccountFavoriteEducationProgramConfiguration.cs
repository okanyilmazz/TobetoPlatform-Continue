using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AccountFavoriteEducationProgramConfiguration : IEntityTypeConfiguration<AccountFavoriteEducationProgram>
{
    public void Configure(EntityTypeBuilder<AccountFavoriteEducationProgram> builder)
    {

        builder.ToTable("AccountFavoriteEducationPrograms").HasKey(afep => afep.Id);
        builder.Property(afep => afep.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(afep => afep.EducationProgramId).HasColumnName("EducationProgramId").IsRequired();


        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();


        builder.HasOne(afep => afep.Account)
            .WithMany(a => a.AccountFavoriteEducationPrograms)
            .HasForeignKey(afep => afep.AccountId);

        builder.HasOne(afep => afep.EducationProgram)
            .WithMany(sm => sm.AccountFavoriteEducationPrograms)
            .HasForeignKey(afep => afep.EducationProgramId);


        builder.HasQueryFilter(afep => !afep.DeletedDate.HasValue);
    }
}
