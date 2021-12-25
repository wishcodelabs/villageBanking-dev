namespace VBMS.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        readonly IHttpContextAccessor httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            httpContextAccessor = contextAccessor;
        }
        public Task<string> GetUserName()
        {
            var context = httpContextAccessor.HttpContext;
            return Task.FromResult(context?.User?.Identity?.Name ?? "SYSTEM");
        }
    }
}
