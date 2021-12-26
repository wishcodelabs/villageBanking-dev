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
        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)userStore;
        }
    }
}
