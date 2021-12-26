namespace VBMS.Infrastructure.Interfaces
{
    public interface IUserService : IIdentityService
    {
        Task<Result> RegisterAsync(RegisterRequest request);

    }
}
