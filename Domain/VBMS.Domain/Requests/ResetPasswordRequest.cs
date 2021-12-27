namespace VBMS.Domain.Requests
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
