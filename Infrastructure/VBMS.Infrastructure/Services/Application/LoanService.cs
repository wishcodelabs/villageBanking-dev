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
                         .Include(l => l.Applicant)
                         .Where(l => l.Applicant.MembershipId == memberId)
                         .ToListAsync();
        }
        public async Task<List<Loan>> GetByStatusAsync(LoanApplicationStatus loanStatus)
        {
            return await Repository
                         .Entities()
                         .Include(l => l.Applicant)
                         .Where(l => l.Status == loanStatus)
                         .ToListAsync();
        }
    }
}
