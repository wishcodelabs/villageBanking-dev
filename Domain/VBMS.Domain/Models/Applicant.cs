namespace VBMS.Domain.Models
{
    public class Applicant : Entity<int>
    {
        public int PersonalDetailsId { get; set; }

        public virtual PersonalDetails PersonalDetails { get; set; }
    }
}