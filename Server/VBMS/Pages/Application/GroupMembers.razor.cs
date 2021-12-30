namespace VBMS.Pages.Application
{
    public partial class GroupMembers
    {
        VillageBankGroup VillageBank { get; set; } = new();

        [CascadingParameter] Task<AuthenticationState> AuthenticationStateTask { get; set; }
        GroupAdmin Admin { get; set; } = new();
        List<VillageGroupMembership> Members = new();
        ClaimsPrincipal claimsPrincipal = new();
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true };
        protected override async Task OnInitializedAsync()
        {

            claimsPrincipal = (await AuthenticationStateTask).User;
            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                Admin = await groupAdminService.GetByUserGuid(await userService.GetGuid(claimsPrincipal.Identity.Name));
                VillageBank = Admin.Group;
                Members = await membershipService.GetMembers(VillageBank.Id);
            }


        }
        void ToggleAdd()
        {
            var parameters = new DialogParameters { ["VillageBankId"] = VillageBank.Id, ["IsAdmin"] = false, ["UserGuid"] = new Guid() };
            var dialog = dialogService.Show<AddGroupMemberModal>("Add New Group Member", parameters, maxWidth);
        }
    }
}
