namespace VBMS.Domain.Requests
{
    public class TokenRequest<TUser> where TUser : class
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string TwoFactorCode { get; set; }
        public bool RemberMachine { get; set; }
        public TUser User { get; set; }
        public DateTime LoginStarted { get; set; }

        public bool RememberMe { get; set; }
    }
}
