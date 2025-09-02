using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.Identity;

public class IdentityUserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("IdentityUser");
        
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.NormalizedUserName).IsUnique();
        
        builder.HasIndex(x => x.NormalizedEmail).IsUnique();

        builder.Property(x => x.Email)
            .HasMaxLength(180)
            .IsRequired();
        
        builder.Property(x => x.NormalizedEmail)
            .HasMaxLength(180);
        
        builder.Property(x => x.UserName)
            .HasMaxLength(180)
            .IsRequired();
        
        builder.Property(x => x.NormalizedUserName)
            .HasMaxLength(180);
        
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();

        builder.HasMany<IdentityUserClaim<long>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
        builder.HasMany<IdentityUserLogin<long>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
        builder.HasMany<IdentityUserToken<long>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
        builder.HasMany<IdentityUserRole<long>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
    }
}