namespace VBMS.Shared.Components
{
    public partial class AddGroupMemberModal
    {
        [Inject] ISnackbar _snackbar { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        string userName;
        [Parameter] public Guid? UserGuid { get; set; }
        [Parameter] public bool IsAdmin { get; set; }
        RegisterRequest RegisterRequest { get; set; } = new();
        Dictionary<string, object> _attributes { get; set; }
        int ProvinceId { get; set; } = 1;
        List<Province> ProvinceList { get; set; } = new();
        [Parameter] public int VillageBankId { get; set; } = new();
        VillageGroupMembership GroupMembershipModel = new VillageGroupMembership();
        IEnumerable<VillageGroupRole> memberRoles { get; set; } = new List<VillageGroupRole>();


        protected override async Task OnInitializedAsync()
        {
            _attributes = new Dictionary<string, object>();
            await Init();
            ProvinceList = await provinceService.GetAllAsync();
            _attributes.Add("form", "editForm");
        }
        async Task Init()
        {
            GroupMembershipModel.PersonalDetails = new();
            GroupMembershipModel.PersonalDetails.PhysicalAddress = new();
            if (!IsAdmin)
            {

            }
            var user = await userService.GetUserAsync((Guid)UserGuid);
            if (user != null)
            {
                GroupMembershipModel.PersonalDetails.FirstName = user.FirstName;
                GroupMembershipModel.PersonalDetails.LastName = user.LastName;
                GroupMembershipModel.PersonalDetails.EmailAddress = user.Email;
                GroupMembershipModel.PersonalDetails.PhoneNumber = user.PhoneNumber;
            }

        }
        async Task Submit()
        {

            if (VillageBankId != 0)
            {
                if (IsAdmin)
                {
                    GroupMembershipModel.VillageGroupId = VillageBankId;
                    GroupMembershipModel.Roles = new();
                    GroupMembershipModel.DateJoined = DateTime.Now;
                    GroupMembershipModel.UserGuid = (Guid)UserGuid;
                    foreach (var role in memberRoles)
                    {
                        GroupMembershipModel.Roles.Add(new VillageGroupMemberRole { Role = role });

                    }

                    if (await membershipService.AddAsync(GroupMembershipModel))
                    {
                        _snackbar.Add("Details Saved Successfully", Severity.Success);
                        MudDialog.Close(DialogResult.Ok(true));
                    }
                    else
                    {
                        _snackbar.Add("Opps! Something went wrong.", Severity.Error);
                    }
                }
                else
                {
                    //New user
                    RegisterRequest.FirstName = GroupMembershipModel.PersonalDetails.FirstName;
                    RegisterRequest.LastName = GroupMembershipModel.PersonalDetails.LastName;
                    RegisterRequest.Email = GroupMembershipModel.PersonalDetails.EmailAddress;
                    RegisterRequest.PhoneNumber = GroupMembershipModel.PersonalDetails.PhoneNumber;
                    RegisterRequest.Password = @"Pa$$word1234";
                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        RegisterRequest.UserName = RegisterRequest.FirstName.ToLower() + "." + RegisterRequest.LastName.ToLower();
                    }
                    RegisterRequest.UserName = userName;
                    RegisterRequest.IsValid = true;
                    RegisterRequest.IsAdmin = memberRoles.Any(r => r == VillageGroupRole.Admin);
                    var result = await userRegisterService.RegisterAsync(RegisterRequest);
                    if (result.Succeeded)
                    {
                        _snackbar.Add(result.Messages.First(), Severity.Success);
                        var userGuid = await userService.GetGuid(RegisterRequest.UserName);

                        GroupMembershipModel.VillageGroupId = VillageBankId;
                        GroupMembershipModel.Roles = new();
                        GroupMembershipModel.DateJoined = DateTime.Now;
                        GroupMembershipModel.UserGuid = userGuid;
                        foreach (var role in memberRoles)
                        {
                            GroupMembershipModel.Roles.Add(new VillageGroupMemberRole { Role = role });
                        }

                        if (await membershipService.AddAsync(GroupMembershipModel))
                        {
                            _snackbar.Add("Details Saved Successfully", Severity.Success);
                            MudDialog.Close(DialogResult.Ok(true));
                        }
                        else
                        {
                            _snackbar.Add("Opps! Something went wrong.", Severity.Error);
                        }

                    }
                    else
                    {
                        _snackbar.Add(result.Messages.First(), Severity.Error);
                    }

                }
            }



        }
        void ModelInvalid()
        {
            _snackbar.Add("Please fill in all required fields", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();

    }
}
