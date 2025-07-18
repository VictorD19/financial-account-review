using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastruture.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report.Id;
        }

        public async Task<string> GetStatusByIdAsync(int reportId)
        {
            return await _context.Reports.Where(report => report.Id == reportId).Select(report => report.Status).FirstAsync();
        }

        public async Task<Report> GetByIDAsync(int reportId)
        {
            return await _context.Reports.FindAsync(reportId);
        }
    }
}