namespace VBMS.Infrastructure.Services.Application
{
    public class LoanInterestRateService : ServiceBase<LoanInterestRate, int>
    {
        public LoanInterestRateService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public IEnumerable<LoanInterestRate> GetByLoanType(int loanTypeId)
        {
            if (loanTypeId == 0)
            {
                return new List<LoanInterestRate>();
            }

            return Repository.Entities().Where(i => i.LoanTypeId == loanTypeId).ToList();
        }
    }
}
