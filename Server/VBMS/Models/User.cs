namespace VBMS.Models
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? MiddleName { get; set; }

        public Guid UserGuid { get; set; }

        public User()
        {
            UserGuid = new();
        }
    }
}
