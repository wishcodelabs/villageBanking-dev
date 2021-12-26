namespace VBMS.Infrastructure.Services.Application
{
    public class LoanInterestRateService : ServiceBase<LoanInterestRate, int>
    {
        public LoanInterestRateService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
