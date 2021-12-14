

namespace VBMS.Domain.Interfaces;

public interface ICurrentUserService
{
    Task<string> GetUserName();
}
