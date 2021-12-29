namespace VBMS.Infrastructure.Interfaces
{
    public interface IUserRegisterService : IIdentityService
    {
        Task<IResult<Guid>> RegisterAsync(RegisterRequest request);

    }
}
