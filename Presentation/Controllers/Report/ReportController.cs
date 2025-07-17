using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ProcessUploadReport _processUploadReport;
        private readonly GetReportByID _getReportByID;
        private readonly GetStatusFile _getStatusFile;
        public ReportController(
            ProcessUploadReport processUpload,
            GetReportByID getReportById,
            GetStatusFile getStatusFile
        )
        {
            _processUploadReport = processUpload;
            _getReportByID = getReportById;
            _getStatusFile = getStatusFile;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadRelatorio([FromForm] UploadReportDTO dto)
        {
            var result = await _processUploadReport.UploadFile(dto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRelatorioById(int id)
        {
            var relatorio = await _getReportByID.Get(id);

            if (relatorio == null)
                return NotFound("Relatório não encontrado.");

            return Ok(relatorio);
        }

        [HttpGet("{id}/status")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var status = await _getStatusFile.Get(id);

            return Ok(new { id, status });
        }


    }
}
