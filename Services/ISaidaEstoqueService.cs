using ControleEstoqueAPI.Dtos;

namespace ControleEstoqueAPI.Services
{
    public interface ISaidaEstoqueService
    {
        Task<IEnumerable<SaidaEstoqueDto>> GetAllAsync();
        Task<SaidaEstoqueDto?> GetByIdAsync(int id);
        Task<SaidaEstoqueDto> CreateAsync(CreateSaidaEstoqueDto dto);
    }
}
