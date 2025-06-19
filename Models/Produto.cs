using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoqueAPI.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string? Codigo { get; set; }

        [Required]
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }

        public ICollection<EntradaEstoque>? Entradas { get; set; }
        public ICollection<SaidaEstoque>? Saidas { get; set; }
    }
}
