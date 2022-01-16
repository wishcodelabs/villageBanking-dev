using VBMS.Infrastructure.Data;

namespace VBMS.Extensions;

internal static class ServiceCollectionExtensions
{

    internal static IServiceCollection AddServerServices(this IServiceCollection services)
    {
        services
            .AddDatabaseDeveloperPageExceptionFilter()
            .AddIdentity()
            .AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole",
                     policy => policy.RequireRole("GroupAdmin"));
            })
            .AddInfrastructureServices()
            .AddMudServices(configuration =>
            {
                configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomEnd;
                configuration.SnackbarConfiguration.HideTransitionDuration = 1000;
                configuration.SnackbarConfiguration.ClearAfterNavigation = false;
                configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
                configuration.SnackbarConfiguration.VisibleStateDuration = 5000;
                configuration.SnackbarConfiguration.NewestOnTop = true;
                configuration.SnackbarConfiguration.MaximumOpacity = 100;
                configuration.SnackbarConfiguration.ShowCloseIcon = true;
            })
        .AddTransient<IUploadService, UploadService>()
        .AddTransient<IUserRegisterService, UserRegisterService>()
        .AddTransient<IUserService, UserService>()
        .AddSyncfusionBlazor()
        .AddRazorPages();


        return services;
    }
    static IServiceCollection AddIdentity(this IServiceCollection services)
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


}
