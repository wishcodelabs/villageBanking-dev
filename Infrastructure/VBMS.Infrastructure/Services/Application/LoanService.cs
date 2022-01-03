namespace VBMS.Infrastructure.Services.Application
{
    public class LoanService : ServiceBase<Loan, int>
    {
        public LoanService(IUnitOfWork<int> unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<List<Loan>> GetAllByMemberId(int memberId)
        {
            return await Repository
                         .Entities()
                         .Where(l => l.ApplicationRequest.Applicant.MembershipId == memberId)
                         .ToListAsync();
        }
        public async Task<List<Loan>> GetByStatusAsync(LoanStatus loanStatus)
        {
            return await Repository
                         .Entities()
                         .Where(l => l.Status == loanStatus)
                         .ToListAsync();
        }
    }
}
