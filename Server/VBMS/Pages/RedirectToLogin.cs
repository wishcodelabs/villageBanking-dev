using Microsoft.AspNetCore.Components;

namespace VBMS.Pages
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("/login", true);
        }

    }
}
