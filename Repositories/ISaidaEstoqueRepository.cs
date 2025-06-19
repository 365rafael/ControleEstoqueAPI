using ControleEstoqueAPI.Models;

namespace ControleEstoqueAPI.Repositories
{
    public interface ISaidaEstoqueRepository
    {
        Task<IEnumerable<SaidaEstoque>> GetAllAsync();
        Task<SaidaEstoque?> GetByIdAsync(int id);
        Task AddAsync(SaidaEstoque saida);
    }
}
