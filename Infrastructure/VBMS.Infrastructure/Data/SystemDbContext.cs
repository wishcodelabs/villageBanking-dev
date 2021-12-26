

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using VBMS.Domain.SeedWork.Contracts;
using VBMS.Infrastructure.Models.Identity;

namespace VBMS.Infrastructure.Data;

public class SystemDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, RoleClaim, IdentityUserToken<int>>
{

    readonly ICurrentUserService currentUserService;
    public SystemDbContext(DbContextOptions<SystemDbContext> options, ICurrentUserService _currentUserService) : base(options)
    {
        currentUserService = _currentUserService;
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    entry.Entity.CreatedBy = await currentUserService.GetUserName();
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = await currentUserService.GetUserName();
                    break;
                default:
                    break;
            }


        }
        return await base.SaveChangesAsync(cancellationToken);
    }
    protected override void ConfigureConventions(
      ModelConfigurationBuilder configurationBuilder)
    {
        // Pre-convention model configuration goes here
        configurationBuilder.Properties<Enum>()
                            .HaveConversion<int>();
        configurationBuilder.Properties<decimal>()
            .HaveColumnType("decimal(18,2)");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        #region Identity
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "Identity");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable(name: "Roles", "Identity");
        });

        modelBuilder.Entity<IdentityUserRole<int>>(entity =>
        {
            entity.ToTable("UserRoles", "Identity");
            entity.HasKey(nameof(IdentityUserRole<int>.UserId), nameof(IdentityUserRole<int>.RoleId));
        });
        modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
        {
            entity.ToTable("UserClaims", "Identity");
        });
        modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
        {
            entity.ToTable("UserLogins", "Identity");
            entity.HasKey(nameof(IdentityUserLogin<int>.LoginProvider), nameof(IdentityUserLogin<int>.ProviderKey));
        });
        modelBuilder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable(name: "RoleClaims", "Identity");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.Claims)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<IdentityUserToken<int>>(entity =>
        {
            entity.ToTable("UserTokens", "Identity");
            entity.HasKey(nameof(IdentityUserToken<int>.UserId), nameof(IdentityUserToken<int>.LoginProvider), nameof(IdentityUserToken<int>.Name));
        });

        #endregion

        /*Enum Seedings*/
        modelBuilder.Entity<MembershipRole>()
                    .HasData(Enum.GetValues(typeof(MembershipRole)).Cast<VillageGroupRole>()
                                 .Select(e => new MembershipRole()
                                 {
                                     RoleId = e,
                                     RoleName = e.ToString()
                                 }));
    }

}
