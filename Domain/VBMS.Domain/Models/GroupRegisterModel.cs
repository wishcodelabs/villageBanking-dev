namespace VBMS.Domain.Models
{
    public class GroupRegisterModel
    {
        [Required(ErrorMessage = "Group name is required")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string GroupPhoneNumber { get; set; }

        [Required(ErrorMessage = "Group role required")]
        public VillageGroupRole Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Compare(nameof(Password), ErrorMessage = "Confirm password and password should match")]
        public string ConfirmPassword { get; set; }
        public GroupRegisterModel()
        {
            Role = VillageGroupRole.Admin;
        }
    }
}
