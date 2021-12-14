

namespace VBMS.Infrastructure.Data;

public class SystemDbContext : DbContext
{
#nullable disable
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
                    entry.Entity.CreatedBy = currentUserService.GetUserName();
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = currentUserService.GetUserName();
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

        foreach (var property in modelBuilder.Model.GetEntityTypes()
                 .SelectMany(entity => entity.GetProperties())
                 .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }
        base.OnModelCreating(modelBuilder);

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
