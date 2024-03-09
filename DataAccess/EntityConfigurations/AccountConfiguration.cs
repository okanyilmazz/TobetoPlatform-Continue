using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(a => a.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(a => a.NationalId).HasColumnName("NationalId");
        builder.Property(a => a.Description).HasColumnName("Description");
        builder.Property(a => a.BirthDate).HasColumnName("BirthDate");
        builder.Property(a => a.ProfilePhotoPath).HasColumnName("ProfilePhotoPath");

        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: a => a.UserId, name: "UK_UserId").IsUnique();


        builder.HasOne(a => a.User);

        builder.HasMany(au => au.AccountUniversities);
        builder.HasMany(al => al.AccountLanguages);
        builder.HasMany(awl => awl.AccountSocialMedias);
        builder.HasMany(ah => ah.AccountHomeworks);
        builder.HasMany(al => al.AccountLessons);
        builder.HasMany(aoc => aoc.AccountOccupationClasses);
        builder.HasMany(ase => ase.AccountSessions);
        builder.HasMany(ask => ask.AccountSkills);
        builder.HasMany(ask => ask.AccountEducationPrograms);
        builder.HasMany(we => we.WorkExperiences);
        builder.HasMany(c => c.Certificates);
        builder.HasMany(ab => ab.AccountBadges);
        builder.HasMany(ll => ll.LessonLikes);
        builder.HasMany(s => s.AnnouncementReads);


        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
