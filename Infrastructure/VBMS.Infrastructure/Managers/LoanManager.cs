namespace VBMS.Infrastructure.Managers
{
    public class LoanManager : ManagerBase<Loan, int>
    {
        public LoanManager(IUnitOfWork<int> unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<List<Loan>> GetAllByMemberId(int memberId)
        {
            return await Repository
                         .Entities
                         .Include(l => l.Applicant)
                         .Where(l => l.Applicant.MembershipId == memberId)
                         .ToListAsync();
        }
        public async Task<List<Loan>> GetByStatusAsync(LoanStatus loanStatus)
        {
            return await Repository
                         .Entities
                         .Include(l => l.Applicant)
                         .Where(l => l.Status == loanStatus)
                         .ToListAsync();
        }
    }
}
