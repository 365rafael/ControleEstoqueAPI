namespace ControleEstoqueAPI.Dtos
{
    public class ResumoFinanceiroDto
    {
        public decimal TotalCustoEntradas { get; set; }
        public decimal TotalVendaSaidas { get; set; }
        public decimal Lucro { get; set; }
    }
}
