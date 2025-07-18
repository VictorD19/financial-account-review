using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class GetReportByID
    {
        private readonly IReportRepository _reportRepository;

        public GetReportByID(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ReportDTO> Get(int idReport)
        {
            Report existReport = await _reportRepository.GetByIDAsync(idReport);

            return new ReportDTO()
            {
                Id = existReport.Id,
                FileName = existReport.FileName,
                User = existReport.User,
                Status = existReport.Status
            };
        }

    }

}