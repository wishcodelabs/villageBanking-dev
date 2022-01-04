namespace VBMS.Services
{
    public class UploadService : IUploadService
    {
        readonly IWebHostEnvironment webHostEnvironment;
        public UploadService(IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
        }
        public Task<string> UploadFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        private string GetWebRootPath() => webHostEnvironment.WebRootPath;

    }
}
