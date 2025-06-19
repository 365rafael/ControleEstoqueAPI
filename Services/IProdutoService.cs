using ControleEstoqueAPI.Dtos;

namespace ControleEstoqueAPI.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task<ProdutoDto?> GetByIdAsync(int id);
        Task<ProdutoDto> CreateAsync(CreateProdutoDto dto);
        Task<bool> UpdateAsync(int id, CreateProdutoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
