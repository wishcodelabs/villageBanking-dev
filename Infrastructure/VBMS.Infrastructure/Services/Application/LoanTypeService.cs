namespace VBMS.Infrastructure.Services.Application
{
    public class LoanTypeService : ServiceBase<LoanType, int>
    {
        public LoanTypeService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<List<LoanType>> GetLoanTypes(int groupId)
        {
            return await Repository.Entities().Where(l => groupId.Equals(l.GroupId)).ToListAsync();
        }
    }
}
