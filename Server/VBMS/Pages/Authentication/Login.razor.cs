namespace VBMS.Pages.Authentication
{
    public partial class Login
    {
        TokenRequest<User> tokenRequest = new();
        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        bool forgotPass;
        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        async Task SubmitAsync()
        {
            tokenRequest.ReturnUrl = "/";
            var result = await userService.LoginAsync(tokenRequest);
            if (result.Succeeded)
            {
                navigationManager.NavigateTo($"/login/?key={result.Data}", true);
            }
            else
            {
                snackBar.Add(result.Messages.First(), Severity.Error);
            }
        }
        void ModelInvalid()
        {
            snackBar.Add("Please fill in all required fields.", Severity.Error);
        }
        void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
        void ForgotPass()
        {
            forgotPass = !forgotPass;
        }
    }
}
