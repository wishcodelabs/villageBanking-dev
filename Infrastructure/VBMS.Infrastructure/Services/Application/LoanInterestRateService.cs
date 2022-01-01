namespace VBMS.Infrastructure.Services.Application
{
    public class LoanInterestRateService : ServiceBase<LoanInterestRate, int>
    {
        public LoanInterestRateService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public List<LoanInterestRate> GetByLoanType(int loanTypeId)
        {
            return Repository.Entities().Where(r => r.LoanTypeId == loanTypeId).ToList();
        }
    }
}
