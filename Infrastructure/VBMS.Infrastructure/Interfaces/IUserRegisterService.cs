namespace VBMS.Infrastructure.Interfaces
{
    public interface IUserRegisterService : IIdentityService
    {
        Task<IResult> RegisterAsync(RegisterRequest request);

    }
}
