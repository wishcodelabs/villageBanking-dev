using Microsoft.Extensions.Caching.Memory;

namespace VBMS.Infrastructure.Services.Application
{
    public class LoanPaymentService : ServiceBase<LoanPayment, int>
    {
        readonly LoanService loanService;
        public LoanPaymentService(IUnitOfWork<int> _unitOfWork, LoanService _loanService) : base(_unitOfWork)
        {
            loanService = _loanService;
        }

        public async Task<bool> HasUnpaid(int applicant)
        {
            var options = new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(24) };
            var list = Repository.Entities().FromCache(options);
            var loans = (await loanService.GetAllAsync()).Where(l => l.ApplicationRequest.ApplicantId == applicant);

            var hasLoan = loans.Any();
            var hasPaid = loans.Any(l => l.Status == LoanStatus.Due && l.Payments.Any()) || loans.Any(l => l.Status == LoanStatus.Paid);

            return hasLoan && !hasPaid;

        }
    }
}
