using System.ComponentModel.DataAnnotations;

namespace ControleEstoqueAPI.Models
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string? Telefone { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
