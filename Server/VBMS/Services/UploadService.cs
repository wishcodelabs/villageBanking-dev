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

        public async Task<string> UploadFileAsync(string filePath, MemoryStream data)
        {
            var newName = Path.GetRandomFileName() + "_" + filePath;
            var path = Path.Combine(GetWebRootPath(), "fileUploads", newName);
            try
            {

                using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write);
                await Task.Run(() => data.WriteTo(fileStream));
                return newName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return string.Empty;
            }
        }

        private string GetWebRootPath() => webHostEnvironment.WebRootPath;

    }
}
