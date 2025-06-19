using ControleEstoqueAPI.Data;
using ControleEstoqueAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueAPI.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly AppDbContext _context;

        public RelatorioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardResumoAsync()
        {
            var hoje = DateTime.Today;
            var primeiroDiaMes = new DateTime(hoje.Year, hoje.Month, 1);
            var ultimoDiaMes = primeiroDiaMes.AddMonths(1).AddDays(-1);

            // Total produtos
            var totalProdutos = await _context.Produtos.CountAsync();

            // Quantidade estoque disponível
            var quantidadeEstoque = await _context.EntradasEstoque
                .Where(e => e.Disponivel)
                .CountAsync();

            // Entradas mês atual
            var entradasMes = await _context.EntradasEstoque
                .Where(e => e.DataEntrada >= primeiroDiaMes && e.DataEntrada <= ultimoDiaMes)
                .ToListAsync();

            var totalEntradasMes = entradasMes.Count;
            var valorTotalEntradasMes = entradasMes.Sum(e => e.PrecoCusto);

            // Saídas mês atual
            var saidasMes = await _context.SaidasEstoque
                .Where(s => s.DataSaida >= primeiroDiaMes && s.DataSaida <= ultimoDiaMes)
                .ToListAsync();

            var totalSaidasMes = saidasMes.Count;
            var valorTotalSaidasMes = saidasMes.Sum(s => s.PrecoVenda);

            // Lucro
            var lucroMes = valorTotalSaidasMes - valorTotalEntradasMes;

            // Top 5 produtos mais vendidos
            var topProdutos = await _context.SaidasEstoque
                .Where(s => s.DataSaida >= primeiroDiaMes && s.DataSaida <= ultimoDiaMes)
                .GroupBy(s => s.ProdutoId)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => new ProdutoMaisVendidoDto
                {
                    ProdutoId = g.Key,
                    ProdutoNome = _context.Produtos.Where(p => p.ProdutoId == g.Key).Select(p => p.Nome).FirstOrDefault() ?? "",
                    QuantidadeVendida = g.Count()
                })
                .ToListAsync();

            return new DashboardDto
            {
                TotalProdutos = totalProdutos,
                QuantidadeEstoqueDisponivel = quantidadeEstoque,
                TotalEntradasMes = totalEntradasMes,
                ValorTotalEntradasMes = valorTotalEntradasMes,
                TotalSaidasMes = totalSaidasMes,
                ValorTotalSaidasMes = valorTotalSaidasMes,
                LucroMes = lucroMes,
                TopProdutosMaisVendidos = topProdutos
            };
        }


        public async Task<IEnumerable<EstoqueAtualDto>> GetEstoqueAtualAsync()
        {
            var produtos = await _context.Produtos.ToListAsync();

            var estoque = await _context.EntradasEstoque
                .Where(e => e.Disponivel)
                .GroupBy(e => e.ProdutoId)
                .Select(g => new
                {
                    ProdutoId = g.Key,
                    Quantidade = g.Count()
                })
                .ToListAsync();

            var resultado = from p in produtos
                            join e in estoque on p.ProdutoId equals e.ProdutoId into pe
                            from e in pe.DefaultIfEmpty()
                            select new EstoqueAtualDto
                            {
                                ProdutoId = p.ProdutoId,
                                ProdutoNome = p.Nome,
                                Codigo = p.Codigo,
                                QuantidadeDisponivel = e?.Quantidade ?? 0
                            };

            return resultado.ToList();
        }

        public async Task<IEnumerable<EntradaEstoqueDto>> GetEntradasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _context.EntradasEstoque
                .Include(e => e.Produto)
                .Where(e => e.DataEntrada >= dataInicio && e.DataEntrada <= dataFim)
                .Select(e => new EntradaEstoqueDto
                {
                    EntradaEstoqueId = e.EntradaEstoqueId,
                    ProdutoId = e.ProdutoId,
                    ProdutoNome = e.Produto.Nome,
                    PrecoCusto = e.PrecoCusto,
                    NumeroSerie = e.NumeroSerie,
                    DataEntrada = e.DataEntrada,
                    Disponivel = e.Disponivel
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SaidaEstoqueDto>> GetSaidasPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _context.SaidasEstoque
                .Include(s => s.Produto)
                .Where(s => s.DataSaida >= dataInicio && s.DataSaida <= dataFim)
                .Select(s => new SaidaEstoqueDto
                {
                    SaidaEstoqueId = s.SaidaEstoqueId,
                    ProdutoId = s.ProdutoId,
                    ProdutoNome = s.Produto.Nome,
                    PrecoVenda = s.PrecoVenda,
                    NumeroSerie = s.NumeroSerie,
                    DataSaida = s.DataSaida
                })
                .ToListAsync();
        }

        public async Task<ResumoFinanceiroDto> GetResumoFinanceiroAsync(DateTime dataInicio, DateTime dataFim)
        {
            var totalCusto = await _context.EntradasEstoque
                .Where(e => e.DataEntrada >= dataInicio && e.DataEntrada <= dataFim)
                .SumAsync(e => (decimal?)e.PrecoCusto) ?? 0;

            var totalVenda = await _context.SaidasEstoque
                .Where(s => s.DataSaida >= dataInicio && s.DataSaida <= dataFim)
                .SumAsync(s => (decimal?)s.PrecoVenda) ?? 0;

            return new ResumoFinanceiroDto
            {
                TotalCustoEntradas = totalCusto,
                TotalVendaSaidas = totalVenda,
                Lucro = totalVenda - totalCusto
            };
        }
    }
}
