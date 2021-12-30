namespace VBMS.Pages.Authentication
{
    public partial class Register
    {
        GroupRegisterModel RegisterModel { get; set; } = new();
        IEnumerable<VillageGroupRole> villageGroupRoles { get; set; } = new HashSet<VillageGroupRole>();
        async void Process()
        {
            var userRequest = new RegisterRequest
            {
                FirstName = RegisterModel.FirstName,
                LastName = RegisterModel.LastName,
                Email = RegisterModel.Email,
                PhoneNumber = RegisterModel.PhoneNumber,
                Password = RegisterModel.Password,
                UserName = RegisterModel.UserName,
                IsValid = true,
                AutoConfirm = true
            };
            var result = await userRegisterService.RegisterAsync(userRequest);
            if (result.Succeeded)
            {
                snackBar.Add(result.Messages.First(), Severity.Success);
                var userGuid = await userService.GetGuid(userRequest.UserName);
                var villageBank = new VillageBankGroup
                {
                    GroupName = RegisterModel.GroupName
                };

                if (await groupAdminService.IsAlreadyAdmin(userGuid))
                {
                    snackBar.Add("There is already a group associated with this user. Login Instead", Severity.Error);
                }
                villageBank.Admins = new List<GroupAdmin>();
                villageBank.Admins.Add(new GroupAdmin { UserGuid = userGuid });
                if (await villageBankGroupService.AddAsync(villageBank))
                {

                    snackBar.Add("New Village Bank Group Created Successfully.", Severity.Success);
                    navigationManager.NavigateTo($"/login?key={result.Data}", true);
                }
                else
                {
                    snackBar.Add("An error occured while creating your group.", Severity.Error);
                }
            }
            else
            {
                snackBar.Add(result.Messages.First(), Severity.Error);
            }
        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }

    }
}
