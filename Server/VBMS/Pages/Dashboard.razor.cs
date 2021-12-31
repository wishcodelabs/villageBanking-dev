namespace VBMS.Pages
{
    public partial class Dashboard
    {
        [CascadingParameter] protected Task<AuthenticationState> AuthenticationStateTask { get; set; }
        VillageBankGroup VillageBank { get; set; } = new();
        int[] searchData, clicksData, applyChartData, admissionData, consolData;
        int memberCount = 0;
        ClaimsPrincipal claimsPrincipal = new();
        Guid userGuid;
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        protected override async Task OnInitializedAsync()
        {
            searchData = new int[] { 10, 15, 25, 40 };
            clicksData = new int[] { 5, 30, 54, 40 };
            applyChartData = new int[] { 162, 200, 285, 400, 250, 50, 100 };
            admissionData = new int[] { 56, 100, 150, 63, 58, 300, 30 };
            consolData = new int[] { 25, 40, 35 };
            claimsPrincipal = (await AuthenticationStateTask).User;

            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                userGuid = await userService.GetGuid(claimsPrincipal.Identity.Name);
                if ((await authorizationService.AuthorizeAsync(claimsPrincipal, this, "RequireAdminRole")).Succeeded)
                {
                    var admin = await groupAdminService.GetByUserGuid(userGuid);
                    if (admin != null)
                    {
                        VillageBank = admin.Group;
                        memberCount = await membershipService.CountMembers(VillageBank.Id);
                    }
                }
                else
                {
                    VillageBank = await membershipService.GetGroupAsync(userGuid);
                }

            }

        }
        async void ToggleActivateGroup()
        {
            var parameters = new DialogParameters { ["VillageBankId"] = VillageBank.Id, ["IsAdmin"] = true, ["UserGuid"] = userGuid };
            if (memberCount == 0)
            {
                var dialog = dialogService.Show<AddGroupMemberModal>("Complete Your Membership Form", parameters, maxWidth);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    ActivateGroup();
                }

            }
            else
            {
                ActivateGroup();
            }

        }

        async void ActivateGroup()
        {
            if (await villageBankGroupService.ActivateGroup(VillageBank.Id))
            {
                snackBar.Add("Your group is now active", Severity.Success);
                var admin = await groupAdminService.GetByUserGuid(userGuid);
                VillageBank = new();
                VillageBank = admin.Group;
                StateHasChanged();
            }
            else
            {
                snackBar.Add("Something went wrong while trying to activate your group", Severity.Error);
            }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if ((await authorizationService.AuthorizeAsync(claimsPrincipal, this, "RequireAdminRole")).Succeeded)
            {

                await jsRuntime.InvokeVoidAsync("setup", new object[] { searchData, clicksData, applyChartData, admissionData, consolData });
            }
        }
    }
}
