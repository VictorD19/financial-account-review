using account_review_api.Infrastructure.Services;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class ProcessUploadReport
    {
        private readonly IReportRepository _repository;
        private readonly IFileStorageService _fileStorageService;
        public ProcessUploadReport(IReportRepository repository, IFileStorageService fileStorageService)
        {
            _repository = repository;
            _fileStorageService = fileStorageService;
        }

        public async Task<ResultDTO> UploadFile(UploadReportDTO dataUpload)
        {
           await _fileStorageService.SaveAsync(dataUpload.File, "ArquivosProcessar");

           var idReport = await _repository.AddAsync(new Report()
            {
                FileName = dataUpload.File.FileName,
                SendDate = new DateTime(),
                User = dataUpload.User,
                Status = "received"
            });

            return new ResultDTO()
            {
                Id = idReport,
                Success = true,
                Message = "Arquivo Salvo com sucesso"
            };
        }
    }
}