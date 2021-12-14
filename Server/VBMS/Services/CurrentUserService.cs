namespace VBMS.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        readonly AuthenticationStateProvider _stateProvider;
        public CurrentUserService(AuthenticationStateProvider stateProvider)
        {
            _stateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
        }
        public async Task<string> GetUserName()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();

            return state?.User?.Identity?.Name ?? "Uknown";
        }
    }
}
