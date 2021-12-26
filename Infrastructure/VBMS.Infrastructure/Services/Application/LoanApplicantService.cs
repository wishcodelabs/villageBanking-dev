namespace VBMS.Infrastructure.Services.Application
{
    public class LoanApplicantService : ServiceBase<Applicant, int>
    {
        public LoanApplicantService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
