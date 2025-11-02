using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartLearn.Domain.Entities;

namespace SmartLearn.Infrastructure.Persistence.Configs;

public static class EntitiesNaming
{
    public static void ChangeEntitiesNaming(this ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("Users");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
    }
}