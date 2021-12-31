namespace VBMS.Infrastructure.Interfaces
{
    public interface IUserService : IIdentityService
    {
        Task<int> GetCount();
        Task<IResult<Guid>> LoginAsync(TokenRequest<User> request);

        Task<string> GetFullName(string username);
        Task<bool> DeleteUser(Guid guid);
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserAsync(Guid guid);

        Task<List<User>> GetAllUsers();
        Task<Guid> GetGuid(string userName);

        Task<List<Role>> GetRoles(int userId);

        Task<List<RoleClaim>> GetRoleClaims(int userId);

        Task<IResult> ResetPassword(ResetPasswordRequest request);
    }
}
