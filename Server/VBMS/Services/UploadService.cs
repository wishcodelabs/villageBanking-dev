namespace VBMS.Services
{
    public class UploadService : IUploadService
    {
        readonly IWebHostEnvironment webHostEnvironment;
        public UploadService(IWebHostEnvironment _webHostEnvironment)
        {
            webHostEnvironment = _webHostEnvironment;
        }

        public async Task<bool> DeleteFileAsync(string filePath)
        {
            var path = Path.Combine(GetWebRootPath(), "fileUploads", filePath);
            try
            {
                if (File.Exists(path))
                {
                    await Task.Run(() => File.Delete(path));

                    return true;
                }
                else
                {
                    return false;
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
                return false;
            }

        }

        public Task<string> UploadFileAsync(string filePath)
        {
            var newName = Path.GetRandomFileName() + "_" + filePath;
            var path = Path.Combine(GetWebRootPath(), "fileUploads", newName);
            try
            {
                var ms = new MemoryStream();
                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write);
                ms.WriteTo(fileStream);
                return Task.FromResult(newName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return Task.FromResult(string.Empty);
            }
        }

        private string GetWebRootPath() => webHostEnvironment.WebRootPath;

    }
}
