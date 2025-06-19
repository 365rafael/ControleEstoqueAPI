namespace ControleEstoqueAPI.Dtos
{
    public class EstoqueAtualDto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
        public string? Codigo { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
