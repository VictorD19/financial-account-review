using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _relatorioService;
        public ReportController(IReportService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadRelatorio([FromForm] UploadReportDTO dto)
        {
            var result = await _relatorioService.ProccessUpload(dto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelatorioById(int id)
        {
            var relatorio = await _relatorioService.GetByID(id);

            if (relatorio == null)
                return NotFound("Relatório não encontrado.");

            return Ok(relatorio);
        }

        [HttpGet("{id}/status")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var status = await _relatorioService.GetStatusFile(id);

            return Ok(new { id, status });
        }


    }
}
