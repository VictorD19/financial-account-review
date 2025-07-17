using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases{
    public class GetStatusFile{
        private readonly IReportRepository _reportRepository;

        public GetStatusFile(IReportRepository reporRepository){
            _reportRepository = reporRepository;
        }

        public Task<string> Get(int idReport){
            Report existReport = await _reportRepository.GetStatusById(idReport);

        return existReport.Status;

        }

    }
}