namespace VBMS.Infrastructure.Interfaces
{
    public interface IUserService : IIdentityService
    {
        Task<int> GetCount();

        Task<string> GetUserName(int userId);

        Task<User> GetUserAsync(int userId);

        Task<List<User>> GetAllUsers();

        Task<List<Role>> GetRoles(int userId);

        Task<List<RoleClaim>> GetRoleClaims(int userId);

        Task<Result> ResetPassword(ResetPasswordRequest request);
    }
}
