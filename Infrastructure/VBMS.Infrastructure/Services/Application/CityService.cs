namespace VBMS.Infrastructure.Services.Application
{
    public class CityService : ServiceBase<City, int>
    {
        public CityService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
