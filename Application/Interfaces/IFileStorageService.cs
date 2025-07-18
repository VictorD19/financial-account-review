namespace Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveAsync(IFormFile fileStream, string path);
    }
}
