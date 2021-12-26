namespace VBMS.Infrastructure.Services.Identity
{
    public class UserRegisterService : IUserRegisterService
    {
        readonly UserManager<User> userManager;
        readonly ILogger<UserRegisterService> logger;
        readonly IUserStore<User> userStore;
        readonly RoleManager<Role> roleManager;
        readonly SignInManager<User> signInManager;
        private readonly IUserEmailStore<User> emailStore;
        const string Basic_Role = "BasicUser";

        public UserRegisterService(UserManager<User> userManager,
                           ILogger<UserRegisterService> logger,
                           RoleManager<Role> roleManager,
                           SignInManager<User> signInManager,
                           IUserStore<User> userStore
            )
        {
            this.userManager = userManager;
            this.userStore = userStore;
            this.logger = logger;
            this.roleManager = roleManager;
            emailStore = GetEmailStore();
            this.signInManager = signInManager;
        }

        public async Task<IResult> RegisterAsync(RegisterRequest request)
        {
            if (request.IsValid)
            {
                var user = CreateUser();
                user.PhoneNumber = request.PhoneNumber;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.MiddleName = request.MiddleName;
                user.EmailConfirmed = request.AutoConfirm;
                await userStore.SetUserNameAsync(user, request.Email, CancellationToken.None);
                await emailStore.SetEmailAsync(user, request.Email, CancellationToken.None);

                var result = await userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    logger.LogInformation("User created a account with password");
                    var roleResult = await roleManager.FindByNameAsync(Basic_Role);
                    var existingUser = await userManager.FindByEmailAsync(request.Email);
                    if (roleResult == null)
                    {
                        await roleManager.CreateAsync(new Role(Basic_Role, "Basic Role For AnyUser"));
                    }
                    else
                    {
                        var uresult = await userManager.IsInRoleAsync(existingUser, Basic_Role);
                        if (!uresult)
                        {
                            await userManager.AddToRoleAsync(existingUser, Basic_Role);
                        }
                    }
                    return await Result.SuccessAsync("Account Created Succesifully");
                }
                else
                {
                    return await Result.FailAsync("Something went wrong..");
                }
            }
            else
            {
                return await Result.FailAsync("The request is not valid");
            }
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
