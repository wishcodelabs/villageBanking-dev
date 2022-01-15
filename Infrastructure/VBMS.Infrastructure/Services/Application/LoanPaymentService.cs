namespace VBMS.Infrastructure.Services.Application
{
    public class LoanPaymentService : ServiceBase<LoanPayment, int>
    {
        readonly LoanService loanService;
        public LoanPaymentService(IUnitOfWork<int> _unitOfWork, LoanService _loanService) : base(_unitOfWork)
        {
            loanService = _loanService;
        }


    }
}
