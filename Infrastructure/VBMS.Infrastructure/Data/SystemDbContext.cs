

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
            var userName = await currentUserService.GetUserName();
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    entry.Entity.CreatedBy ??= userName;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy ??= userName;
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
                .WithMany(p => p.RoleClaims)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<IdentityUserToken<int>>(entity =>
        {
            entity.ToTable("UserTokens", "Identity");
            entity.HasKey(nameof(IdentityUserToken<int>.UserId), nameof(IdentityUserToken<int>.LoginProvider), nameof(IdentityUserToken<int>.Name));
        });

        #endregion

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.ToTable("Loans");
        });
        modelBuilder.Entity<LoanApplication>(entity =>
        {
            entity.ToTable("LoanApplications");
        });
        modelBuilder.Entity<Investment>(e =>
        {
            e.ToTable("Investments");
        });
        modelBuilder.Entity<LoanPayment>(e =>
        {
            e.ToTable("LoanPayments");
        });
        modelBuilder.Entity<InvestmentPeriod>(e =>
        {
            e.ToTable("InvestmentPeriods");
        });
        modelBuilder.Entity<VillageGroupMembership>(e =>
        {
            e.ToTable("Membership");
            e.OwnsOne(e => e.PersonalDetails, p =>
            {
                p.ToTable("MemberPersonalDetails");
                p.OwnsOne(p => p.PhysicalAddress, a =>
                {
                    a.ToTable("MemberAddresses");
                    a.Property<int>("OwnerId");
                    a.WithOwner();

                })
                .WithOwner(p => p.Owner);

            });
        });
        modelBuilder.Entity<LoanType>(e =>
        {
            e.ToTable("LoanTypes");
        });
        modelBuilder.Entity<LoanInterestRate>(e =>
        {
            e.ToTable("LoanInterestRates");
        });
        modelBuilder.Entity<VillageBankGroup>(e =>
        {
            e.ToTable("VillageBankGroups");
            e.HasMany(e => e.Admins)
             .WithOne(a => a.Group).HasForeignKey(a => a.GroupId);
        });
        modelBuilder.Entity<GroupAdmin>(e =>
        {

            e.ToTable("GroupAdmins");
        });
        modelBuilder.Entity<VillageGroupMemberRole>(e =>
        {
            e.ToTable("GroupMemberRoles");
        });
        modelBuilder.Entity<MembershipSubscription>(e =>
        {
            e.ToTable("MemberSubscriptions");
        });
        modelBuilder.Entity<City>(e =>
        {
            e.ToTable("Cities");
        });
        modelBuilder.Entity<Province>(e =>
        {
            e.ToTable("Provinces");
        });
    }

}
