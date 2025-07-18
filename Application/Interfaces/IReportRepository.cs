using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReportRepository {
        public Task<int> AddAsync(Report report);
        public Task<string> GetStatusByIdAsync(int reportId);
        public Task<Report> GetByIDAsync(int reportId);
    }
}