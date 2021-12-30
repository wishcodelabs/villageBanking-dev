

namespace VBMS.Shared.Components
{
    public partial class AddGroupMemberModal
    {

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public Guid? UserGuid { get; set; }
        int ProvinceId { get; set; } = 1;
        List<Province> ProvinceList { get; set; } = new();
        List<City> CityList { get; set; } = new();
        [Parameter] public int VillageBankId { get; set; } = new();
        VillageGroupMembership GroupMembershipModel = new VillageGroupMembership();
        IEnumerable<VillageGroupRole> memberRoles { get; set; } = new List<VillageGroupRole>();
        protected override async Task OnInitializedAsync()
        {
            await Init();
            ProvinceList = await provinceService.GetAllAsync();
        }
        async Task Init()
        {
            GroupMembershipModel.PersonalDetails = new();
            GroupMembershipModel.PersonalDetails.PhysicalAddress = new();
            var user = await userService.GetUserAsync((Guid)UserGuid);
            if (user == null)
            {

            }
            GroupMembershipModel.PersonalDetails.FirstName = user.FirstName;
            GroupMembershipModel.PersonalDetails.LastName = user.LastName;
            GroupMembershipModel.PersonalDetails.EmailAddress = user.Email;
            GroupMembershipModel.PersonalDetails.PhoneNumber = user.PhoneNumber;


        }
        async Task Submit()
        {
            if (VillageBankId != 0)
            {
                GroupMembershipModel.VillageGroupId = VillageBankId;
                GroupMembershipModel.Roles = new();
                foreach (var role in memberRoles)
                {
                    GroupMembershipModel.Roles.Add(new VillageGroupMemberRole { Role = role });
                }

                if (await membershipService.AddAsync(GroupMembershipModel))
                {
                    snackBar.Add("Details Saved Successfully", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    snackBar.Add("Opps! Something went wrong.", Severity.Error);
                }
            }

        }
        void GetCities()
        {
            CityList = cityService.GetCities(ProvinceId);
        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all required field", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();

    }
}
