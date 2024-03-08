using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class EducationProgramLikeConfiguration : IEntityTypeConfiguration<EducationProgramLike>
{
    public void Configure(EntityTypeBuilder<EducationProgramLike> builder)
    {
        builder.ToTable("EducationProgramLikes").HasKey(epl => epl.Id);

        builder.Property(epl => epl.Id).HasColumnName("Id").IsRequired();
        builder.Property(epl => epl.AccountId).HasColumnName("AccountId").IsRequired();
        builder.Property(epl => epl.EducationProgramId).HasColumnName("EducationProgramId").IsRequired();

        builder.HasIndex(indexExpression: epl => epl.Id, name: "UK_Id").IsUnique();

        builder.HasOne(epl => epl.Account);
        builder.HasOne(epl => epl.EducationProgram);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}
