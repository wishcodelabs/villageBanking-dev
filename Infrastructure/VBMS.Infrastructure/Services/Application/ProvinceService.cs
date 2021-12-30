namespace VBMS.Infrastructure.Services.Application
{
    public class ProvinceService : ServiceBase<Province, int>
    {
        public ProvinceService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
