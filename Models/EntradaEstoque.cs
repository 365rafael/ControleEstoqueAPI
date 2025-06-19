using System.ComponentModel.DataAnnotations;

namespace ControleEstoqueAPI.Models
{
    public class EntradaEstoque
    {
        public int EntradaEstoqueId { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Required]
        public decimal PrecoCusto { get; set; }

        [Required]
        public string NumeroSerie { get; set; } = string.Empty;

        public DateTime DataEntrada { get; set; } = DateTime.Now;

        public bool Disponivel { get; set; } = true;
    }
}
