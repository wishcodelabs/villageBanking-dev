namespace VBMS.Infrastructure.Services.Application
{
    public class LoanApplicationService : ServiceBase<LoanApplication, int>
    {
        public LoanApplicationService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<List<LoanApplication>> GetAllByUserGuid(Guid userGuid, int periodid)
        {
            var myApplications = new List<LoanApplication>();
            if (periodid == 0)
            {
                myApplications = await Repository.Entities().Where(l => l.Applicant.GroupMembership.UserGuid == userGuid).ToListAsync();
            }
            else
            {
                myApplications = await Repository.Entities().Where(l => l.Applicant.GroupMembership.UserGuid == userGuid && l.PeriodId == periodid).ToListAsync();
            }

            return myApplications;
        }
        public async Task<List<LoanApplication>> GetAllByPeriod(int periodId, int groupId)
        {
            var list = new List<LoanApplication>();
            if (periodId == 0)
            {
                list = await Repository.Entities().Where(l => l.Applicant.GroupMembership.VillageGroupId == groupId).ToListAsync();
            }
            else
            {
                list = await Repository.Entities().Where(l => l.Applicant.GroupMembership.VillageGroupId == groupId && l.PeriodId == periodId).ToListAsync();
            }

            return list;
        }
    }
}
