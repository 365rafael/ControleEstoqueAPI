using System.ComponentModel.DataAnnotations;

namespace ControleEstoqueAPI.Models
{
    public class SaidaEstoque
    {
        public int SaidaEstoqueId { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Required]
        public decimal PrecoVenda { get; set; }

        [Required]
        public string NumeroSerie { get; set; } = string.Empty;

        public DateTime DataSaida { get; set; } = DateTime.Now;
    }
}
