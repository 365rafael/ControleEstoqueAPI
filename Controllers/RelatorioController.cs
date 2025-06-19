using ControleEstoqueAPI.Dtos;
using ControleEstoqueAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _service;

        private readonly IPdfService _pdfService;

        public RelatorioController(IRelatorioService service, IPdfService pdfService)
        {
            _service = service;
            _pdfService = pdfService;
        }

        [HttpGet("dashboard/pdf")]
        public async Task<IActionResult> GetDashboardPdf()
        {
            var dashboard = await _service.GetDashboardResumoAsync();
            var pdf = _pdfService.GerarPdfDoDashboard(dashboard);

            return File(pdf, "application/pdf", $"RelatorioDashboard_{DateTime.Now:yyyyMMddHHmmss}.pdf");
        }


        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardDto>> GetDashboard()
        {
            var dashboard = await _service.GetDashboardResumoAsync();
            return Ok(dashboard);
        }


        // Estoque Atual
        [HttpGet("estoque-atual")]
        public async Task<ActionResult<IEnumerable<EstoqueAtualDto>>> GetEstoqueAtual()
        {
            var result = await _service.GetEstoqueAtualAsync();
            return Ok(result);
        }

        // Entradas por período
        [HttpGet("entradas")]
        public async Task<ActionResult<IEnumerable<EntradaEstoqueDto>>> GetEntradasPorPeriodo(
            [FromQuery] string dataInicio, [FromQuery] string dataFim)
        {
            if (!TryParseDate(dataInicio, out var dataInicioParsed) ||
                !TryParseDate(dataFim, out var dataFimParsed))
            {
                return BadRequest("Datas inválidas. Use o formato dd/MM/yyyy ou dd-MM-yyyy.");
            }

            var result = await _service.GetEntradasPorPeriodoAsync(dataInicioParsed, dataFimParsed);
            return Ok(result);
        }

        // Saídas por período
        [HttpGet("saidas")]
        public async Task<ActionResult<IEnumerable<SaidaEstoqueDto>>> GetSaidasPorPeriodo(
            [FromQuery] string dataInicio, [FromQuery] string dataFim)
        {
            if (!TryParseDate(dataInicio, out var dataInicioParsed) ||
                !TryParseDate(dataFim, out var dataFimParsed))
            {
                return BadRequest("Datas inválidas. Use o formato dd/MM/yyyy ou dd-MM-yyyy.");
            }

            var result = await _service.GetSaidasPorPeriodoAsync(dataInicioParsed, dataFimParsed);
            return Ok(result);
        }

        // 💰 Resumo Financeiro por período
        [HttpGet("resumo-financeiro")]
        public async Task<ActionResult<ResumoFinanceiroDto>> GetResumoFinanceiro(
            [FromQuery] string dataInicio, [FromQuery] string dataFim)
        {
            if (!TryParseDate(dataInicio, out var dataInicioParsed) ||
                !TryParseDate(dataFim, out var dataFimParsed))
            {
                return BadRequest("Datas inválidas. Use o formato dd/MM/yyyy ou dd-MM-yyyy.");
            }

            var result = await _service.GetResumoFinanceiroAsync(dataInicioParsed, dataFimParsed);
            return Ok(result);
        }

        // Método auxiliar para parse de data
        private bool TryParseDate(string input, out DateTime date)
        {
            var formatos = new[] { "dd/MM/yyyy", "dd-MM-yyyy" };
            return DateTime.TryParseExact(
                input,
                formatos,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out date);
        }
    }
}
