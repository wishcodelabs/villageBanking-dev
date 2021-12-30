namespace VBMS.Domain.Models
{
    public class Province : Entity<int>
    {
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
