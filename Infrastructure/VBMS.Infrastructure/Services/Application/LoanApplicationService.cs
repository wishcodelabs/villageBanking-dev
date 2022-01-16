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
                myApplications = await Repository.Entities().Where(l => l.Applicant.UserGuid == userGuid).ToListAsync();
            }
            else
            {
                myApplications = await Repository.Entities().Where(l => l.Applicant.UserGuid == userGuid && l.PeriodId == periodid).ToListAsync();
            }

            return myApplications;
        }

        public async Task<List<LoanApplication>> GetAllByPeriod(int periodId, int groupId)
        {
            var list = new List<LoanApplication>();
            if (periodId == 0)
            {
                list = await Repository.Entities().Where(l => l.Applicant.VillageGroupId == groupId).ToListAsync();
            }
            else
            {
                list = await Repository.Entities().Where(l => l.Applicant.VillageGroupId == groupId && l.PeriodId == periodId).ToListAsync();
            }

            return list;
        }
        public async Task<List<LoanApplication>> GetByStatus(int groupId, LoanApplicationStatus status)
        {
            var all = await GetAllByPeriod(0, groupId);

            return all.Where(l => l.Status == status).ToList();
        }

        public async Task<int> GetMineByStatusAsync(int member, LoanApplicationStatus status, int currentPeriod)
        {
            var mine = await Repository.Entities(false).Where(l => l.ApplicantId == member && l.Status == status).ToListAsync();
            if (currentPeriod == 0)
            {
                return mine.Count;

            }
            else
            {
                return mine.Where(l => l.PeriodId == currentPeriod).Count();
            }

        }
    }
}
