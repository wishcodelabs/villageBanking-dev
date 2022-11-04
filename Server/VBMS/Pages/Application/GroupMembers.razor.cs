namespace VBMS.Pages.Application
{
    public partial class GroupMembers
    {
        VillageBankGroup VillageBank { get; set; } = new();

        [CascadingParameter] Task<AuthenticationState> AuthenticationStateTask { get; set; }
        GroupAdmin Admin { get; set; } = new();

        List<VillageGroupMembership> Members = new();
        ClaimsPrincipal claimsPrincipal = new();
        DialogOptions maxWidth = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
        protected override async Task OnInitializedAsync()
        {

            claimsPrincipal = (await AuthenticationStateTask).User;
            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                Admin = await groupAdminService.GetByUserGuid(claimsPrincipal.GetGuid());
                VillageBank = Admin.Group;
                Members = await membershipService.GetMembers(VillageBank.Id);
            }


        }
        async void ToggleDelete(VillageGroupMembership member)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", member.PersonalDetails.FirstName + " " + member.PersonalDetails.LastName);
            parameters.Add("DialogType", DialogType.Delete);
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall, DisableBackdropClick = true };
            var dialog = dialogService.Show<SimpleDialog>("Delete", parameters, options);
            var response = await dialog.Result;
            if (!response.Cancelled)
            {
                if ((bool)response.Data)
                {
                    //do the delete
                    if (await membershipService.DeleteAsync(member) && await userService.DeleteUser(member.UserGuid))
                    {
                        snackBar.Add("Record deleted successifully", Severity.Success);
                        Members = new();
                        Members = await membershipService.GetMembers(VillageBank.Id);
                        StateHasChanged();
                    }
                    else
                    {
                        snackBar.Add("Something went wrong while trying to delete the record", Severity.Error);
                    }
                }
            }



        }
        async void ToggleAdd()
        {
            var parameters = new DialogParameters { ["VillageBankId"] = VillageBank.Id, ["IsAdmin"] = false, ["UserGuid"] = new Guid() };
            var dialog = dialogService.Show<AddGroupMemberModal>("Add New Group Member", parameters, maxWidth);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                if ((bool)result.Data)
                {
                    Members = new();
                    Members = await membershipService.GetMembers(VillageBank.Id);
                    StateHasChanged();
                }
            }
        }
        async void ToggleEdit(VillageGroupMembership record)
        {
            var parameters = new DialogParameters { ["VillageBankId"] = VillageBank.Id, ["IsAdmin"] = false, ["UserGuid"] = new Guid(), ["IsEditing"] = true, ["Model"] = record };
            var dialog = dialogService.Show<AddGroupMemberModal>("Edit Record", parameters, maxWidth);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                if ((bool)result.Data)
                {
                    Members = new();
                    Members = await membershipService.GetMembers(VillageBank.Id);
                    StateHasChanged();
                }
            }
        }
    }
}
