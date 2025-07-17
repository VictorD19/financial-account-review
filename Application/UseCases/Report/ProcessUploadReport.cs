using Domain.Entities;
using Application.DTOs;
using Application.Interfaces;

namespace Application.UseCases
{
    public class ProcessUploadReport
    {
        private readonly IReportRepository _repository;

        public ProcessUploadReport(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDTO> UploadFile(UploadReportDTO dataUpload)
        {

            await _repository.Adicionar(new Report()
            {
                FileName = "Teste",
                SendDate = new DateTime(),
                User = "Victor",
                Status = "received"
            });
            return new ResultDTO()
            {
                Success = true,
                Message = "Arquivo Salvo com sucesso"
            };
        }
    }
}