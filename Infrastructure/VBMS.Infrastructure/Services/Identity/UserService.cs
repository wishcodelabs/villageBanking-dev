namespace VBMS.Infrastructure.Services.Identity
{
    public class UserService : IUserService
    {
        readonly UserManager<User> userManager;
        readonly ILogger<UserService> logger;
        readonly SignInManager<User> signInManager;
        readonly RoleManager<Role> roleManager;
        public UserService(UserManager<User> _userManager, ILogger<UserService> _logger, RoleManager<Role> _roleManager, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            logger = _logger;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }

        public async Task<IResult> LoginAsync(TokenRequest token)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(token.Email);
                if (user == null)
                {
                    return await Result.FailAsync("User not found.");
                }
                var result = await signInManager.PasswordSignInAsync(user, token.Password, token.RememberMe, false);
                if (result.Succeeded)
                {
                    return Result.Success($"Welcome {user.FirstName} {user.LastName}");
                }
                else
                {
                    return await Result.FailAsync("Incorrect Credentials.");
                }
            }
            catch (Exception)
            {

                return await Result.FailAsync("An Error Occured. Please Try Again");
            }
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<int> GetCount()
        {
            var users = await userManager.Users.ToListAsync();
            return users.Count;
        }

        public Task<List<RoleClaim>> GetRoleClaims(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetRoles(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var myRoles = new List<Role>();
            var roles = await roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    myRoles.Add(role);
                }
            }
            return myRoles;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public Task<string> GetUserName(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> ResetPassword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
