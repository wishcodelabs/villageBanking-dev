namespace VBMS.Domain.Models
{
    public class City : Entity<int>
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }

        public virtual Province Province { get; set; }
    }
}
