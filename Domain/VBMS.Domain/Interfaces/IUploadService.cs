namespace VBMS.Domain.Interfaces
{
    public interface IUploadService : IService
    {
        Task<string> UploadFileAsync(string filePath);

        Task<bool> DeleteFileAsync(string filePath);
    }
}
