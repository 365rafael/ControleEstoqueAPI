namespace ControleEstoqueAPI.Dtos
{
    public class DashboardDto
    {
        public int TotalProdutos { get; set; }
        public int QuantidadeEstoqueDisponivel { get; set; }
        public int TotalEntradasMes { get; set; }
        public decimal ValorTotalEntradasMes { get; set; }
        public int TotalSaidasMes { get; set; }
        public decimal ValorTotalSaidasMes { get; set; }
        public decimal LucroMes { get; set; }
        public List<ProdutoMaisVendidoDto> TopProdutosMaisVendidos { get; set; } = new();
    }

    public class ProdutoMaisVendidoDto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
        public int QuantidadeVendida { get; set; }
    }
}
