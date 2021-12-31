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
        [Parameter] public bool IsEditing { get; set; }
        [Parameter] public VillageGroupMembership? Model { get; set; }
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
            if (!IsEditing && Model == null)
            {
                Model = new();
                Model.PersonalDetails = new();
                Model.PersonalDetails.PhysicalAddress = new();
                if (!IsAdmin)
                {

                }
                var user = await userService.GetUserAsync((Guid)UserGuid);
                if (user != null)
                {
                    Model.PersonalDetails.FirstName = user.FirstName;
                    Model.PersonalDetails.LastName = user.LastName;
                    Model.PersonalDetails.EmailAddress = user.Email;
                    Model.PersonalDetails.PhoneNumber = user.PhoneNumber;
                }
            }
        }
        async Task Submit()
        {

            if (VillageBankId != 0)
            {
                if (IsEditing)
                {
                    if (await membershipService.UpdateAsync(Model))
                    {
                        _snackbar.Add("Record Updated Sucessefully", Severity.Success);
                        MudDialog.Close(DialogResult.Ok(true));
                    }
                    else
                    {
                        _snackbar.Add("An Error Occurred while trying to update the record", Severity.Error);
                    }
                }
                else
                {
                    if (IsAdmin)
                    {
                        Model.VillageGroupId = VillageBankId;
                        Model.Roles = new();
                        Model.DateJoined = DateTime.Now;
                        Model.UserGuid = (Guid)UserGuid;
                        foreach (var role in memberRoles)
                        {
                            Model.Roles.Add(new VillageGroupMemberRole { Role = role });

                        }

                        if (await membershipService.AddAsync(Model))
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
                        RegisterRequest.FirstName = Model.PersonalDetails.FirstName;
                        RegisterRequest.LastName = Model.PersonalDetails.LastName;
                        RegisterRequest.Email = Model.PersonalDetails.EmailAddress;
                        RegisterRequest.PhoneNumber = Model.PersonalDetails.PhoneNumber;
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
                            if (RegisterRequest.IsAdmin)
                            {
                                if (!await groupAdminService.IsAlreadyAdmin(userGuid))
                                {
                                    var groupAdmin = new GroupAdmin
                                    {
                                        UserGuid = userGuid,
                                        GroupId = VillageBankId
                                    };
                                    if (await groupAdminService.AddAsync(groupAdmin))
                                    {
                                        snackBar.Add($"{RegisterRequest.UserName} added as a group admin.", Severity.Success);
                                    }
                                }

                            }
                            Model.VillageGroupId = VillageBankId;
                            Model.Roles = new();
                            Model.DateJoined = DateTime.Now;
                            Model.UserGuid = userGuid;
                            foreach (var role in memberRoles)
                            {
                                Model.Roles.Add(new VillageGroupMemberRole { Role = role });
                            }

                            if (await membershipService.AddAsync(Model))
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

        }
        void ModelInvalid()
        {
            _snackbar.Add("Please fill in all required fields", Severity.Error);
        }
        void Cancel() => MudDialog.Cancel();

    }
}
