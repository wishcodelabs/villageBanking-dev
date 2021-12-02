

namespace VBMS.Infrastructure.Data;

public class SystemDbContext : DbContext
{
    public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
    {

    }
    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanInterestRate> LoanInterestRates { get; set; }

    public virtual DbSet<InvestmentPeriod> InvestmentsPeriods { get; set; }

    public virtual DbSet<LoanType> LoanTypes { get; set; }

    public virtual DbSet<VillageBankGroup> VillageBankGroups { get; set; }

    public virtual DbSet<VillageGroupMember> VillageGroupMembers { get; set; }

    public virtual DbSet<VillageGroupMemberShare> VillageGroupMemberShares { get; set; }
}
