using account_review_api.Application.DTOs;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IReportService
    {
        Task<ResultDTO> ProccessUpload(UploadReportDTO dto);
        Task<ReportDTO> GetByID(int id);
        Task<string> GetStatusFile(int id);
    }
}
