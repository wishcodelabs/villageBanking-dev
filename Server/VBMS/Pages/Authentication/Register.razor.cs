using VBMS.Domain.Models;

namespace VBMS.Pages.Authentication
{
    public partial class Register
    {
        GroupRegisterModel RegisterModel { get; set; } = new();


        async void Process()
        {

        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all the required fields.", Severity.Error);
        }

    }
}
