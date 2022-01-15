namespace VBMS.Domain.Interfaces
{
    public interface IUploadService : IService
    {
        Task<string> UploadFileAsync(string filePath, MemoryStream data);

        Task<bool> DeleteFileAsync(string filePath);
    }
}
