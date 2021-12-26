using VBMS.Domain.Models;

namespace VBMS.Pages.Authentication
{
    public partial class Register
    {
        GroupRegisterModel RegisterModel { get; set; } = new();
        IEnumerable<VillageGroupRole> villageGroupRoles { get; set; } = new HashSet<VillageGroupRole>();

        async void Process()
        {

        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }

    }
}
