namespace ControleEstoqueAPI.Dtos
{
    public class SaidaEstoqueDto
    {
        public int SaidaEstoqueId { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
        public decimal PrecoVenda { get; set; }
        public string NumeroSerie { get; set; } = string.Empty;
        public DateTime DataSaida { get; set; }
    }

    public class CreateSaidaEstoqueDto
    {
        public int ProdutoId { get; set; }
        public decimal PrecoVenda { get; set; }
        public string NumeroSerie { get; set; } = string.Empty;
    }
}
