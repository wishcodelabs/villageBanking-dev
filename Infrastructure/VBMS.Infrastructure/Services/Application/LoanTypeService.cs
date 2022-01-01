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
        public async Task<bool> ToggleActive(LoanType record)
        {
            record.IsActive = !record.IsActive;

            return await UpdateAsync(record);
        }
    }
}
