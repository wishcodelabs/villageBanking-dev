namespace VBMS.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddCurrentUserService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor()
                    .AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }
        internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {

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
        internal static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options =>
             {
                 options.Password.RequiredLength = 6;
                 options.Password.RequireDigit = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase = false;
                 options.User.RequireUniqueEmail = true;
             })
                    .AddEntityFrameworkStores<SystemDbContext>()
                    .AddDefaultTokenProviders();
            return services;
        }

        internal static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddTransient<IUnitOfWork<int>, UnitOfWork<int>>()
                    .AddTransient<LoanService>()
                    .AddTransient<GroupMemberRoleService>()
                    .AddTransient<GroupMemberShareService>()
                    .AddTransient<LoanApplicantService>()
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


            services.AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomEnd;
                configuration.SnackbarConfiguration.HideTransitionDuration = 1000;
                configuration.SnackbarConfiguration.ClearAfterNavigation = false;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.VisibleStateDuration = 5000;
                configuration.SnackbarConfiguration.NewestOnTop = true;
                configuration.SnackbarConfiguration.MaximumOpacity = 100;
                configuration.SnackbarConfiguration.ShowCloseIcon = true;
            });

            return services;
        }
        internal static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRegisterService, UserRegisterService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }

    }
}
