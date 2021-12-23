namespace VBMS.Domain.Models
{
    public class GroupRegisterModel
    {
        [Required]
        public string GroupName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        public string ConfirmPassword { get; set; }
    }
}
