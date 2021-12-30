namespace VBMS.Infrastructure.Services.Application
{
    public class CityService : ServiceBase<City, int>
    {
        public CityService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public List<City> GetCities(int provinceId)
        {
            return Repository.Entities().Where(c => c.ProvinceId == provinceId).ToList();
        }
    }
}
