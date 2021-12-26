

namespace VBMS.Infrastructure.Services.Identity
{
    public class UserService : IUserService
    {
        readonly UserManager<User> userManager;
        readonly ILogger<UserService> logger;
        readonly IUserStore<User> userStore;
        readonly RoleManager<User> roleManager;
        readonly SignInManager<User> signInManager;

        public UserService(UserManager<User> userManager,
                           ILogger<UserService> logger,
                           RoleManager<User> roleManager,
                           SignInManager<User> signInManager,
                           IUserStore<User> userStore
            )
        {
            this.userManager = userManager;
            this.userStore = userStore;
            this.logger = logger;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public Task<Result> RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
