namespace VBMS.Infrastructure.Services.Application
{
    public class LoanTypeService : ServiceBase<LoanType, int>
    {
        public LoanTypeService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
