using ControleEstoqueAPI.Models;

namespace ControleEstoqueAPI.Repositories
{
    public interface IEntradaEstoqueRepository
    {
        Task<IEnumerable<EntradaEstoque>> GetAllAsync();
        Task<EntradaEstoque?> GetByIdAsync(int id);
        Task<EntradaEstoque?> GetByNumeroSerieAsync(string numeroSerie);
        Task AddAsync(EntradaEstoque entrada);
        Task DeleteAsync(EntradaEstoque entrada);
    }
}
