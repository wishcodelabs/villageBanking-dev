namespace VBMS.Infrastructure.Services.Application
{
    public class InvestmentService : ServiceBase<Investment, int>
    {
        public InvestmentService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
