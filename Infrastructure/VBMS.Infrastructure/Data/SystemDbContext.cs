

namespace VBMS.Infrastructure.Data;

public class SystemDbContext : DbContext
{
#nullable disable
    readonly ICurrentUserService currentUserService;
    public SystemDbContext(DbContextOptions<SystemDbContext> options, ICurrentUserService _currentUserService) : base(options)
    {
        currentUserService = _currentUserService;
    }
    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanInterestRate> LoanInterestRates { get; set; }

    public virtual DbSet<InvestmentPeriod> InvestmentsPeriods { get; set; }

    public virtual DbSet<LoanType> LoanTypes { get; set; }

    public virtual DbSet<VillageBankGroup> VillageBankGroups { get; set; }

    public virtual DbSet<VillageGroupMembership> VillageGroupMembers { get; set; }

    public virtual DbSet<VillageGroupMemberShare> VillageGroupMemberShares { get; set; }
    public virtual DbSet<LoanPayment> LoanPayments { get; set; }
    public virtual DbSet<PersonalDetails> PersonalDetails { get; set; }
    public virtual DbSet<MembershipSubscription> MembershipSubscriptions { get; set; }
    public virtual DbSet<Applicant> Applicants { get; set; }
    public virtual DbSet<Investment> Investments { get; set; }
    public virtual DbSet<MembershipRole> MembershipRoles { get; set; }
    public virtual DbSet<VillageGroupMemberRole> VillageGroupMemberRoles { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                    entry.Entity.CreatedBy = currentUserService.GetUserId();
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = currentUserService.GetUserId();
                    break;
                default:
                    break;
            }


        }
        return await base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        foreach (var property in modelBuilder.Model.GetEntityTypes()
                 .SelectMany(entity => entity.GetProperties())
                 .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Loan>()
                    .Property(l => l.Status)
                    .HasConversion<int>();
        modelBuilder.Entity<PersonalDetails>()
                    .Property(p => p.Gender)
                    .HasConversion<int>();
        modelBuilder.Entity<PersonalDetails>()
                    .Property(p => p.MaritalStatus)
                    .HasConversion<int>();
        modelBuilder.Entity<VillageGroupMemberRole>()
                    .Property(mr => mr.Role)
                    .HasConversion<int>();
        modelBuilder.Entity<VillageGroupMembership>()
                    .Property(m => m.Status)
                    .HasConversion<int>();
        modelBuilder.Entity<MembershipSubscription>()
                    .Property(mr => mr.Subscription)
                    .HasConversion<int>();
        modelBuilder.Entity<LoanPayment>()
                    .Property(lp => lp.PaymentMethod)
                    .HasConversion<int>();
        modelBuilder.Entity<MembershipRole>()
                    .Property(r => r.RoleId)
                    .HasConversion<int>();
        /*Enum Seeding*/
        modelBuilder.Entity<MembershipRole>()
                    .HasData(Enum.GetValues(typeof(MembershipRole)).Cast<VillageGroupRole>()
                                 .Select(e => new MembershipRole()
                                 {
                                     RoleId = e,
                                     RoleName = e.ToString()
                                 }));
    }

}
