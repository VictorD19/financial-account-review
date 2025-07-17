using Application.Interfaces
namespace Infrastruture.Repository{
    public class ReportRepository: IReportRepository{
         private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

 public Task<Report> Adicionar(Report report){
   return new Report(){}
 }
        public Task<string> GetStatusById(int reportId){
return "";
        }
        public Task<Report> GetByID(int reportId){
            return new Report(){}
        }
    }
}