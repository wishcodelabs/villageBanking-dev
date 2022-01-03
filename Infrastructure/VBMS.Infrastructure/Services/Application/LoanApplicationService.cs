namespace VBMS.Infrastructure.Services.Application
{
    public class LoanApplicationService : ServiceBase<LoanApplication, int>
    {
        public LoanApplicationService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
