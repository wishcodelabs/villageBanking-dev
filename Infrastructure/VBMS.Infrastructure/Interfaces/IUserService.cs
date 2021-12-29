namespace VBMS.Infrastructure.Interfaces
{
    public interface IUserService : IIdentityService
    {
        Task<int> GetCount();
        Task<IResult<Guid>> LoginAsync(TokenRequest<User> request);

        Task<string> GetFullName(string username);

        Task<User> GetUserAsync(int userId);

        Task<List<User>> GetAllUsers();
        Task<string> GetGuid(string userName);

        Task<List<Role>> GetRoles(int userId);

        Task<List<RoleClaim>> GetRoleClaims(int userId);

        Task<IResult> ResetPassword(ResetPasswordRequest request);
    }
}
