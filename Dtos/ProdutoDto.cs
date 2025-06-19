namespace ControleEstoqueAPI.Dtos
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Codigo { get; set; }
        public int FornecedorId { get; set; }
        public string FornecedorNome { get; set; } = string.Empty;
    }

    public class CreateProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Codigo { get; set; }
        public int FornecedorId { get; set; }
    }
}
