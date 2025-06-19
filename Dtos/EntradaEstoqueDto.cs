namespace ControleEstoqueAPI.Dtos
{
    public class EntradaEstoqueDto
    {
        public int EntradaEstoqueId { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
        public decimal PrecoCusto { get; set; }
        public string NumeroSerie { get; set; } = string.Empty;
        public DateTime DataEntrada { get; set; }
        public bool Disponivel { get; set; }
    }

    public class CreateEntradaEstoqueDto
    {
        public int ProdutoId { get; set; }
        public decimal PrecoCusto { get; set; }
        public string NumeroSerie { get; set; } = string.Empty;
    }
}
