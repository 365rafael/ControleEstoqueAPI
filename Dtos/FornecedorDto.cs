namespace ControleEstoqueAPI.Dtos
{
    public class FornecedorDto
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; }
    }

    public class CreateFornecedorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string? Telefone { get; set; }
    }
}
