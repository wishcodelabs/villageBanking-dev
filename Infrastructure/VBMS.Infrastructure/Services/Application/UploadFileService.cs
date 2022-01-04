namespace VBMS.Infrastructure.Services.Application
{
    public class UploadFileService : ServiceBase<UploadFile, int>
    {
        public UploadFileService(IUnitOfWork<int> _unitOfWork) : base(_unitOfWork)
        {
        }
    }
}
