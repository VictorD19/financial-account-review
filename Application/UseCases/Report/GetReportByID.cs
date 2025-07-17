using Application.DTOs;
using Domain.Entities;

namespace Application.UseCases{
    public class GetReportByID{
    private readonly IReportRepository _reportRepository;

    public GetReportByID(IReportRepository reportRepository){
        _reportRepository = reportRepository
    }

public Task<ReportDTO> Get(int idReport){

Report existReport =  await _reportRepository.GetByID(idReport);

return new ReportDTO(){
    Id = existReport.Id,
    FileName = existReport.FileName,
    User = existReport.User,
    Status = existReport.Status
}
}

}
}