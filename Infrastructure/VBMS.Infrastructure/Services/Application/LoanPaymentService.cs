namespace VBMS.Infrastructure.Services.Application
{
    public class LoanPaymentService : ServiceBase<LoanPayment, int>
    {
        public LoanPaymentService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
