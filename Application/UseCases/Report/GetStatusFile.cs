using Application.Interfaces;

namespace Application.UseCases
{
    public class GetStatusFile
    {
        private readonly IReportRepository _reportRepository;

        public GetStatusFile(IReportRepository reporRepository)
        {
            _reportRepository = reporRepository;
        }

        public async Task<string> Get(int idReport)
        {
            return await _reportRepository.GetStatusByIdAsync(idReport);
        }

    }
}