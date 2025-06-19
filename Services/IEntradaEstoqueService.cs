using ControleEstoqueAPI.Dtos;

namespace ControleEstoqueAPI.Services
{
    public interface IEntradaEstoqueService
    {
        Task<IEnumerable<EntradaEstoqueDto>> GetAllAsync();
        Task<EntradaEstoqueDto?> GetByIdAsync(int id);
        Task<EntradaEstoqueDto> CreateAsync(CreateEntradaEstoqueDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
