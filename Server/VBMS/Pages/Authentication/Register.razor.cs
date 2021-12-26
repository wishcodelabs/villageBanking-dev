using VBMS.Domain.Models;

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
                snackBar.Add(result.Messages[0], Severity.Success);
            }
            else
            {
                snackBar.Add(result.Messages[0], Severity.Error);
            }
        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }

    }
}
