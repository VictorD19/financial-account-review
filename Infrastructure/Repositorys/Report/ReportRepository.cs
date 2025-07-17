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

        public async Task<Report> Adicionar(Report report)
        {
            return new Report()
            {
                Id = 1,
                FileName = "Arquivo Cirado",
                SendDate = new DateTime(),
                Status = "completed",
                User = "Victor"
            };
        }

        public async Task<string> GetStatusById(int reportId)
        {
            return "active";
        }

        public async Task<Report> GetByID(int reportId)
        {
            return new Report()
            {
                Id = 1,
                FileName = "Arquivo Cirado",
                SendDate = new DateTime(),
                Status = "completed",
                User = "Victor"
            };
        }
    }
}