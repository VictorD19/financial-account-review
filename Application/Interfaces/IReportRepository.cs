using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReportRepository {
        public Task<Report> Adicionar(Report report);
        public Task<string> GetStatusById(int reportId);
        public Task<Report> GetByID(int reportId);
    }
}