
namespace VBMS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWorkerServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork<int>, UnitOfWork<int>>()
               .AddSingleton<LoanService>();

            return services;
        }
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork<int>, UnitOfWork<int>>()
                .AddTransient<LoanService>()
                .AddTransient<GroupMemberRoleService>()
                .AddTransient<GroupMemberShareService>()
                .AddTransient<LoanApplicationService>()
                .AddTransient<LoanTypeService>()
                .AddTransient<LoanPaymentService>()
                .AddTransient<LoanInterestRateService>()
                .AddTransient<MembershipSubscriptionService>()
                .AddTransient<VillageBankGroupService>()
                .AddTransient<InvestmentPeriodService>()
                .AddTransient<InvestmentService>()
                .AddTransient<GroupAdminService>()
                .AddTransient<IDashboardService, DashboardService>()
                .AddTransient<CityService>()
                .AddTransient<ProvinceService>()
                .AddTransient<MembershipService>();


            return services;
        }

        public static IServiceCollection AddSingletonDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor()
                   .AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddDbContext<SystemDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options2 =>
                {
                    options2.MigrationsAssembly("VBMS.Infrastructure");
                    options2.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);

                });

            }, ServiceLifetime.Singleton);
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor()
                   .AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddDbContext<SystemDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options2 =>
                {
                    options2.MigrationsAssembly("VBMS.Infrastructure");
                    options2.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);

                });

            }, ServiceLifetime.Transient);
            return services;
        }


    }
}
