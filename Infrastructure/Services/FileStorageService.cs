using Application.Interfaces;

namespace account_review_api.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _env;

        public FileStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveAsync(IFormFile file, string path)
        {
            string diretoryPath = Path.Combine(_env.ContentRootPath, "Uploads", path);

            if (!Directory.Exists(diretoryPath))
                Directory.CreateDirectory(diretoryPath);

            string extensao = Path.GetExtension(file.FileName);
            string nomeBase = Path.GetFileNameWithoutExtension(file.FileName);
            string fileName = $"{nomeBase}-{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{extensao}";
            string filePath = Path.Combine(diretoryPath, fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return filePath;
        }
    }
}
