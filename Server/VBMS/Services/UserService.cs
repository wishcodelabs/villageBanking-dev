

using IResult = VBMS.Domain.Responses.IResult;

namespace VBMS.Services
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

        public async Task<IResult<Guid>> LoginAsync(TokenRequest<User> token)
        {
            try
            {
                var user = await userManager.FindByNameAsync(token.UserName);
                if (user == null)
                {
                    return await Result<Guid>.FailAsync("User not found.");
                }
                if (await signInManager.CanSignInAsync(user))
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, token.Password, true);
                    if (result.Succeeded)
                    {
                        var key = SignInMiddleware<User>.AnnounceLogin(token);
                        return await Result<Guid>.SuccessAsync(key);
                    }
                    else
                    {
                        return await Result<Guid>.FailAsync("Incorrect Credentials.");
                    }
                }
                else
                {
                    return await Result<Guid>.FailAsync("Your Account Is Blocked. Please contact your group admin");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message + e.StackTrace);
                return await Result<Guid>.FailAsync("An Error Occured. Please Try Again");
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
        public async Task<Guid> GetGuid(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user.UserGuid;
        }

        public async Task<string> GetFullName(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            return user?.FirstName + " " + user?.LastName;
        }


        public Task<IResult> ResetPassword(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(Guid guid)
        {
            return await userManager.Users.FirstOrDefaultAsync(u => u.UserGuid == guid);
        }
        public async Task<List<string>> GetMyRoles(User user)
        {
            var list = new List<string>();
            foreach (var role in roleManager.Roles)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    list.Add(role.Name);
                }
            }
            return list;

        }
        public async Task<bool> DeleteUser(Guid guid)
        {
            var user = await GetUserAsync(guid);
            if (user != null)
            {
                try
                {
                    var r = await userManager.RemoveFromRolesAsync(user, await GetMyRoles(user));
                    var result = await userManager.DeleteAsync(user);

                    return r.Succeeded && result.Succeeded;
                }
                catch
                {

                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
