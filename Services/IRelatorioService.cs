using ControleEstoqueAPI.Dtos;

namespace ControleEstoqueAPI.Services
{
    public interface IRelatorioService
    {
        Task<IEnumerable<EstoqueAtualDto>> GetEstoqueAtualAsync();
        Task<IEnumerable<EntradaEstoqueDto>> GetEntradasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<SaidaEstoqueDto>> GetSaidasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<ResumoFinanceiroDto> GetResumoFinanceiroAsync(DateTime dataInicio, DateTime dataFim);
        Task<DashboardDto> GetDashboardResumoAsync();

    }
}
